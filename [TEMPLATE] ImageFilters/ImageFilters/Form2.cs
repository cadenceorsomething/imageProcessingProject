using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageFilters
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            numericUpDown1.Minimum = 3;
            numericUpDown1.Value = 3;
            numericUpDown1.Increment = 2;
            this.AcceptButton = button1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }


        public int WindowSize
        {
            get { return (int)numericUpDown1.Value; }
        }


        public bool UseEfficientAlgorithm
        {
            get { return radioButton1.Checked; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
