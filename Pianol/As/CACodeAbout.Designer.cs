namespace PinaoUI.As {
    partial class CACodeAbout {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CACodeAbout));
            this.authorLB = new System.Windows.Forms.Label();
            this.EXEName = new System.Windows.Forms.Label();
            this.emailLB = new System.Windows.Forms.Label();
            this.IconPic = new System.Windows.Forms.PictureBox();
            this.source = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IconPic)).BeginInit();
            this.SuspendLayout();
            // 
            // authorLB
            // 
            this.authorLB.AutoSize = true;
            this.authorLB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.authorLB.Location = new System.Drawing.Point(345, 37);
            this.authorLB.Name = "authorLB";
            this.authorLB.Size = new System.Drawing.Size(68, 17);
            this.authorLB.TabIndex = 0;
            this.authorLB.Text = "作者邮箱：";
            // 
            // EXEName
            // 
            this.EXEName.AutoSize = true;
            this.EXEName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXEName.Location = new System.Drawing.Point(127, 54);
            this.EXEName.Name = "EXEName";
            this.EXEName.Size = new System.Drawing.Size(81, 17);
            this.EXEName.TabIndex = 2;
            this.EXEName.Text = "Piano 2.0.1.2";
            // 
            // emailLB
            // 
            this.emailLB.AutoSize = true;
            this.emailLB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emailLB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailLB.ForeColor = System.Drawing.Color.MediumBlue;
            this.emailLB.Location = new System.Drawing.Point(345, 54);
            this.emailLB.Name = "emailLB";
            this.emailLB.Size = new System.Drawing.Size(134, 17);
            this.emailLB.TabIndex = 3;
            this.emailLB.Text = "2075383131@qq.com";
            this.emailLB.Click += new System.EventHandler(this.emailLB_Click);
            // 
            // IconPic
            // 
            this.IconPic.Location = new System.Drawing.Point(239, 37);
            this.IconPic.Name = "IconPic";
            this.IconPic.Size = new System.Drawing.Size(100, 50);
            this.IconPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconPic.TabIndex = 1;
            this.IconPic.TabStop = false;
            // 
            // source
            // 
            this.source.AutoSize = true;
            this.source.Cursor = System.Windows.Forms.Cursors.Hand;
            this.source.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.source.ForeColor = System.Drawing.Color.Teal;
            this.source.Location = new System.Drawing.Point(9, 468);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(155, 17);
            this.source.TabIndex = 6;
            this.source.Text = "项目开源Github:cctvadmin";
            this.source.Click += new System.EventHandler(this.source_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(420, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "官网:http://www.adminznh.ren/";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CACodeAbout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(615, 489);
            this.Controls.Add(this.emailLB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.source);
            this.Controls.Add(this.EXEName);
            this.Controls.Add(this.IconPic);
            this.Controls.Add(this.authorLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CACodeAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IconPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label authorLB;
        private System.Windows.Forms.PictureBox IconPic;
        private System.Windows.Forms.Label EXEName;
        private System.Windows.Forms.Label emailLB;
        private System.Windows.Forms.Label source;
        private System.Windows.Forms.Label label1;
    }
}