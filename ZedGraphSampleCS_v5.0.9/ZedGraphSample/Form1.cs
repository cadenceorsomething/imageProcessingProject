using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraphSample
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}


		private void Form1_Load( object sender, EventArgs e )
		{
			SetSize();
            comboBox1.Items.Add("Median Filter");
            comboBox1.Items.Add("MidPoint Filter");
		}


        


        private void CreateMedianGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();

            myPane.Title.Text = "Median Filter - Execution Time vs Window Size";
            myPane.XAxis.Title.Text = "Window Size";
            myPane.YAxis.Title.Text = "Time (ms)";



            List<int> quickValues = new List<int>
            {
                13, 34, 67, 115, 166, 237,
                317, 412, 522, 657, 812
            };

            PointPairList quick = new PointPairList();

            int size = 3;
            for (int i = 0; i < quickValues.Count; i++)
            {
                quick.Add(size, quickValues[i]);
                size += 2;
            }



            List<int> countValues = new List<int>
            {
                34, 42, 54, 71, 91, 114,
                140, 170, 204, 242, 277
            };

            PointPairList count = new PointPairList();

            size = 3;
            for (int i = 0; i < countValues.Count; i++)
            {
                count.Add(size, countValues[i]);
                size += 2;
            }



            List<int> kthValues = new List<int>
            {
                10, 70, 200, 445, 850, 1500,
                2400, 3600, 5200, 7200, 10000
            };

            PointPairList kth = new PointPairList();

            size = 3;
            for (int i = 0; i < kthValues.Count; i++)
            {
                kth.Add(size, kthValues[i]/ 2);
                size += 2;
            }


            myPane.AddCurve("Quick Sort", quick, Color.Blue, SymbolType.Circle);
            myPane.AddCurve("Counting Sort", count, Color.Red, SymbolType.Circle);
            myPane.AddCurve("Select Kth", kth, Color.Green, SymbolType.Circle);

            // Final update
            zgc.AxisChange();
            zgc.Invalidate();
        }


        private void CreateMidpointGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();

            myPane.Title.Text = "Midpoint Filter - Execution Time vs Window Size";
            myPane.XAxis.Title.Text = "Window Size";
            myPane.YAxis.Title.Text = "Time (ms)";

            // Naive method
            List<int> naiveValues = new List<int>
            {
                16, 36, 72, 120, 173,
                235, 310, 400, 505, 625, 757
            };

            PointPairList naive = new PointPairList();

            int size = 3;
            for (int i = 0; i < naiveValues.Count; i++)
            {
                naive.Add(size, naiveValues[i]);
                size += 2;
            }

            // Efficient method

            List<int> efficientValues = new List<int>
            {
                6, 13, 22, 34,
                46, 61, 79, 100,
                124, 151, 181
            };

            PointPairList efficient = new PointPairList();

            size = 3;
            for (int i = 0; i < efficientValues.Count; i++)
            {
                efficient.Add(size, efficientValues[i]);
                size += 2;
            }


            myPane.AddCurve("Naive", naive, Color.Purple, SymbolType.Circle);
            myPane.AddCurve("Efficient", efficient, Color.Orange, SymbolType.Circle);

            zgc.AxisChange();
            zgc.Invalidate();
        }


        private void Form1_Resize( object sender, EventArgs e )
		{
			SetSize();
		}

		private void SetSize()
		{
			zg1.Location = new Point( 10, 10 );
			// Leave a small margin around the outside of the control
			zg1.Size = new Size( this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20 );
		}


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GraphPane pane = zg1.GraphPane;

            // Clear old graph
            pane.CurveList.Clear();

            if (comboBox1.SelectedIndex == 0) // Median Filter
            {
                CreateMedianGraph(zg1);
            }
            else if (comboBox1.SelectedIndex == 1) // Midpoint Filter
            {
                CreateMidpointGraph(zg1);
            }
        }

    }
}