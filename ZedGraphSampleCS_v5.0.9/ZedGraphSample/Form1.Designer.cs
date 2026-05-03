namespace ZedGraphSample
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
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.zg1 = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zg1
			// 
			this.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left;
			this.zg1.Location = new System.Drawing.Point(16, 15);
			this.zg1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.zg1.Name = "zg1";
			this.zg1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
			this.zg1.ScrollGrace = 0D;
			this.zg1.ScrollMaxX = 0D;
			this.zg1.ScrollMaxY = 0D;
			this.zg1.ScrollMaxY2 = 0D;
			this.zg1.ScrollMinX = 0D;
			this.zg1.ScrollMinY = 0D;
			this.zg1.ScrollMinY2 = 0D;
			this.zg1.Size = new System.Drawing.Size(585, 366);
			this.zg1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(617, 395);
			this.Controls.Add(this.zg1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private ZedGraph.ZedGraphControl zg1;
	}
}

