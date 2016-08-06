
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class JodelControl : Control
{
    public JodelControl()
    {
        Paint += JodelControl_Paint;
        MouseMove += JodelControl_MouseMove;
        MouseDown += JodelControl_MouseDown;
        this.DoubleBuffered = true;
        BackColor = Color.FromArgb(163, 191, 57);
    }
    public Color TextColor { get; set; }
    public Color VoteColor { get; set; }
    public string Comment { get; set; }
    public int VoteInt { get; set; }
    public string _Location { get; set; }
    public string Duration { get; set; }

    private void JodelControl_MouseDown(object sender, MouseEventArgs e)
    {
        if (new Rectangle(this.Width - 35, (this.Height / 2) - 20, 35, 25).Contains(e.X, e.Y))
        {
            VoteInt += 1;
            this.Refresh();
        }
        if (new Rectangle(this.Width - 35, (this.Height / 2) + 17, 35, 25).Contains(e.X, e.Y))
        {
            VoteInt -= 1;
            this.Refresh();
        }
    }

    private void JodelControl_MouseMove(object sender, MouseEventArgs e)
    {
        if (new Rectangle(this.Width - 35, (this.Height / 2) - 20, 35, 25).Contains(e.X, e.Y) | new Rectangle(this.Width - 35, (this.Height / 2) + 17, 35, 25).Contains(e.X, e.Y))
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.Arrow;
        }
    }

    private void JodelControl_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(BackColor);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.DrawString(Comment, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(TextColor), new Rectangle(8, 8, this.Width - 35, this.Height - 20));
        g.DrawString(VoteInt.ToString(), new Font("Arial", 16, FontStyle.Regular), new SolidBrush(VoteColor), new Rectangle(this.Width - 40, (this.Height / 2) - 3, 40, 20), new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        });
        g.DrawLine(new Pen(VoteColor, 5), new Point(this.Width - 35, (this.Height / 2) - 7), new Point(this.Width - 20, (this.Height / 2) - 20));
        g.DrawLine(new Pen(VoteColor, 5), new Point(this.Width - 22, (this.Height / 2) - 20), new Point(this.Width - 7, (this.Height / 2) - 7));

        g.DrawLine(new Pen(VoteColor, 5), new Point(this.Width - 35, (this.Height / 2) + 17), new Point(this.Width - 20, (this.Height / 2) + 27));
        g.DrawLine(new Pen(VoteColor, 5), new Point(this.Width - 22, (this.Height / 2) + 27), new Point(this.Width - 9, (this.Height / 2) + 17));

        g.DrawString(Duration, new Font("Arial", 8, FontStyle.Regular), new SolidBrush(TextColor), new Rectangle(this.Width - 35, this.Height - 20, 35, 25));
        g.DrawString(_Location, new Font("Arial", 8, FontStyle.Regular), new SolidBrush(TextColor), new Rectangle(25, this.Height - 20, this.Width - 45, 25));
    }
}