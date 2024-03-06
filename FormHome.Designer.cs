using System;
using System.Drawing;
namespace Lecture;

partial class FormHome
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
        mainPanel = new Panel();

        mainPanel.BackColor = Color.FromArgb(255, 230, 230, 230);
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.AutoScroll = true;

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(mainPanel);
    }

    #endregion
    public Panel mainPanel;
    public System.Windows.Forms.Timer carouselSlideTimer;
}
