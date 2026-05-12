using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Lecture.Models;

namespace Lecture.Services;

public class BooksDataService
{
    private static readonly HttpClient _http = new();
    private const string ApiUrl = "https://viikdev.github.io/booksApi/data.json";
    public const string BaseUrl = "https://viikdev.github.io/booksApi/";

    private sealed record BookDto(
        [property: JsonPropertyName("title")]   string Title,
        [property: JsonPropertyName("author")]  string Author,
        [property: JsonPropertyName("categories")] string[] Categories,
        [property: JsonPropertyName("language")] string Language,
        [property: JsonPropertyName("pdfLink")] string PdfLink);

    public async Task<IReadOnlyList<BookBase>> LoadBooksAsync()
    {
        try
        {
            var dtos = await _http.GetFromJsonAsync<BookDto[]>(ApiUrl) ?? [];
            return dtos
                .Select(d => new BookBase(d.Title, d.Author, d.Categories, d.Language, d.PdfLink))
                .ToList()
                .AsReadOnly();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to load books: {ex.Message}");
            return [];
        }
    }
}
