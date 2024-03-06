namespace Lecture
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            this.Load += FormAboutLoad;
            this.Resize += FormAboutResize;
        }

        private void FormAboutLoad(object? sender, EventArgs e)
        {
            CenterElements();
        }

        private void FormAboutResize(object? sender, EventArgs e)
        {
            CenterElements();
        }

        private void CenterElements()
        {
            panelWrapperPictureBoxes.Location = new Point((int)((panelPictureBoxBottom.Width - panelWrapperPictureBoxes.Width) / 2), 0);
            labelTop.Location = new Point((int)((panelTop.Width - labelTop.Width) / 2),(int)((panelTop.Height - labelTop.Height) / 2));
            panelWrapperPictureBoxes.Width = (int)(panelPictureBoxBottom.Width * .9);
            panelWrapperPictureBoxes.Location = new Point((int)(panelPictureBoxBottom.Width * .05), (int)((panelPictureBoxBottom.Height - panelWrapperPictureBoxes.Height) / 2));
            // pictureBoxBottom1.Location = new Point(0, (int)((panelWrapperPictureBoxes.Height - pictureBoxBottom1.Height) / 2));
            // pictureBoxBottom2.Location = new Point(0, (int)((panelWrapperPictureBoxes.Height - pictureBoxBottom2.Height) / 2));
        }
    }
}