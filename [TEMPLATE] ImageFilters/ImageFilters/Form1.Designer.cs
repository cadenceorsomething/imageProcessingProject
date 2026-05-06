namespace ImageFilters
{
    partial class Form1
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
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.MedianBtn = new System.Windows.Forms.Button();
            this.MidpointBtn = new System.Windows.Forms.Button();
            this.BilateralBtn = new System.Windows.Forms.Button();
            this.ElabsedTimeLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Location = new System.Drawing.Point(16, 15);
            this.pictureBoxRight.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(607, 542);
            this.pictureBoxRight.TabIndex = 0;
            this.pictureBoxRight.TabStop = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Location = new System.Drawing.Point(671, 15);
            this.pictureBoxLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(607, 542);
            this.pictureBoxLeft.TabIndex = 1;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(16, 565);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(163, 33);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // MedianBtn
            // 
            this.MedianBtn.Location = new System.Drawing.Point(671, 565);
            this.MedianBtn.Margin = new System.Windows.Forms.Padding(4);
            this.MedianBtn.Name = "MedianBtn";
            this.MedianBtn.Size = new System.Drawing.Size(163, 33);
            this.MedianBtn.TabIndex = 3;
            this.MedianBtn.Text = "Median Filter";
            this.MedianBtn.UseVisualStyleBackColor = true;
            this.MedianBtn.Click += new System.EventHandler(this.median_Click);
            // 
            // MidpointBtn
            // 
            this.MidpointBtn.Location = new System.Drawing.Point(842, 565);
            this.MidpointBtn.Margin = new System.Windows.Forms.Padding(4);
            this.MidpointBtn.Name = "MidpointBtn";
            this.MidpointBtn.Size = new System.Drawing.Size(163, 33);
            this.MidpointBtn.TabIndex = 4;
            this.MidpointBtn.Text = "Midpoint Filter";
            this.MidpointBtn.UseVisualStyleBackColor = true;
            this.MidpointBtn.Click += new System.EventHandler(this.midpoint_Click);
            // 
            // BilateralBtn
            // 
            this.BilateralBtn.Location = new System.Drawing.Point(1013, 564);
            this.BilateralBtn.Margin = new System.Windows.Forms.Padding(4);
            this.BilateralBtn.Name = "BilateralBtn";
            this.BilateralBtn.Size = new System.Drawing.Size(163, 33);
            this.BilateralBtn.TabIndex = 5;
            this.BilateralBtn.Text = "Bilateral Filter";
            this.BilateralBtn.UseVisualStyleBackColor = true;
            this.BilateralBtn.Click += new System.EventHandler(this.bilateral_Click);
            // 
            // ElabsedTimeLabel
            // 
            this.ElabsedTimeLabel.AutoSize = true;
            this.ElabsedTimeLabel.Location = new System.Drawing.Point(13, 624);
            this.ElabsedTimeLabel.Name = "ElabsedTimeLabel";
            this.ElabsedTimeLabel.Size = new System.Drawing.Size(94, 16);
            this.ElabsedTimeLabel.TabIndex = 6;
            this.ElabsedTimeLabel.Text = "Time elapsed:";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AccessibleName = "timeLabel";
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(113, 624);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(31, 16);
            this.TimeLabel.TabIndex = 7;
            this.TimeLabel.Text = "0.0s";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 649);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ElabsedTimeLabel);
            this.Controls.Add(this.BilateralBtn);
            this.Controls.Add(this.MidpointBtn);
            this.Controls.Add(this.MedianBtn);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.pictureBoxRight);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Image Filters...";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button MedianBtn;
        private System.Windows.Forms.Button MidpointBtn;
        private System.Windows.Forms.Button BilateralBtn;
        private System.Windows.Forms.Label ElabsedTimeLabel;
        private System.Windows.Forms.Label TimeLabel;
    }
}

