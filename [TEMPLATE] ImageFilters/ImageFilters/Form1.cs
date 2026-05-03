using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;



namespace ImageFilters
{
    public partial class Form1 : Form
    {
        private Button[] buttonArr;
        public Form1()
        {
            InitializeComponent();

            buttonArr = new Button[] { button1, button2, button3 };

            foreach (var btn in buttonArr)
                btn.Enabled = false;
        }

        byte[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;

                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);

                // enable filters

                foreach (var btn in buttonArr)
                    btn.Enabled = true;
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // i added this to stop an error from recurring
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ImageMatrix == null)
            {
                MessageBox.Show("ImageMatrix is null");
                return;
            }

            timeLabel.Text = "processing...";
            var stopWatch = Stopwatch.StartNew();
            byte[,] medianImage = ImageOperations.MedianFilter(ImageMatrix, 5);
            
            stopWatch.Stop();
            double seconds = stopWatch.Elapsed.TotalSeconds;
            seconds = Math.Round(seconds, 2);
            timeLabel.Text = $"{seconds}s"; 

            ImageOperations.DisplayImage(medianImage, pictureBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ImageMatrix == null)
            {
                MessageBox.Show("ImageMatrix is null");
                return;
            }

            // byte[,] medianImage = ImageOperations.MidPointFilterSlow(ImageMatrix, 7);
            //ImageOperations.DisplayImage(medianImage, pictureBox2);

            using (Form2 options = new Form2() )
            {
                // presses cancel
                if (options.ShowDialog() != DialogResult.OK)
                    return;


                int windowSize = options.WindowSize;
                bool efficient = options.UseEfficientAlgorithm;



                byte[,] result;

                timeLabel.Text = "processing...";
                var stopWatch = Stopwatch.StartNew();
                if (efficient)
                {
                    result = ImageOperations.MidPointFilterEffecient(
                        ImageMatrix, windowSize);
                }
                else
                {
                    result = ImageOperations.MidPointFilterSlow(
                        ImageMatrix, windowSize);
                }
                stopWatch.Stop();
                double seconds = stopWatch.Elapsed.TotalSeconds;
                seconds = Math.Round(seconds, 2);
                timeLabel.Text = $"{seconds}s";


                ImageOperations.DisplayImage(result, pictureBox2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ImageMatrix == null)
            {
                MessageBox.Show("ImageMatrix is null");
                return;
            }

            timeLabel.Text = "processing...";
            var stopWatch = Stopwatch.StartNew();
            byte[,] bilateralImage = ImageOperations.BilateralFilter(ImageMatrix, 7, 6, 25);

            stopWatch.Stop();
            double seconds = stopWatch.Elapsed.TotalSeconds;
            seconds = Math.Round(seconds, 2);
            timeLabel.Text = $"{seconds}s";


            ImageOperations.DisplayImage(bilateralImage, pictureBox2);
        }
    }
}