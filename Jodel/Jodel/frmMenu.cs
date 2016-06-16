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
            API.accessToken = "9e98f945-e9b6-44a7-bcab-c831c190c35c";
            API.latitude = "47.48138427471329";
            API.longitude = "8.30048079354216";
            temp = API.GetAllJodels();
            Color[] itemColor = { Color.Orange, Color.Red, Color.Blue };
            Random rand = new Random();

            Point location = new Point(0, 0);
            
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
