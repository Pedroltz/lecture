using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
// using static System.Reflection.Metadata.BlobBuilder;

namespace Lecture.Classes
{
    public class BooksData
    {
        public readonly List<BookBase> data = new();

        public BooksData()
        {
        }

        public async Task LoadDataAsync()
        {
            string json = await ReadJsonFromUrlAsync("https://viikdev.github.io/booksApi/data.json");

            dynamic books = JsonConvert.DeserializeObject(json);

            foreach (var book in books)
            {
                if (book != null)
                {
                    string title = book.title;
                    string author = book.author;
                    string[] categories = book.categories.ToObject<string[]>();
                    string language = book.language;
                    string pdfLink = book.pdfLink;

                    data.Add(new BookBase(title, author, categories, language, pdfLink));
                }
                else
                {
                    Debug.WriteLine("Encountered a null book entry.");
                }
            }
        }

        private async Task<string> ReadJsonFromUrlAsync(string url) {
            using (HttpClient client = new())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle the case when the request fails
                    Debug.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
                    return string.Empty;
                }
            }
        }
    }
}
