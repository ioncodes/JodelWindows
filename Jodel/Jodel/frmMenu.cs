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

namespace Jodel
{
    public partial class frmMenu : Form
    {
        List<Tuple<string, string, string, bool, int, string, string, Tuple<string>>> jodels = new List<Tuple<string, string, string, bool, int, string, string, Tuple<string>>>();
        private static string lng = "";
        private static string lat = "";
        private static int votecount = 0;

        public frmMenu()
        {
            InitializeComponent();
            API.accessToken = "d87efc34-22d2-4a2f-9a6c-ac086b10f308";
            API.latitude = "47.48138427471329";
            API.longitude = "8.30048079354216";
            API.countryCode = "CH";
            API.city = "Miami";
            jodels = API.GetAllJodels();

            Point location = new Point(0, 0);
            ColorConverter cc = new ColorConverter();

            //foreach (var item in temp)
            //{
            //    Panel pan = new Panel();
            //    pan.AutoSize = false;
            //    pan.Width = this.Width-75;
            //    pan.Location = location;
            //    pan.BackColor = (Color)cc.ConvertFromString("#" + item.Item3);
            //    Label lbl = new Label();
            //    lbl.Font = new Font("Arial", 12);
            //    lbl.ForeColor = Color.White;
            //    lbl.Text = item.Item2;
            //    lbl.AutoSize = true;
            //    lbl.MaximumSize = new Size(pan.Width - 5, 0);
            //    lbl.Width = pan.Width - 10;
            //    lbl.Location = new Point(lbl.Location.X + 5, lbl.Location.Y + 5);
            //    pan.Controls.Add(lbl);
            //    flowLayoutPanel1.Controls.Add(pan);
            //    location = new Point(location.X - pan.Height, location.Y);
            //}

            foreach (var item in jodels)
            {
                Panel pan = new Panel();
                pan.Padding = new Padding(5);
                pan.AutoSize = true;
                pan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                pan.BackColor = (Color)cc.ConvertFromString("#" + item.Item3);
                Label lbl = new Label();
                lbl.Dock = DockStyle.Fill;
                lbl.Font = new Font("Arial", 12);
                lbl.ForeColor = Color.White;
                lbl.Text = item.Item2;
                lbl.AutoSize = true;
                lbl.Name = "a" + item.Item1 + "a";
                pan.MinimumSize = new Size(this.Width - 75, 0);
                pan.MaximumSize = new Size(this.Width - 75, 0);
                lbl.MaximumSize = new Size(pan.Width - 50, 0);
                pan.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(pan);
                location = new Point(location.X - pan.Height, location.Y);

                lbl.MouseClick += (s, e) => // event handler to trigger jodel clicks
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            // Left click
                            {
                                //nothing, maybe later
                            }
                            break;

                        case MouseButtons.Right:
                            // Right click
                            {
                                cmsJodelRightClick.Show(Cursor.Position);
                                string postID = lbl.Name;
                                postID = postID.Remove(0); //error
                                postID = postID.Remove(postID.Length-1);
                                SetInfos(postID);
                            }
                            break;
                    }
                };
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void infosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInfo frmi = new frmInfo();
            frmi.lng = lng;
            frmi.lat = lat;
            frmi.votecount = votecount;
            frmi.Show();
        }

        private void SetInfos(string postID)
        {
            foreach (var lst in jodels)
            {
                if (lst.Item1 == postID)
                {
                    votecount = lst.Item5;
                    lat = lst.Item6;
                    lng = lst.Rest.Item1;
                    break;
                }
            }
        }
    }
}
