using System;
using System.Windows.Forms;
using Lecture.Classes;
namespace Lecture;

public partial class ProjectWrapper : Form
{
    private BooksData booksData;
    private FormHome formHome;
    private FormAbout formAbout;
    private FormCategoriesList formCategoriesList;
    private FormSearchResults formSearchResults;
    public ProjectWrapper()
    {
        InitializeComponent();
        InitializeAsync();
        this.Load += ProjectWrapperLoad;
        this.Resize += ProjectWrapperResize;
    }

    private async void InitializeAsync()
    {
        booksData = new BooksData();
        await booksData.LoadDataAsync();
        formHome = new(booksData);
        formAbout = new();
        formCategoriesList = new();
        OpenChildForm(formHome);
    }

    private Form activeForm = null;
    private void OpenChildForm(Form childForm, bool forceChange = false)
    {
        try
        {
            if (activeForm != null && activeForm.GetType() == childForm.GetType() && !forceChange)
            {
                return; // If the activeForm is of the same type as childForm, do nothing
            }
            if (activeForm != null)
            {
                activeForm.Hide();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
        catch (System.Exception)
        {
            MessageBox.Show("Aguarde enquanto o programa está carregando...");
            throw;
        }
    }
    private void ProjectWrapperLoad(object? sender, EventArgs e)
    {
        this.ActiveControl = childFormPanel;
        AdjustSizes();
        CenterElements();
    }
    private void ProjectWrapperResize(object? sender, EventArgs e)
    {
        AdjustSizes();
        CenterElements();
    }
    private void CenterElements()
    {
        panelSearchBarButtonWrapper.Location = new Point((panelSearchBar.Width - panelSearchBarButtonWrapper.Width) / 2, (panelSearchBar.Height - panelSearchBarButtonWrapper.Height) / 2);
        searchTextBox.Location = new Point(0, (panelSearchBarButtonWrapper.Height - searchTextBox.Height) / 2);
        buttonSearchBar.Location = new Point(panelSearchBarButtonWrapper.Width - buttonSearchBar.Width, (panelSearchBarButtonWrapper.Height - buttonSearchBar.Height) / 2);
        pictureBoxLogo.Location = new Point((panelLogo.Width - pictureBoxLogo.Width) / 2, 0);
    }
    private void AdjustSizes()
    {
        panelSearchBarButtonWrapper.Size = new Size((int)(panelSearchBar.Width * .7), 35);
        searchTextBox.Size = new Size((int)(panelSearchBarButtonWrapper.Width * .8), 35);
        buttonSearchBar.Size = new Size((int)(panelSearchBarButtonWrapper.Width * .18), searchTextBox.Height);
    }

    private void SearchTextBoxEnter(object sender, EventArgs e)
    {
        if (searchTextBox.Text == searchTextBox.Tag.ToString())
        {
            searchTextBox.Text = "";
            searchTextBox.ForeColor = System.Drawing.Color.Black;
        }
    }
    private void SearchTextBoxLeave(object sender, EventArgs e)
    {
        ClearSearchTextBox();
    }
    private void ClearSearchTextBox()
    {
        if (string.IsNullOrWhiteSpace(searchTextBox.Text))
        {
            searchTextBox.Text = searchTextBox.Tag.ToString();
            searchTextBox.ForeColor = System.Drawing.Color.Gray;
            OpenChildForm(formHome);
        }
    }
    private void ButtonSearchBarClick(object sender, EventArgs e)
    {
        ClearSearchTextBox();
        if (searchTextBox.ForeColor != System.Drawing.Color.Gray) { // Check if search bar is filled with something else rather the placeholder
            List<BookBase> searchResults = GetSearchResults(booksData);
            formSearchResults = new(searchResults);
            OpenChildForm(formSearchResults,true);
        }
    }

    private void FormHomeButtonClick(object sender, EventArgs e)
    {
        OpenChildForm(formHome);
    }

    private bool categoriesDropped = false;

    private void CategoriesDropTimerTick(object sender, EventArgs e)
    {
        if (!categoriesDropped)
        {
            flowLayoutPanelCategoriesSubMenu.Height += 10;
            if (flowLayoutPanelCategoriesSubMenu.Height >= 180)
            {
                categoriesDropped = true;
                categoriesDropTimer.Stop();
            }
        }
        else
        {
            flowLayoutPanelCategoriesSubMenu.Height -= 10;
            if (flowLayoutPanelCategoriesSubMenu.Height <= 0)
            {
                categoriesDropped = false;
                categoriesDropTimer.Stop();
            }
        }
    }
    private void CategoriesButtonClick(object sender, EventArgs e)
    {
        categoriesDropTimer.Start();
    }
    private void CategoriesSubMenuButtonClick(object sender, EventArgs e)
    {
        this.ActiveControl = searchTextBox;
        searchTextBox.Text = "#" + ((Button)sender).Tag;
        searchTextBox.SelectionLength = 0;
        searchTextBox.Select(searchTextBox.Text.Length, 0);
    }
    private void SearchTextBoxKeyPress(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            ButtonSearchBarClick(sender, e);
            this.ActiveControl = null;
            e.Handled = e.SuppressKeyPress = true;
        }
    }
    private void CategoriesPlusSubMenuButtonClick(object sender, EventArgs e)
    {
        // OpenChildForm(formCategoriesList);
        MessageBox.Show("Em desenvolvimento...");
    }
    private void AboutButtonClick(object sender, EventArgs e)
    {
        OpenChildForm(formAbout);
    }
    private List<BookBase> GetSearchResults(BooksData sourceData) {
        List<BookBase> filteredBooks;
        if (searchTextBox.Text[0] == '#') {
            filteredBooks = sourceData.data.Where(book => book.Categories.Any(category => string.Equals(category, searchTextBox.Text.Substring(1), StringComparison.OrdinalIgnoreCase))).ToList();
        } else {
            filteredBooks = sourceData.data.Where(book => book.Title.Contains(searchTextBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        // MessageBox.Show("" + filteredBooks.Count);
        return filteredBooks;
    }
}
