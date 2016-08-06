namespace Jodel
{
    partial class frmInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblVoteCountL = new System.Windows.Forms.Label();
            this.lblLatitudeR = new System.Windows.Forms.Label();
            this.lblVoteCount = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitudeL = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVoteCountL
            // 
            this.lblVoteCountL.AutoSize = true;
            this.lblVoteCountL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoteCountL.Location = new System.Drawing.Point(12, 9);
            this.lblVoteCountL.Name = "lblVoteCountL";
            this.lblVoteCountL.Size = new System.Drawing.Size(87, 20);
            this.lblVoteCountL.TabIndex = 0;
            this.lblVoteCountL.Text = "Votecount:";
            // 
            // lblLatitudeR
            // 
            this.lblLatitudeR.AutoSize = true;
            this.lblLatitudeR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitudeR.Location = new System.Drawing.Point(28, 39);
            this.lblLatitudeR.Name = "lblLatitudeR";
            this.lblLatitudeR.Size = new System.Drawing.Size(71, 20);
            this.lblLatitudeR.TabIndex = 1;
            this.lblLatitudeR.Text = "Latitude:";
            // 
            // lblVoteCount
            // 
            this.lblVoteCount.AutoSize = true;
            this.lblVoteCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoteCount.Location = new System.Drawing.Point(105, 9);
            this.lblVoteCount.Name = "lblVoteCount";
            this.lblVoteCount.Size = new System.Drawing.Size(18, 20);
            this.lblVoteCount.TabIndex = 2;
            this.lblVoteCount.Text = "0";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(105, 39);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(18, 20);
            this.lblLatitude.TabIndex = 3;
            this.lblLatitude.Text = "0";
            // 
            // lblLongitudeL
            // 
            this.lblLongitudeL.AutoSize = true;
            this.lblLongitudeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitudeL.Location = new System.Drawing.Point(12, 69);
            this.lblLongitudeL.Name = "lblLongitudeL";
            this.lblLongitudeL.Size = new System.Drawing.Size(84, 20);
            this.lblLongitudeL.TabIndex = 4;
            this.lblLongitudeL.Text = "Longitude:";
            this.lblLongitudeL.Click += new System.EventHandler(this.lblLongitude_Click);
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(105, 69);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(18, 20);
            this.lblLongitude.TabIndex = 5;
            this.lblLongitude.Text = "0";
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 110);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblLongitudeL);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.lblVoteCount);
            this.Controls.Add(this.lblLatitudeR);
            this.Controls.Add(this.lblVoteCountL);
            this.Name = "frmInfo";
            this.Text = "frmInfo";
            this.Load += new System.EventHandler(this.frmInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVoteCountL;
        private System.Windows.Forms.Label lblLatitudeR;
        private System.Windows.Forms.Label lblVoteCount;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitudeL;
        private System.Windows.Forms.Label lblLongitude;
    }
}