using Avalonia.Controls;
using Avalonia.Interactivity;
using Lecture.Services;

namespace Lecture.Views;

public partial class AboutView : UserControl
{
    public AboutView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        logoUnisagrado.Source = ImageLoader.LoadAsset("Assets/unisagrado-logo.png");
        logoMonolitica.Source = ImageLoader.LoadAsset("Assets/monolitica-pastoral-nova.png");
    }
}
