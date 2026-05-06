using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ImageFilters
{
    public partial class MedianWindow : Form
    {
        public MedianWindow()
        {
            InitializeComponent();
            comboBox.Items.Add("Quick Sort");
            comboBox.Items.Add("Counting Sort");
            comboBox.Items.Add("Select K-th Element");
            comboBox.Items.Add("Hybrid");
            comboBox.SelectedIndex = 0;

            numWindowSize.Minimum = 3;
            numWindowSize.Increment = 2;
        }

        public string SelectedMethod;
        public int windowSize;
        public int K;

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string method = comboBox.SelectedItem.ToString();

            numWindowSize.Enabled = true; // always ON

            if (method == "Select K-th Element")
            {
                numK_index.Enabled = true;
            }
            else
            {
                numK_index.Enabled = false;
            }

        }


        private void okbutton1_Click(object sender, EventArgs e)
        {

            SelectedMethod = comboBox.SelectedItem.ToString();

            windowSize = (int)numWindowSize.Value;

            if (SelectedMethod == "Select K-th Element")
            {
                K = (int)numK_index.Value;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}