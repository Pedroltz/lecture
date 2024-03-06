namespace Lecture
{
    partial class FormSearchResults
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
            panelResultsDetails = new Panel();
            mainLabel = new Label();
            panelResultsContent = new Panel();


            mainPanel.BackColor = Color.FromArgb(255, 230, 230, 230);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AutoScroll = true;
            mainPanel.Controls.Add(panelResultsDetails);
            mainPanel.Controls.Add(panelResultsContent);

            mainLabel.BackColor = Color.Transparent;
            mainLabel.ForeColor = Color.FromArgb(255,0,0,0);
            mainLabel.Margin = new Padding(0);
            mainLabel.Text = "Resultados ():";
            mainLabel.AutoSize = true;
            mainLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);

            panelResultsDetails.Dock = DockStyle.Top;
            panelResultsDetails.BackColor = Color.Transparent;
            panelResultsDetails.Height = 50;
            panelResultsDetails.Controls.Add(mainLabel);

            panelResultsContent.Dock = DockStyle.Fill;
            panelResultsContent.Margin = new Padding(0);
            panelResultsContent.AutoScroll = true;
            panelResultsContent.HorizontalScroll.Enabled = false;
            panelResultsContent.HorizontalScroll.Visible = false;

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(mainPanel);
        }

        #endregion
        private Panel mainPanel;
        private Label mainLabel;
        private Panel panelResultsDetails;
        private Panel panelResultsContent;
    }
}