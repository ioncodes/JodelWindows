using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JodelAPI;
using System.Drawing;

namespace Jodel
{
    public partial class frmMenu : Form
    {
        List<Tuple<string, string>> temp = new List<Tuple<string, string>>();

        public frmMenu()
        {
            InitializeComponent();
            API.accessToken = "API KEY";
            API.latitude = "LAT";
            API.longitude = "LNG";
            temp = API.GetAllJodels();
            Color[] itemColor = { Color.Orange, Color.Red, Color.Blue };
            Random rand = new Random();

            Point location = new Point(0, 0);
            //int repetition = 0;
            //foreach(var item in temp)
            //{
            //    Label dynamicbutton = new Label();
            //    dynamicbutton.Text = item.Item2;
            //    dynamicbutton.Visible = true;
            //    dynamicbutton.Location = new Point(4 + repetition * 307, 4);
            //    dynamicbutton.Height = 50;
            //    dynamicbutton.Width = flowLayoutPanel1.Width-20;
            //    dynamicbutton.BackColor = Color.FromArgb(40, 40, 40);
            //    dynamicbutton.ForeColor = Color.White;
            //    dynamicbutton.Font = new Font("Lucida Console", 12);
            //    dynamicbutton.Show();
            //    flowLayoutPanel1.Controls.Add(dynamicbutton);
            //    repetition++;
            //}

            foreach(var item in temp)
            {
                Panel pan = new Panel();
                pan.AutoSize = false;
                pan.Width = this.Width;
                pan.Location = location;
                pan.BackColor = itemColor[rand.Next(0, 3)];
                Label lbl = new Label();
                lbl.Font = new Font("Arial", 12);
                lbl.Text = item.Item2;
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(pan.Width - 10, 0);
                lbl.Width = pan.Width - 10;
                pan.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(pan);
                location = new Point(location.X - pan.Height, location.Y);
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            
        }
    }
}
