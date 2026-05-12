using System.Diagnostics;

namespace Lecture.Services;

public static class PdfOpener
{
    public static void Open(string link)
    {
        try
        {
            Process.Start(new ProcessStartInfo { FileName = link, UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Could not open book: {ex.Message}");
        }
    }
}
