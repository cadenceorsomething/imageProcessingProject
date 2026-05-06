namespace ImageFilters
{
    partial class MedianWindow
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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.okbutton1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numWindowSize = new System.Windows.Forms.NumericUpDown();
            this.numK_index = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numK_index)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(125, 58);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 24);
            this.comboBox.TabIndex = 0;
            this.comboBox.Text = "Choose method...";
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // okbutton1
            // 
            this.okbutton1.Location = new System.Drawing.Point(38, 229);
            this.okbutton1.Name = "okbutton1";
            this.okbutton1.Size = new System.Drawing.Size(126, 32);
            this.okbutton1.TabIndex = 1;
            this.okbutton1.Text = "Ok";
            this.okbutton1.UseVisualStyleBackColor = true;
            this.okbutton1.Click += new System.EventHandler(this.okbutton1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(209, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numWindowSize.Location = new System.Drawing.Point(44, 132);
            this.numWindowSize.Name = "numericUpDown1";
            this.numWindowSize.Size = new System.Drawing.Size(120, 22);
            this.numWindowSize.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            this.numK_index.Location = new System.Drawing.Point(209, 132);
            this.numK_index.Name = "numericUpDown2";
            this.numK_index.Size = new System.Drawing.Size(120, 22);
            this.numK_index.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Window Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "K index";
            // 
            // MedianWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 273);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numK_index);
            this.Controls.Add(this.numWindowSize);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okbutton1);
            this.Controls.Add(this.comboBox);
            this.Name = "MedianWindow";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numK_index)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button okbutton1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numWindowSize;
        private System.Windows.Forms.NumericUpDown numK_index;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}