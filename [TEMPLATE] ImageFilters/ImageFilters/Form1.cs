using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;



namespace ImageFilters
{
    public partial class Form1 : Form
    {
        private Button[] buttonArr;
        public Form1()
        {
            InitializeComponent();

            buttonArr = new Button[] { MedianBtn, MidpointBtn, BilateralBtn };

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
                ImageOperations.DisplayImage(ImageMatrix, pictureBoxRight);

                // enable filters

                foreach (var btn in buttonArr)
                    btn.Enabled = true;
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // i added this to stop an error from recurring
        }


        private void median_Click(object sender, EventArgs e)
        {
            if (ImageMatrix == null)
            {
                MessageBox.Show("ImageMatrix is null");
                return;
            }

            MedianWindow form = new MedianWindow();

            if (form.ShowDialog() != DialogResult.OK)
                return;

            string method = form.SelectedMethod;
            int k = form.K;

            int height = ImageMatrix.GetLength(0);
            int width = ImageMatrix.GetLength(1);

            byte[,] result = new byte[height, width];

            int[] countArray = new int[256];
            int windowSize = form.windowSize;


            int offset = windowSize / 2;

            byte[] window = new byte[windowSize * windowSize];

            TimeLabel.Text = "processing...";
            var stopwatch = Stopwatch.StartNew();

            for (int i = offset; i < height - offset; i++)
            {
                for (int j = offset; j < width - offset; j++)
                {
                    int index = 0;

                    // build window
                    for (int x = -offset; x <= offset; x++)
                    {
                        for (int y = -offset; y <= offset; y++)
                        {
                            window[index++] = ImageMatrix[i + x, j + y];
                        }
                    }

                    byte median;

                    if (method == "Quick Sort")
                    {
                        median = ImageOperations.GetMedian_QuickSort((byte[])window.Clone());
                    }
                    else if (method == "Counting Sort")
                    {
                        median = ImageOperations.GetMedian_CountingSort(window, countArray);
                    }
                    else if (method == "Select K-th Element")
                    {
                        median = ImageOperations.GetMedian_SelectKthElement((byte[])window.Clone(), 0, window.Length - 1, k);
                    }
                    else // Hybrid
                    {
                        median = ImageOperations.GetMedian_HybridInsertion(window, countArray);
                    }

                    result[i, j] = median;
                }
            }

            stopwatch.Stop();
            TimeLabel.Text = $"{Math.Round(stopwatch.Elapsed.TotalSeconds, 2)}s";

            ImageOperations.DisplayImage(result, pictureBoxLeft);
        }


        private void midpoint_Click(object sender, EventArgs e)
        {
            if (ImageMatrix == null)
            {
                MessageBox.Show("ImageMatrix is null");
                return;
            }

            // byte[,] medianImage = ImageOperations.MidPointFilterSlow(ImageMatrix, 7);
            //ImageOperations.DisplayImage(medianImage, pictureBox2);

            using (MidPointWindow options = new MidPointWindow() )
            {
                // presses cancel
                if (options.ShowDialog() != DialogResult.OK)
                    return;


                int windowSize = options.WindowSize;
                bool efficient = options.UseEfficientAlgorithm;



                byte[,] result;

                TimeLabel.Text = "processing...";
                var stopWatch = Stopwatch.StartNew();
                if (efficient)
                {
                    result = ImageOperations.MidPointFilterEffecient(
                        ImageMatrix, windowSize);
                }
                else
                {
                    result = ImageOperations.MidPointFilterNaive(
                        ImageMatrix, windowSize);
                }
                stopWatch.Stop();
                double seconds = stopWatch.Elapsed.TotalSeconds;
                seconds = Math.Round(seconds, 2);
                TimeLabel.Text = $"{seconds}s";


                ImageOperations.DisplayImage(result, pictureBoxLeft);
            }
        }

        private void bilateral_Click(object sender, EventArgs e)
        {
            if (ImageMatrix == null)
            {
                MessageBox.Show("ImageMatrix is null");
                return;
            }

            TimeLabel.Text = "processing...";
            var stopWatch = Stopwatch.StartNew();
            byte[,] bilateralImage = ImageOperations.BilateralFilter(ImageMatrix, 7, 6, 25);

            stopWatch.Stop();
            double seconds = stopWatch.Elapsed.TotalSeconds;
            seconds = Math.Round(seconds, 2);
            TimeLabel.Text = $"{seconds}s";


            ImageOperations.DisplayImage(bilateralImage, pictureBoxLeft);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}