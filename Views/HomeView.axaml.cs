using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using Lecture.Models;
using Lecture.Services;
using System.Linq;

namespace Lecture.Views;

public partial class HomeView : UserControl
{
    private static readonly string[] AllCategories =
        ["Populares", "Adicionados Recentemente", "Vistos para Enem", "Clássicos", "Romances", "Cultos"];

    private readonly IReadOnlyList<BookBase> _books;
    private Bitmap? _cover;
    private DispatcherTimer? _scrollTimer;

    public HomeView(IReadOnlyList<BookBase> books)
    {
        InitializeComponent();
        _books = books;
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        try { _cover = ImageLoader.LoadAsset("Assets/book-cape-1.png"); }
        catch { /* proceed without cover placeholder */ }
        BuildCarousels();
    }

    private void BuildCarousels()
    {
        if (_books.Count == 0) return;
        foreach (var category in PickRandom(AllCategories, 3))
            mainPanel.Children.Add(CreateCarouselSection(category));
    }

    private Control CreateCarouselSection(string categoryName)
    {
        var booksRow = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 8, Margin = new Thickness(4) };
        foreach (var book in PickRandom(_books.ToArray(), Math.Min(12, _books.Count)))
            booksRow.Children.Add(CreateBookCard(book));

        var scrollViewer = new ScrollViewer
        {
            HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
            VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,
            Height = 270,
            Content = booksRow,
        };

        var prevBtn = MakeNavButton("<");
        var nextBtn = MakeNavButton(">");
        prevBtn.Click += (_, _) => ScrollCarousel(scrollViewer, -200);
        nextBtn.Click += (_, _) => ScrollCarousel(scrollViewer, +200);

        var navRow = new DockPanel { LastChildFill = true };
        DockPanel.SetDock(prevBtn, Dock.Left);
        DockPanel.SetDock(nextBtn, Dock.Right);
        navRow.Children.Add(prevBtn);
        navRow.Children.Add(nextBtn);
        navRow.Children.Add(scrollViewer);

        return new StackPanel
        {
            Margin = new Thickness(24, 12, 24, 4),
            Children =
            {
                new TextBlock { Text = categoryName, FontSize = 14, FontWeight = FontWeight.SemiBold, Margin = new Thickness(0,0,0,6) },
                navRow,
            }
        };
    }

    private static Button MakeNavButton(string label) => new()
    {
        Content = label, Width = 36, FontSize = 16,
        FontWeight = FontWeight.Bold,
        Background = Brushes.Transparent,
        BorderThickness = default,
        VerticalAlignment = VerticalAlignment.Center,
    };

    private Border CreateBookCard(BookBase book)
    {
        IBrush background = _cover != null
            ? new ImageBrush(_cover) { Stretch = Stretch.Fill }
            : new SolidColorBrush(Color.FromArgb(255, 245, 245, 255));

        var titleText = book.Title.Length > 20 ? book.Title[..17] + "..." : book.Title;

        var card = new Border
        {
            Width = 180,
            Height = 250,
            Cursor = new Cursor(StandardCursorType.Hand),
            Background = background,
            ClipToBounds = true,
            Child = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255)),
                Padding = new Thickness(4, 2),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Child = new TextBlock
                {
                    Text = titleText,
                    TextAlignment = TextAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    MaxWidth = 160,
                    Foreground = Brushes.Black,
                },
            },
        };

        card.PointerEntered += (_, _) => card.Opacity = 0.85;
        card.PointerExited += (_, _) => card.Opacity = 1.0;
        card.PointerReleased += (_, e) =>
        {
            if (e.InitialPressMouseButton == MouseButton.Left)
                PdfOpener.Open(book.PdfLink);
        };

        return card;
    }

    private void ScrollCarousel(ScrollViewer sv, double delta)
    {
        double max = sv.Extent.Width - sv.Viewport.Width;
        double target = Math.Clamp(sv.Offset.X + delta, 0, Math.Max(0, max));
        AnimateCarouselScroll(sv, target);
    }

    private void AnimateCarouselScroll(ScrollViewer sv, double targetX)
    {
        _scrollTimer?.Stop();
        _scrollTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16) };
        _scrollTimer.Tick += (_, _) => OnCarouselScrollTick(sv, targetX);
        _scrollTimer.Start();
    }

    private void OnCarouselScrollTick(ScrollViewer sv, double targetX)
    {
        const double step = 12;
        double current = sv.Offset.X;
        if (Math.Abs(current - targetX) <= step)
        {
            sv.Offset = new Vector(targetX, 0);
            _scrollTimer?.Stop();
            _scrollTimer = null;
            return;
        }
        sv.Offset = new Vector(current < targetX ? current + step : current - step, 0);
    }

    private static T[] PickRandom<T>(T[] source, int count)
    {
        var rng = new Random();
        return [.. source.OrderBy(_ => rng.Next()).Take(count)];
    }
}
