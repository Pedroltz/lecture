using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lecture.Classes;
using System.Diagnostics;
using PdfiumViewer;
using System.Net;
using System.Windows.Forms;
using System.Net.Http;
namespace Lecture;

public partial class FormHome : Form
{
    private BooksData booksData;
    public FormHome(BooksData data)
    {
        InitializeComponent();
        this.Load += FormHomeLoad;
        this.Resize += FormHomeResize;
        booksData = data;
    }

    private void FormHomeLoad(object? sender, EventArgs e)
    {
        CreateCarousels();
        CenterElements();
    }

    private void FormHomeResize(object? sender, EventArgs e)
    {
        CenterElements();
    }

    private void CenterElements()
    {
        // button.Location = new Point((mainPanel.Width-button.Width)/2,(mainPanel.Height-button.Height)/2);
        var cContainers = mainPanel.Controls.OfType<Control>().Where(c => c.Tag != null && c.Tag.ToString() == "cContainer").ToList();
        foreach (Control control in cContainers)
        {
            control.Size = new Size((int)(mainPanel.Width * .9), 350);
            control.Location = new Point((mainPanel.Width - control.Width) / 2, control.Location.Y);
            var cCarousel = control.Controls.OfType<Control>().Where(c => c.Tag != null && (string)c.Tag == "cCarousel").ToList()[0];
            cCarousel.Size = new Size((int)(control.Width * .9), 280);
            cCarousel.Location = new Point((control.Width - cCarousel.Width) / 2, cCarousel.Location.Y);
            var cCarouselControllers = control.Controls.OfType<Control>().Where(c => c.Tag != null && (string)c.Tag == "cCarouselControllers").ToList()[0];
            cCarouselControllers.Size = new Size(cCarousel.Width + 80,30);
            cCarouselControllers.Location = new Point((control.Width - cCarouselControllers.Width) / 2, (control.Height - cCarousel.Height/2) - cCarouselControllers.Height);
            var cBtnPrev = cCarouselControllers.Controls.OfType<Control>().Where(c => c.Tag != null && (string)c.Tag == "cBtnPrev").ToList()[0];
            var cBtnNext = cCarouselControllers.Controls.OfType<Control>().Where(c => c.Tag != null && (string)c.Tag == "cBtnNext").ToList()[0];
            int controllerSpace = (int)((cCarouselControllers.Width - cCarousel.Width)/2);
            cBtnPrev.Size = new Size(30,30);
            cBtnNext.Size = new Size(30,30);
        }
    }
    private void CreateCarousels()
    {
        if (booksData.data.Count > 0)
        {
            string[] categories = new string[] { };
            categories = RandomCategories(3);
            for (int i = 0; i < categories.Length; i++)
            {
                Panel container = new Panel();
                container.Size = new Size((int)(this.Width * .9), 350);
                container.Location = new Point(0, i * 360);
                container.Tag = "cContainer";

                Label category = new Label();
                category.AutoSize = true;
                category.Text = categories[i];
                category.Location = new Point(10, 15);
                category.Tag = "cCategory";
                category.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular, GraphicsUnit.Point);

                Panel carousel = new Panel();
                carousel.Size = new Size((int)(container.Width * .9), 280);
                carousel.Location = new Point((container.Width - carousel.Width) / 2, container.Height - carousel.Height);
                carousel.Tag = "cCarousel";
                carousel.AutoScroll = true;
                carousel.VerticalScroll.Visible = false;
                carousel.VerticalScroll.Enabled = false;

                Panel carouselControllers = new Panel();
                carouselControllers.Size = new Size(container.Width, 30);
                carouselControllers.Location = new Point(0, container.Height - carousel.Height/2);
                carouselControllers.Tag = "cCarouselControllers";
                carouselControllers.Margin = new Padding(0);
                int controllerSpace = (int)((carouselControllers.Width - carousel.Width)/2);

                Button btnPrev = new Button();
                btnPrev.Size = new Size(controllerSpace,30);
                btnPrev.Text = "<";
                btnPrev.FlatStyle = FlatStyle.Flat;
                btnPrev.Tag = "cBtnPrev";
                btnPrev.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
                btnPrev.Dock = DockStyle.Left;
                btnPrev.FlatAppearance.BorderSize = 0;
                btnPrev.Click += CarouselBtnPrevClick;

                Button btnNext = new Button();
                btnNext.Size = new Size(controllerSpace,30);
                btnNext.Text = ">";
                btnNext.FlatStyle = FlatStyle.Flat;
                btnNext.Tag = "cBtnNext";
                btnNext.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
                btnNext.Dock = DockStyle.Right;
                btnNext.FlatAppearance.BorderSize = 0;
                btnNext.Click += CarouselBtnNextClick;

                BookBase[] randomBooks = RandomBooks(12, booksData.data);
                for (int j = 0; j < 12; j++)
                {
                    // Code to populate carousel with book information
                    // Assuming 'PopulateCarousel' method adds book information
                    PopulateCarousel(j, carousel, randomBooks[j]);
                }

                carouselControllers.Controls.Add(btnPrev);
                carouselControllers.Controls.Add(btnNext);
                container.Controls.Add(category);
                container.Controls.Add(carousel);
                container.Controls.Add(carouselControllers);
                mainPanel.Controls.Add(container);
            }
        }
    }
    private string[] RandomCategories(int qntd)
    {
        List<string> carouselCategories = new List<string>() { "Populares", "Adicionados Recentemente", "Vistos para Enem", "Clássicos", "Romances", "Cultos" };
        if (qntd <= 0 || qntd > carouselCategories.Count)
        {
            throw new ArgumentException("Invalid count parameter");
        }

        Random random = new Random();

        // Shuffle the list of categories
        List<string> shuffledCategories = carouselCategories.OrderBy(x => random.Next()).ToList();

        // Take the first 'count' categories from the shuffled list
        string[] selectedCategories = shuffledCategories.Take(qntd).ToArray();

        return selectedCategories;
    }
    private BookBase[] RandomBooks(int qntd, List<BookBase> books)
    {
        if (qntd <= 0 || qntd > books.Count)
        {
            throw new ArgumentException("Invalid count parameter");
        }

        Random random = new Random();

        // Shuffle the list of categories
        List<BookBase> shuffledBooks = books.OrderBy(x => random.Next()).ToList();

        // Take the first 'count' categories from the shuffled list
        BookBase[] selectedBooks = shuffledBooks.Take(qntd).ToArray();

        return selectedBooks;
    }
    private async void PopulateCarousel(int row, Control carousel, BookBase book)
    {
        Button btn = new();
        Label title = new();

        // btn.BackgroundImage = Image.FromFile(@"Resources/book-cape-1.png");
        btn.BackColor = Color.FromArgb(255, 245, 245, 255);
        btn.BackgroundImageLayout = ImageLayout.Stretch;
        btn.Cursor = Cursors.Hand;
        btn.Location = new Point(row * 190, 0);
        btn.Size = new Size(180, 250);
        btn.UseVisualStyleBackColor = true;
        btn.Tag = book.PdfLink;
        btn.Click += new EventHandler(BtnPdfClick);

        if (book.Title.Length > 20)
        {
            // Truncate the text and append "..."
            title.Text = book.Title.Substring(0, 17) + "...";
        }
        else
        {
            title.Text = book.Title;
        }

        title.Size = new Size(160, 33);
        title.AutoSize = false;
        title.TextAlign = ContentAlignment.MiddleCenter;
        title.Location = new Point(10, 110);
        title.BackColor = Color.FromArgb(125, 255, 255, 255);

        btn.Controls.Add(title);
        carousel.Controls.Add(btn);

        await LoadImageAsync(btn, @"Resources/book-cape-1.png");
    }
    private void BtnPdfClick(object sender, EventArgs e)
    {
        if (sender is Button clickedButton) {
            FormPdfViewer PdfViewer = new(clickedButton.Tag.ToString());
            PdfViewer.Show();
        }
    }
    private void CarouselBtnPrevClick(object sender, EventArgs e) {
        Control container = ((Button)sender).Parent.Parent;
        var cCarousel = container.Controls.OfType<Control>().FirstOrDefault(c => c.Tag != null && (string)c.Tag == "cCarousel") as Panel;
        int cCarouselMaxScroll = cCarousel.HorizontalScroll.Maximum - cCarousel.Width + 1;

        if (cCarousel != null) {
            int scrollValue = Math.Max(cCarousel.HorizontalScroll.Minimum, Math.Min(cCarouselMaxScroll, cCarousel.HorizontalScroll.Value - 100));
            test(cCarousel, scrollValue);
        }
    }

    private void CarouselBtnNextClick(object sender, EventArgs e) {
        Control container = ((Button)sender).Parent.Parent;
        var cCarousel = container.Controls.OfType<Control>().FirstOrDefault(c => c.Tag != null && (string)c.Tag == "cCarousel") as Panel;
        int cCarouselMaxScroll = cCarousel.HorizontalScroll.Maximum - cCarousel.Width + 1;

        if (cCarousel != null) {
            int scrollValue = Math.Max(cCarousel.HorizontalScroll.Minimum, Math.Min(cCarouselMaxScroll, cCarousel.HorizontalScroll.Value + 100));
            test(cCarousel, scrollValue);
        }
    }

    private System.Windows.Forms.Timer scrollTicker;

    private void test(Panel carousel, int scrollValue) {
        if (scrollTicker == null || !scrollTicker.Enabled) {
            scrollTicker?.Stop();
            scrollTicker?.Dispose();

            scrollTicker = new System.Windows.Forms.Timer();
            scrollTicker.Interval = 20;
            scrollTicker.Tick += (sender, e) => handletest(carousel, scrollValue);
            scrollTicker.Start();
        }
    }

    private void handletest(Panel carousel, int scrollValue) {
        if (carousel.HorizontalScroll.Value < scrollValue) {
            carousel.HorizontalScroll.Value = Math.Min(scrollValue,carousel.HorizontalScroll.Value + 10);
        } else if (carousel.HorizontalScroll.Value > scrollValue) {
            carousel.HorizontalScroll.Value = Math.Max(scrollValue,carousel.HorizontalScroll.Value - 10);
        }
        carousel.PerformLayout();

        if (carousel.HorizontalScroll.Value >= carousel.HorizontalScroll.Maximum || carousel.HorizontalScroll.Value <= carousel.HorizontalScroll.Minimum || carousel.HorizontalScroll.Value == scrollValue) {
            scrollTicker.Stop();
            scrollTicker.Dispose();
            scrollTicker = null;
        }
    }

    private async Task LoadImageAsync(Button button, string imagePath)
        {
            try
            {
                // Use Task.Run to load the image in a separate thread
                var image = await Task.Run(() => Image.FromFile(imagePath));

                // Check if the button still exists (it might have been removed from the UI)
                if (button.IsHandleCreated)
                {
                    // Set the background image on the UI thread
                    button.Invoke((MethodInvoker)delegate
                    {
                        button.BackgroundImage = image;
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during image loading
                Console.WriteLine($"Error loading image: {ex.Message}");
            }
        }
}
