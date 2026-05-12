using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Lecture.Services;

public static class ImageLoader
{
    public static Bitmap LoadAsset(string assetPath)
    {
        var uri = new Uri($"avares://Lecture/{assetPath}");
        using var stream = AssetLoader.Open(uri);
        return new Bitmap(stream);
    }

    public static async Task<Bitmap?> LoadFileAsync(string filePath)
    {
        try
        {
            return await Task.Run(() => new Bitmap(filePath));
        }
        catch
        {
            return null;
        }
    }
}
