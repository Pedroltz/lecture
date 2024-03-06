using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Classes
{
    public class BookBase
    {
        public string Title { get; }
        public string Author { get; }
        public string[] Categories { get; }
        public string Language { get; }
        public string PdfLink { get; }

        public BookBase(string title, string author, string[] categories, string language, string pdfLink)
        {
            Title = title;
            Author = author;
            Categories = categories;
            Language = language;
            PdfLink = pdfLink;
        }
    }
}
