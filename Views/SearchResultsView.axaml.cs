using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Lecture.Models;
using Lecture.Services;

namespace Lecture.Views;

public partial class SearchResultsView : UserControl
{
    private readonly IReadOnlyList<BookBase> _books;
    private Bitmap? _cover;

    public SearchResultsView(IReadOnlyList<BookBase> books)
    {
        InitializeComponent();
        _books = books;
        Loaded += OnLoaded;
    }

    private async void OnLoaded(object? sender, RoutedEventArgs e)
    {
        resultsLabel.Text = $"Resultados ({_books.Count}):";
        _cover = await Task.Run(() => ImageLoader.LoadAsset("Assets/book-cape-1.png"));
        foreach (var book in _books)
            resultsPanel.Children.Add(CreateBookButton(book));
    }

    private Button CreateBookButton(BookBase book)
    {
        IBrush background = _cover != null
            ? new ImageBrush(_cover) { Stretch = Stretch.Fill }
            : new SolidColorBrush(Color.FromArgb(255, 245, 245, 255));

        var titleText = book.Title.Length > 20 ? book.Title[..17] + "..." : book.Title;

        var btn = new Button
        {
            Width = 180,
            Height = 250,
            Margin = new Avalonia.Thickness(6),
            Tag = book.PdfLink,
            Cursor = new Cursor(StandardCursorType.Hand),
            Padding = default,
            Background = background,
            BorderThickness = default,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
            Content = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255)),
                Padding = new Avalonia.Thickness(4, 2),
                Child = new TextBlock
                {
                    Text = titleText,
                    TextAlignment = TextAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    MaxWidth = 160,
                },
            },
        };

        btn.Click += (_, _) => { if (btn.Tag is string link) PdfOpener.Open(link); };
        return btn;
    }
}
