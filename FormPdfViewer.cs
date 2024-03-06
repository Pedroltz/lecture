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
namespace Lecture
{
    public partial class FormPdfViewer : Form
    {
        private PdfViewer pdfViewer;
        private WebClient webClient;

        public FormPdfViewer(string pdf)
        {
            InitializeComponent();
            this.Load += new EventHandler(FormPdfViewerLoad);
            this.FormClosing += new FormClosingEventHandler(FormPdfViewerFormClosing);

            // Initialize your PdfViewer control
            pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            pdfViewer.Tag = pdf;
            pdfViewer.ShowBookmarks = false;
            this.WindowState = FormWindowState.Maximized;

            // Add the PdfViewer control to your form
            this.Controls.Add(pdfViewer);
        }

        private void LoadPdfFromUrl(string pdfUrl)
        {
            try
            {
                webClient = new WebClient();
                webClient.DownloadFile("https://viikdev.github.io/booksApi/"+pdfUrl, "downloadedFile.pdf");
                using (FileStream fileStream = new FileStream("downloadedFile.pdf", FileMode.Open, FileAccess.Read))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Position = 0; // Reset the memory stream position

                    pdfViewer.Document = PdfDocument.Load(memoryStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Desculpe, este título não pode ser lido no momento!");
                this.Close();
            }
            finally
            {
                if (webClient != null)
                {
                    webClient.Dispose();
                }
            }
        }

        private void FormPdfViewerLoad(object sender, EventArgs e) {
            // Call the method to load PDF from URL
            LoadPdfFromUrl(pdfViewer.Tag.ToString());
        }

        private void FormPdfViewerFormClosing(object sender, FormClosingEventArgs e) {
            if (pdfViewer != null) {
                pdfViewer.Dispose();
                pdfViewer = null;
            }
        }
    }
}
