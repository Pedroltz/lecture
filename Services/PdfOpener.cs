using System.Diagnostics;

namespace Lecture.Services;

public static class PdfOpener
{
    public static void Open(string pdfLink)
    {
        var url = BooksDataService.BaseUrl + pdfLink;
        try
        {
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Could not open PDF: {ex.Message}");
        }
    }
}
