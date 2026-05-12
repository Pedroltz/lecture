using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Lecture.Models;
using Lecture.Services;

namespace Lecture.Views;

public partial class MainWindow : Window
{
    private readonly BooksDataService _dataService = new();
    private IReadOnlyList<BookBase> _books = [];
    private HomeView? _homeView;
    private AboutView? _aboutView;

    public MainWindow()
    {
        InitializeComponent();
        Opened += async (_, _) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        _books = await _dataService.LoadBooksAsync();
        _homeView = new HomeView(_books);
        _aboutView = new AboutView();

        logoImage.Source = ImageLoader.LoadAsset("Assets/tyto-logo.png");
        contentArea.Content = _homeView;
    }

    private void HomeButtonClick(object? sender, RoutedEventArgs e) =>
        contentArea.Content = _homeView;

    private void AboutButtonClick(object? sender, RoutedEventArgs e) =>
        contentArea.Content = _aboutView;

    private void CategoriesButtonClick(object? sender, RoutedEventArgs e) =>
        categoriesSubMenu.IsVisible = !categoriesSubMenu.IsVisible;

    private void CategoryTagClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is string tag)
        {
            searchBox.Text = tag;
            categoriesSubMenu.IsVisible = false;
            RunSearch();
        }
    }

    private void CategoriesMoreClick(object? sender, RoutedEventArgs e)
    {
        categoriesSubMenu.IsVisible = false;
        // future: open categories list view
    }

    private void SearchButtonClick(object? sender, RoutedEventArgs e) => RunSearch();

    private void SearchBoxKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter) RunSearch();
    }

    private void RunSearch()
    {
        string query = searchBox.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(query)) { contentArea.Content = _homeView; return; }

        var results = _books.Where(b =>
            b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

        contentArea.Content = new SearchResultsView(results);
    }
}
