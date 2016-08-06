using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jodel
{
    public partial class frmInfo : Form
    {
        public string lng = "";
        public string lat = "";
        public int votecount = 0;

        public frmInfo()
        {
            InitializeComponent();
        }

        private void lblLongitude_Click(object sender, EventArgs e)
        {

        }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            lblVoteCount.Text = votecount.ToString();
            lblLongitude.Text = lng;
            lblLatitude.Text = lat;
        }
    }
}
