using System;
using System.Drawing;
using System.Windows.Forms;
namespace Lecture;

public partial class ProjectWrapper
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        // ***Create components here***
        FlowLayoutPanel flowLayoutPanelSideMenu = new FlowLayoutPanel();
        panelLogo = new Panel();
        Button homeButton = new Button();
        Button categoriesButton = new Button();
        flowLayoutPanelCategoriesSubMenu = new FlowLayoutPanel();
        categoriesSubMenuButton1 = new Button();
        categoriesSubMenuButton2 = new Button();
        categoriesSubMenuButton3 = new Button();
        categoriesSubMenuButton4 = new Button();
        panelSearchBar = new Panel();
        TableLayoutPanel tablePanel = new TableLayoutPanel();
        TableLayoutPanel tablePanelRight = new TableLayoutPanel();
        childFormPanel = new Panel();
        searchTextBox = new TextBox();
        panelSearchBarButtonWrapper = new Panel();
        buttonSearchBar = new Button();
        categoriesDropTimer = new System.Windows.Forms.Timer();
        Panel panelAboutButton = new Panel();
        aboutButton = new Button();
        pictureBoxLogo = new PictureBox();

        panelAboutButton.Dock = DockStyle.Fill;
        panelAboutButton.Margin = new Padding(0);
        panelAboutButton.Controls.Add(flowLayoutPanelSideMenu);
        panelAboutButton.Controls.Add(aboutButton);
        // panelAboutButton.BackColor = Color.FromArgb(255, 11, 7, 17);
        panelAboutButton.BackColor = Color.FromArgb(255, 21, 36, 71);

        aboutButton.Dock = DockStyle.Bottom;
        aboutButton.Height = 45;
        aboutButton.Width = flowLayoutPanelSideMenu.Width;
        aboutButton.Text = "Sobre";
        aboutButton.FlatStyle = FlatStyle.Flat;
        aboutButton.FlatAppearance.BorderSize = 0;
        aboutButton.ForeColor = Color.FromArgb(255, 245, 245, 245);
        aboutButton.Margin = new Padding(0);
        aboutButton.Click += AboutButtonClick;

        childFormPanel.BackColor = Color.FromArgb(255, 230, 230, 230);
        childFormPanel.Dock = DockStyle.Fill;
        childFormPanel.Margin = new Padding(0);

        tablePanel.Dock = DockStyle.Fill;
        tablePanel.ColumnCount = 2;
        tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200)); // 200 is the fixed width for the left panel
        tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // Remaining space for the top panel
        tablePanel.Margin = new Padding(0);

        // Add controls to the TableLayoutPanel
        tablePanel.Controls.Add(panelAboutButton, 0, 0);
        tablePanel.Controls.Add(tablePanelRight, 1, 0);

        tablePanelRight.Dock = DockStyle.Fill;
        tablePanelRight.RowCount = 2;
        tablePanelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        tablePanelRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        tablePanelRight.Margin = new Padding(0);

        tablePanelRight.Controls.Add(panelSearchBar, 0, 0);
        tablePanelRight.Controls.Add(childFormPanel, 0, 1);

        flowLayoutPanelSideMenu.Dock = DockStyle.Left;
        flowLayoutPanelSideMenu.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanelSideMenu.Controls.Add(panelLogo);
        flowLayoutPanelSideMenu.Controls.Add(homeButton);
        flowLayoutPanelSideMenu.Controls.Add(categoriesButton);
        flowLayoutPanelSideMenu.Controls.Add(flowLayoutPanelCategoriesSubMenu);
        flowLayoutPanelSideMenu.Margin = new Padding(0);

        panelLogo.Height = 80;
        panelLogo.BackColor = Color.Transparent;
        panelLogo.Margin = new Padding(0);
        panelLogo.Controls.Add(pictureBoxLogo);

        Image originalImage = Image.FromFile(@"Resources/tyto-logo.png");

        // Calculate the width proportionally based on the original aspect ratio
        int targetHeight = 80;
        int targetWidth = (int)(originalImage.Width * ((float)targetHeight / originalImage.Height));

        // Create a new bitmap with the calculated width and the target height
        Bitmap resizedImage = new Bitmap(targetWidth, targetHeight);

        // Use Graphics to draw the original image onto the resized bitmap
        using (Graphics g = Graphics.FromImage(resizedImage))
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);
        }

        pictureBoxLogo.Height = 80;
        pictureBoxLogo.SizeMode = PictureBoxSizeMode.AutoSize;
        pictureBoxLogo.Image = resizedImage;

        homeButton.Height = 45;
        homeButton.Width = flowLayoutPanelSideMenu.Width;
        homeButton.Text = "Início";
        homeButton.FlatStyle = FlatStyle.Flat;
        homeButton.FlatAppearance.BorderSize = 0;
        homeButton.ForeColor = Color.FromArgb(255, 245, 245, 245);
        homeButton.Margin = new Padding(0);
        homeButton.Click += FormHomeButtonClick;

        categoriesButton.Height = 45;
        categoriesButton.Width = flowLayoutPanelSideMenu.Width;
        categoriesButton.Text = "Categorias";
        categoriesButton.FlatStyle = FlatStyle.Flat;
        categoriesButton.FlatAppearance.BorderSize = 0;
        categoriesButton.ForeColor = Color.FromArgb(255, 245, 245, 245);
        categoriesButton.Margin = new Padding(0);
        categoriesButton.Click += CategoriesButtonClick;

        flowLayoutPanelCategoriesSubMenu.Height = 0;
        flowLayoutPanelCategoriesSubMenu.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanelCategoriesSubMenu.Controls.Add(categoriesSubMenuButton1);
        flowLayoutPanelCategoriesSubMenu.Controls.Add(categoriesSubMenuButton2);
        flowLayoutPanelCategoriesSubMenu.Controls.Add(categoriesSubMenuButton3);
        flowLayoutPanelCategoriesSubMenu.Controls.Add(categoriesSubMenuButton4);
        // flowLayoutPanelCategoriesSubMenu.BackColor = Color.FromArgb(255, 35, 35, 35);
        flowLayoutPanelCategoriesSubMenu.BackColor = Color.FromArgb(255, 200, 62, 37);
        flowLayoutPanelCategoriesSubMenu.Margin = new Padding(0);
        flowLayoutPanelCategoriesSubMenu.Padding = new Padding(0, 10, 0, 10);

        categoriesSubMenuButton1.Height = 40;
        categoriesSubMenuButton1.Width = flowLayoutPanelCategoriesSubMenu.Width;
        categoriesSubMenuButton1.FlatStyle = FlatStyle.Flat;
        categoriesSubMenuButton1.FlatAppearance.BorderSize = 0;
        categoriesSubMenuButton1.ForeColor = Color.FromArgb(255, 245, 245, 245);
        categoriesSubMenuButton1.Margin = new Padding(0);
        categoriesSubMenuButton1.Text = "José de Alencar";
        categoriesSubMenuButton1.Tag = "JoséDeAlencar";
        categoriesSubMenuButton1.Click += CategoriesSubMenuButtonClick;

        categoriesSubMenuButton2.Height = 40;
        categoriesSubMenuButton2.Width = flowLayoutPanelCategoriesSubMenu.Width;
        categoriesSubMenuButton2.FlatStyle = FlatStyle.Flat;
        categoriesSubMenuButton2.FlatAppearance.BorderSize = 0;
        categoriesSubMenuButton2.ForeColor = Color.FromArgb(255, 245, 245, 245);
        categoriesSubMenuButton2.Margin = new Padding(0);
        categoriesSubMenuButton2.Text = "Machado de Assis";
        categoriesSubMenuButton2.Tag = "MachadoDeAssis";
        categoriesSubMenuButton2.Click += CategoriesSubMenuButtonClick;

        categoriesSubMenuButton3.Height = 40;
        categoriesSubMenuButton3.Width = flowLayoutPanelCategoriesSubMenu.Width;
        categoriesSubMenuButton3.FlatStyle = FlatStyle.Flat;
        categoriesSubMenuButton3.FlatAppearance.BorderSize = 0;
        categoriesSubMenuButton3.ForeColor = Color.FromArgb(255, 245, 245, 245);
        categoriesSubMenuButton3.Margin = new Padding(0);
        categoriesSubMenuButton3.Text = "Olavo Bilac";
        categoriesSubMenuButton3.Tag = "OlavoBilac";
        categoriesSubMenuButton3.Click += CategoriesSubMenuButtonClick;

        categoriesSubMenuButton4.Height = 40;
        categoriesSubMenuButton4.Width = flowLayoutPanelCategoriesSubMenu.Width;
        categoriesSubMenuButton4.FlatStyle = FlatStyle.Flat;
        categoriesSubMenuButton4.FlatAppearance.BorderSize = 0;
        categoriesSubMenuButton4.ForeColor = Color.FromArgb(255, 245, 245, 245);
        categoriesSubMenuButton4.Margin = new Padding(0);
        categoriesSubMenuButton4.Text = "Mais...";
        categoriesSubMenuButton4.Click += CategoriesPlusSubMenuButtonClick;

        panelSearchBar.Dock = DockStyle.Fill;
        panelSearchBar.Margin = new Padding(0);
        panelSearchBar.BackColor = Color.FromArgb(255, 42, 83, 164);
        panelSearchBar.Controls.Add(panelSearchBarButtonWrapper);

        panelSearchBarButtonWrapper.Margin = new Padding(0);
        panelSearchBarButtonWrapper.Size = new Size(300, 35);
        panelSearchBarButtonWrapper.MaximumSize = new Size(600, 35);
        panelSearchBarButtonWrapper.Controls.Add(searchTextBox);
        panelSearchBarButtonWrapper.Controls.Add(buttonSearchBar);

        searchTextBox.Margin = new Padding(0);
        searchTextBox.Text = "Pesquisar livro...";
        searchTextBox.ForeColor = Color.Gray;
        searchTextBox.Enter += SearchTextBoxEnter;
        searchTextBox.Leave += SearchTextBoxLeave;
        searchTextBox.GotFocus += SearchTextBoxEnter;
        searchTextBox.KeyDown += new KeyEventHandler(SearchTextBoxKeyPress);
        searchTextBox.Tag = searchTextBox.Text;
        searchTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);

        buttonSearchBar.Text = "Buscar";
        buttonSearchBar.Click += ButtonSearchBarClick;
        buttonSearchBar.BackColor = Color.FromArgb(255, 205, 205, 205);

        categoriesDropTimer.Enabled = false;
        categoriesDropTimer.Interval = 8;
        categoriesDropTimer.Tick += CategoriesDropTimerTick;

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width - 450, Screen.PrimaryScreen.WorkingArea.Height - 290);
        this.Text = "Lecture - Colégio Tyto";
        this.MinimumSize = this.Size;
        this.Controls.Add(tablePanel);
    }

    #endregion
    public Panel childFormPanel;
    public Panel panelSearchBar;
    public TextBox searchTextBox;
    public Panel panelSearchBarButtonWrapper;
    public Button buttonSearchBar;
    public System.Windows.Forms.Timer categoriesDropTimer;
    public FlowLayoutPanel flowLayoutPanelCategoriesSubMenu;
    public Button categoriesSubMenuButton1;
    public Button categoriesSubMenuButton2;
    public Button categoriesSubMenuButton3;
    public Button categoriesSubMenuButton4;
    public Button aboutButton;
    public PictureBox pictureBoxLogo;
    public Panel panelLogo;
}