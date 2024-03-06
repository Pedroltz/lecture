using System;
using System.Windows.Forms;
using Lecture.Classes;
namespace Lecture
{
    public partial class FormSearchResults : Form
    {
        private List<BookBase> booksData;
        public FormSearchResults(List<BookBase> data)
        {
            InitializeComponent();
            this.Load += FormSearchResultsLoad;
            this.Resize += FormSearchResultsResize;
            booksData = data;
        }
        private void FormSearchResultsLoad(object sender, EventArgs e) {
            mainLabel.Text = $"Resultados ({booksData.Count}):";
            ShowResults();
            CenterElements();
        }
        private void FormSearchResultsResize(object sender, EventArgs e) {
            CenterElements();
        }
        private void CenterElements()
        {
            int elementDistance = (panelResultsDetails.Height - mainLabel.Height)/2;
            mainLabel.Location = new Point(elementDistance, elementDistance);
        }

        private int j = 0;
        private int k = 0;

        private void ShowResults() {
            for (int i = 0; i < booksData.Count; i++) {
                int kOldVal = k;
                BookBase book = booksData[i];
                FlowLayoutPanel flowLayoutPanel = new();

                flowLayoutPanel.Dock = DockStyle.Fill;
                flowLayoutPanel.AutoSize = true;

                CreateBook(j, k, book);
                if (!(kOldVal != k)) {
                    j++;
                }
            }
        }
        private async void CreateBook(int row, int column, BookBase book)
        {
            Button btn = new();
            Label title = new();

            // btn.BackgroundImage = Image.FromFile(@"Resources/book-cape-1.png);
            btn.BackColor = Color.FromArgb(255, 245, 245, 255);
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Cursor = Cursors.Hand;
            btn.Location = new Point(row * 200 + mainLabel.Location.X, column * 260 + 75);
            btn.Size = new Size(180, 250);
            btn.UseVisualStyleBackColor = true;
            btn.Tag = book.PdfLink;
            btn.Click += new EventHandler(BtnPdfClick);
            btn.UseVisualStyleBackColor = true;

            if (book.Title.Length > 20)
            {
                // Truncate the text and append "..."
                title.Text = book.Title.Substring(0, 17) + "...";
            }
            else
            {
                title.Text = book.Title;
            }

            int checkNextBookWidth = btn.Location.X + btn.Width + 200 + mainLabel.Location.X;

            if (checkNextBookWidth > this.ClientSize.Width) {
                j = 0;
                k += 1;
            }

            title.Size = new Size(160, 33);
            title.AutoSize = false;
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Location = new Point(10, 110);
            title.BackColor = Color.FromArgb(125, 255, 255, 255);

            btn.Controls.Add(title);
            panelResultsContent.Controls.Add(btn);

            await LoadImageAsync(btn, @"Resources/book-cape-1.png");
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

        private void BtnPdfClick(object sender, EventArgs e)
        {
            if (sender is Button clickedButton) {
                FormPdfViewer PdfViewer = new(clickedButton.Tag.ToString());
                PdfViewer.Show();
            }
        }
    }
}