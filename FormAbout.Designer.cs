namespace Lecture
{
    partial class FormAbout
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
            mainPanel = new Panel();
            panelPictureBoxBottom = new Panel();
            pictureBoxBottom1 = new PictureBox();
            pictureBoxBottom2 = new PictureBox();
            panelWrapper = new Panel();
            panelTop = new Panel();
            labelTop = new Label();
            panelWrapperPictureBoxes = new Panel();
            Label labelProfessor = new Label();
            Label labelStudents = new Label();
            Label labelProfessorName = new Label();
            Label labelStudentsName1 = new Label();
            Label labelStudentsName2 = new Label();
            Label labelStudentsName3 = new Label();
            Label labelStudentsName4 = new Label();
            Label labelStudentsName5 = new Label();

            mainPanel.BackColor = Color.FromArgb(255, 240, 240, 240);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AutoScroll = true;
            mainPanel.Controls.Add(panelTop);
            mainPanel.Controls.Add(panelWrapper);
            mainPanel.Controls.Add(panelPictureBoxBottom);

            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 100;
            panelTop.Controls.Add(labelTop);

            labelTop.Text = "Créditos";
            labelTop.Font = new Font("Segoe UI Semibold", 18.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelTop.AutoSize = true;

            panelPictureBoxBottom.Dock = DockStyle.Bottom;
            panelPictureBoxBottom.Margin = new Padding(0);
            panelPictureBoxBottom.Padding = new Padding(5);
            panelPictureBoxBottom.Height = 150;
            panelPictureBoxBottom.Controls.Add(panelWrapperPictureBoxes);

            panelWrapperPictureBoxes.AutoSize = true;
            panelWrapperPictureBoxes.Height = 80;
            panelWrapperPictureBoxes.Controls.Add(pictureBoxBottom1);
            panelWrapperPictureBoxes.Controls.Add(pictureBoxBottom2);
            // panelWrapperPictureBoxes.BackColor = Color.FromArgb(255,210,0,0);

            Image originalImage = Image.FromFile(@"Resources/unisagrado-logo.png");
            Image originalImage2 = Image.FromFile(@"Resources/monolitica-pastoral-nova.png");

            // Calculate the width proportionally based on the original aspect ratio
            // int targetHeight = 120;
            // int targetWidth = (int)(originalImage.Width * ((float)targetHeight / originalImage.Height));
            int targetWidth = 300;
            int targetHeight = (int)(originalImage.Height * ((float)targetWidth / originalImage.Width));

            // Create a new bitmap with the calculated width and the target height
            Bitmap resizedImage = new Bitmap(targetWidth, targetHeight);
            Bitmap resizedImage2 = new Bitmap(targetWidth, targetHeight);

            // Use Graphics to draw the original image onto the resized bitmap
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);
            }
            using (Graphics g = Graphics.FromImage(resizedImage2))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage2, 0, 0, targetWidth, targetHeight);
            }

            pictureBoxBottom1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxBottom1.Image = resizedImage;
            pictureBoxBottom1.Dock = DockStyle.Left;

            pictureBoxBottom2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxBottom2.Image = resizedImage2;
            pictureBoxBottom2.Dock = DockStyle.Right;

            panelWrapper.Dock = DockStyle.Fill;
            panelWrapper.Controls.Add(labelProfessor);
            panelWrapper.Controls.Add(labelProfessorName);
            panelWrapper.Controls.Add(labelStudents);
            panelWrapper.Controls.Add(labelStudentsName1);
            panelWrapper.Controls.Add(labelStudentsName2);
            panelWrapper.Controls.Add(labelStudentsName3);
            panelWrapper.Controls.Add(labelStudentsName4);
            panelWrapper.Controls.Add(labelStudentsName5);
            panelWrapper.Margin = new Padding(0);

            labelProfessor.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelProfessor.Text = "Projeto Extencionista de Programação de Computadores";
            labelProfessor.AutoSize = true;
            labelProfessor.Location = new Point(0,150);

            labelStudents.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelStudents.Text = "Integrantes do Grupo Lecture";
            labelStudents.AutoSize = true;
            labelStudents.Location = new Point(0,225);

            labelProfessorName.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelProfessorName.Text = "Prof. Dr. Elvio Gilberto";
            labelProfessorName.AutoSize = true;
            labelProfessorName.Location = new Point(0,175);

            labelStudentsName1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelStudentsName1.Text = "Gustavo Rodrighero Ferreira";
            labelStudentsName1.AutoSize = true;
            labelStudentsName1.Location = new Point(0,250);

            labelStudentsName2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelStudentsName2.Text = "João Matheus Veríssimo Francisco";
            labelStudentsName2.AutoSize = true;
            labelStudentsName2.Location = new Point(0,275);

            labelStudentsName3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelStudentsName3.Text = "Natan Coelho de Medeiros";
            labelStudentsName3.AutoSize = true;
            labelStudentsName3.Location = new Point(0,300);

            labelStudentsName4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelStudentsName4.Text = "Pedro Luiz Tunin";
            labelStudentsName4.AutoSize = true;
            labelStudentsName4.Location = new Point(0,325);

            labelStudentsName5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelStudentsName5.Text = "Viktor Bonazza Charlanti";
            labelStudentsName5.AutoSize = true;
            labelStudentsName5.Location = new Point(0,350);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(mainPanel);
        }

        #endregion
        private Panel mainPanel;
        private PictureBox pictureBoxBottom1;
        private PictureBox pictureBoxBottom2;
        private Panel panelPictureBoxBottom;
        private Panel panelWrapper;
        private Panel panelTop;
        private Label labelTop;
        private Panel panelWrapperPictureBoxes;
    }
}