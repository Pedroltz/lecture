using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Lecture.Models;

namespace Lecture.Services;

public class BooksDataService
{
    private static readonly HttpClient _http = new();
    private const string ApiUrl = "https://gutendex.com/books/?languages=pt";

    private static readonly HashSet<string> EnemAuthors = new(StringComparer.OrdinalIgnoreCase)
    {
        "Machado de Assis", "Alencar, José de",
        "Barreto, Lima", "Azevedo, Aluísio",
        "Bilac, Olavo", "Lobato, Monteiro",
        "Queirós, Eça de",
    };

    private sealed record GutendexAuthor(
        [property: JsonPropertyName("name")] string Name);

    private sealed record GutendexBook(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("authors")] GutendexAuthor[] Authors,
        [property: JsonPropertyName("subjects")] string[] Subjects,
        [property: JsonPropertyName("languages")] string[] Languages,
        [property: JsonPropertyName("download_count")] int DownloadCount,
        [property: JsonPropertyName("formats")] Dictionary<string, string> Formats);

    private sealed record GutendexResponse(
        [property: JsonPropertyName("results")] GutendexBook[] Results);

    public async Task<IReadOnlyList<BookBase>> LoadBooksAsync()
    {
        try
        {
            var tasks = new[]
            {
                _http.GetFromJsonAsync<GutendexResponse>(ApiUrl),
                _http.GetFromJsonAsync<GutendexResponse>(ApiUrl + "&page=2"),
            };

            var responses = await Task.WhenAll(tasks);

            var books = new List<BookBase>();
            foreach (var response in responses)
            {
                if (response == null) continue;
                foreach (var book in response.Results)
                {
                    var readLink = book.Formats.GetValueOrDefault("text/html")
                        ?? book.Formats.GetValueOrDefault("application/pdf")
                        ?? book.Formats.GetValueOrDefault("text/plain; charset=utf-8");

                    if (string.IsNullOrEmpty(readLink)) continue;

                    var author = book.Authors.FirstOrDefault()?.Name ?? "Desconhecido";
                    var categories = MapCategories(book.Subjects, book.DownloadCount, author, book.Id);

                    books.Add(new BookBase(book.Title, author, categories, "Português", readLink));
                }
            }

            return books.AsReadOnly();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to load books: {ex.Message}");
            return [];
        }
    }

    private static string[] MapCategories(string[] subjects, int downloadCount, string author, int id)
    {
        var categories = new HashSet<string>();
        var subjectsJoined = string.Join(" ", subjects).ToLowerInvariant();

        if (downloadCount > 500)
            categories.Add("Populares");

        if (EnemAuthors.Contains(author))
            categories.Add("Vistos para Enem");

        if (subjectsJoined.Contains("fiction") || subjectsJoined.Contains("romance") || subjectsJoined.Contains("novel"))
            categories.Add("Romances");

        if (subjectsJoined.Contains("poetry") || subjectsJoined.Contains("poem") || subjectsJoined.Contains("poesia"))
            categories.Add("Cultos");

        if (subjectsJoined.Contains("philosophy") || subjectsJoined.Contains("essay"))
            categories.Add("Cultos");

        if (id > 60000)
            categories.Add("Adicionados Recentemente");

        categories.Add("Clássicos");

        return [.. categories];
    }
}
