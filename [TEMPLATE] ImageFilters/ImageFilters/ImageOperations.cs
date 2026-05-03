using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageFilters
{
    public class ImageOperations
    {
        public static byte[,] OpenImage(string ImagePath)
        {
            Bitmap original_bm = new Bitmap(ImagePath);
            int Height = original_bm.Height;
            int Width = original_bm.Width;

            byte[,] Buffer = new byte[Height, Width];

            unsafe
            {
                BitmapData bmd = original_bm.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, original_bm.PixelFormat);
                int x, y;
                int nWidth = 0;
                bool Format32 = false;
                bool Format24 = false;
                bool Format8 = false;

                if (original_bm.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    Format24 = true;
                    nWidth = Width * 3;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format32bppArgb || original_bm.PixelFormat == PixelFormat.Format32bppRgb || original_bm.PixelFormat == PixelFormat.Format32bppPArgb)
                {
                    Format32 = true;
                    nWidth = Width * 4;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Format8 = true;
                    nWidth = Width;
                }
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (y = 0; y < Height; y++)
                {
                    for (x = 0; x < Width; x++)
                    {
                        if (Format8)
                        {
                            Buffer[y, x] = p[0];
                            p++;
                        }
                        else
                        {
                            Buffer[y, x] = (byte)((int)(p[0] + p[1] + p[2]) / 3);
                            if (Format24) p += 3;
                            else if (Format32) p += 4;
                        }
                    }
                    p += nOffset;
                }
                original_bm.UnlockBits(bmd);
            }

            return Buffer;
        }
        public static int GetHeight(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(0);
        }
        public static int GetWidth(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(1);
        }
        public static void DisplayImage(byte[,] ImageMatrix, PictureBox PicBox)
        {
            // Create Image:
            //==============
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        p[0] = p[1] = p[2] = ImageMatrix[i, j];
                        p += 3;
                    }

                    p += nOffset;
                }
                ImageBMP.UnlockBits(bmd);
            }
            PicBox.Image = ImageBMP;
        }


        // O(n^2*log(n)) solution.
        // i will write more notes later
        public static byte[,] MedianFilter(byte[,] image, int windowSize)
        {
            if (windowSize % 2 == 0)
                throw new ArgumentException("windowSize HAS to be odd.");

            int height = image.GetLength(0);
            int width = image.GetLength(1);

            byte[,] result = new byte[height, width];
            Array.Copy(image, result, image.Length);

            int r = windowSize / 2;



            for (int i = r; i < height - r; i++)
            {
                for (int j = r; j < width - r; j++)
                {
                    List<byte> window = new List<byte>();


                    for (int x = -r; x <= r; x++)
                    {
                        for (int y = -r; y <= r; y++)
                        {
                            window.Add(image[i + x, j + y]);
                        }
                    }

                    window.Sort();
                    result[i, j] = window[window.Count / 2];
                }
            }

            return result;
        }


        // the sort makes it O(n*log(n))
        public static byte[,] MidPointFilterSlow(byte[,] image, int windowSize)
        {
            if (windowSize % 2 == 0)
                throw new ArgumentException("windowSize HAS to be odd.");

            int height = image.GetLength(0);
            int width = image.GetLength(1);

            byte[,] result = new byte[height, width];
            Array.Copy(image, result, image.Length);

            int r = windowSize / 2;

            for (int i = r; i < height - r; i++)
            {
                for (int j = r; j < width - r; j++)
                {
                    List<byte> window = new List<byte>();


                    for (int x = -r; x <= r; x++)
                    {
                        for (int y = -r; y <= r; y++)
                        {
                            window.Add(image[i + x, j + y]);
                        }
                    }

                    window.Sort();

                    // the min and max value of this window
                    byte min = window[0], max = window[window.Count - 1];

                    // calculate the midpoint as the new pixel
                    byte midpoint = (byte)((min + max) / 2);
                    result[i, j] = midpoint;
                }
            }

            return result;
        }


        // O(n)
        public static byte[,] MidPointFilterEffecient(byte[,] image, int windowSize)
        {
            if (windowSize % 2 == 0)
                throw new ArgumentException("windowSize HAS to be odd.");

            int height = image.GetLength(0);
            int width = image.GetLength(1);

            byte[,] result = new byte[height, width];
            Array.Copy(image, result, image.Length);

            int r = windowSize / 2;

            for (int i = r; i < height - r; i++)
            {
                for (int j = r; j < width - r; j++)
                {
                    List<byte> window = new List<byte>();

                    byte min = 255;
                    byte max = 0;


                    for (int x = -r; x <= r; x++)
                    {
                        for (int y = -r; y <= r; y++)
                        {
                            byte val = image[i + x, j + y];

                            if (val < min) min = val;
                            if (val > max) max = val;
                        }
                    }

                    result[i, j] = (byte)((min + max) / 2);
                }
            }

            return result;
        }

        // BONUS 
        // the results of the median and midpoint filters have yeilded dissatisfactory results when compared to my imagination.
        // hence, i looked up a way to both make an image filtered and preserve the sharp edges by using bilateral filtering
        // the core idea us to blend similar pixels only.

        // spatial gaussian: a convolution used to smooth out a surface
        static private double SpatialWeight(int dx, int dy, double sigma_S)
        {
            return Math.Exp(-(dx * dx + dy * dy) / (2.0 * sigma_S * sigma_S));
        }


        static private double RangeWeight(int intensityDelta, double sigma_B)
        {
            return Math.Exp(-(intensityDelta * intensityDelta) / (2 * sigma_B * sigma_B));
        }


        private static byte ClampToByte(double v)
        {
            if (v < 0) return 0;
            if (v > 255) return 255;
            return (byte)v;
        }


        // didnt work with salt and pepper noise, better with mild noise.
        static public byte[,] BilateralFilter(byte[,] image, int WindowSize, double sigma_S, double sigma_B)
        {
            if (WindowSize % 2 == 0)
                throw new ArgumentException("WindowSize must be odd.");
            if (sigma_S <= 0 || sigma_B <= 0)
                throw new ArgumentException("Sigma values must be > 0.");

            int height = image.GetLength(0);
            int width = image.GetLength(1);
            int r = WindowSize / 2;

            byte[,] result = new byte[height, width];
            Array.Copy(image, result, image.Length);

            double[,] spatialKernel = new double[WindowSize, WindowSize];
            for (int m = -r; m <= r; m++)
                for (int n = -r; n <= r; n++)
                    spatialKernel[m + r, n + r] = SpatialWeight(m, n, sigma_S);

            const double EPS = 1e-12;

            for (int i = r; i < height - r; i++)
            {
                for (int j = r; j < width - r; j++)
                {
                    double weightedSum = 0.0;
                    double weightSum = 0.0;
                    byte centerPixl = image[i, j];

                    for (int m = -r; m <= r; m++)
                    {
                        for (int n = -r; n <= r; n++)
                        {
                            int neighborX = i + m;
                            int neighborY = j + n;

                            byte neighborPixl = image[neighborX, neighborY];

                            double spatial = spatialKernel[m + r, n + r];
                            double range = RangeWeight(neighborPixl - centerPixl, sigma_B);

                            double weight = spatial * range;

                            weightedSum += neighborPixl * weight;
                            weightSum += weight;
                        }
                    }

                    if (weightSum > EPS)
                        result[i, j] = ClampToByte(weightedSum / weightSum);
                    else
                        result[i, j] = centerPixl;
                }
            }

            return result;
        }

    }
}
