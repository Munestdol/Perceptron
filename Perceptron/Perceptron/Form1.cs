using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        public int count = 1;
        public const int CountOfPixels = 30;
        public const int AElements = 300;
        public static int[,] MatrixOfConnectionToAElements = new int[CountOfPixels * CountOfPixels, AElements];
        public static int[] Pixels;

        Graphics graphics;
        Image image;

        string bmpPath = "";
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            graphics.ScaleTransform(10, 10);
            InitializeTable();
            FillTableOfConnection(dataGridView1);
            IniatializeLabmdaABC();      
        }
        private void FillTableOfConnection(DataGridView dataGridViewTemp)
        {
            int x = 0;          
            for (int i = 1; i < dataGridViewTemp.Rows.Count; i++)
            {
                if (i == 300)
                {
                    break;
                }
                else
                {
                    dataGridViewTemp.Rows[x].Cells[i].Value = 1.ToString();
                    x++;
                }
            }
            Random rnd = new Random();
            for (int i = 300; i < 900; i++)
            {
                for (int j = 1; j < 300; j++)
                {
                    int value = rnd.Next(-1, 2);
                    dataGridViewTemp.Rows[i].Cells[j].Value = value;
                }
            }

            for (int i = 0; i < dataGridViewTemp.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridViewTemp.Columns.Count; j++)
                {
                    if (dataGridViewTemp.Rows[i].Cells[j].Value == null)
                    {
                        dataGridViewTemp.Rows[i].Cells[j].Value = 0.ToString();

                    }
                    else
                    {
                        continue;
                    }
                }
                if (i == 899)
                {
                    break;
                }
            }
        }
        private void InitializeTable()
        {
            int x = 1;


            for (int i = 0; i < AElements + 1; i++)
            {

                if (i == 0)
                {
                    dataGridView1.Columns.Add(i.ToString(), "");
                    var column = dataGridView1.Columns[i];
                    column.Width = 30;
                }
                else
                {
                    dataGridView1.Columns.Add(i.ToString(), (x).ToString());
                    var column = dataGridView1.Columns[i];
                    column.Width = 30;
                    x++;
                }
            }
            for (int i = 0; i < 900; i++)
            {
                dataGridView1.Rows.Add();
            }

            for (int i = 0; i < 900; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = string.Format($"X{i + 1}");
            }
        }

        private void IniatializeLabmdaABC()
        {
            for (int i = 0; i < 301; i++)
            {
                
                dataGridView2.Columns.Add(i.ToString(), (i + 1).ToString());
                dataGridView3.Columns.Add(i.ToString(), (i + 1).ToString());
                dataGridView4.Columns.Add(i.ToString(), (i + 1).ToString());
                var columnA = dataGridView2.Columns[i];
                var columnB = dataGridView3.Columns[i];
                var columnC = dataGridView4.Columns[i];
                columnA.Width = 30;
                columnB.Width = 30;
                columnC.Width = 30;
            }
            var RowNumberA = dataGridView2.Rows.Add();
            var RowNumberB = dataGridView3.Rows.Add();
            var RowNumberC = dataGridView4.Rows.Add();
            for (int i = 1; i < 301; i++)
            {
                dataGridView2.Rows[RowNumberA].Cells[i].Value = "1";
                dataGridView3.Rows[RowNumberB].Cells[i].Value = "1";
                dataGridView4.Rows[RowNumberC].Cells[i].Value = "1";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       


        private void OpenUploadFiles()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            Brush aBrush = (Brush)Brushes.Black;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bmpPath = openFileDialog.FileName;
                image = Image.FromFile(bmpPath);
            }
            else
            {
                bmpPath = "";
            }
            bitmap = new Bitmap(image);

            for (int x = 0; x < CountOfPixels; x++)
            {
                for (int y = 0; y < CountOfPixels; y++)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                    {
                        graphics.FillRectangle(aBrush, x, y, 1, 1);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            int[,] MatrixOfUploadPictures = new int[CountOfPixels, CountOfPixels];
            int[] Pixels1 = new int[CountOfPixels * CountOfPixels];
            OpenUploadFiles();           
            
            Logic.FillMatrixOFPixels(MatrixOfUploadPictures, bitmap, CountOfPixels);
            Logic.FillValuePixels(Pixels1, MatrixOfUploadPictures, CountOfPixels);
            Logic.CalculateSum(dataGridView1, dataGridView2, dataGridView3, dataGridView4, Pixels1);
        }
        private void MainLogicExecuteA(int[,] MatrixOfUploadPictures, Bitmap bitmap1, int number)
        {
            Pixels = new int[CountOfPixels * CountOfPixels];
            Logic.FillMatrixOFPixels(MatrixOfUploadPictures, bitmap1, CountOfPixels);
            
            Logic.FillValuePixels(Pixels, MatrixOfUploadPictures, CountOfPixels);
            Logic.CalculateSumA(dataGridView1, dataGridView2, dataGridView3, dataGridView4, Pixels, number);
        }
        private void MainLogicExecuteB(int[,] MatrixOfUploadPictures, Bitmap bitmap1, int number)
        {
            Pixels = new int[CountOfPixels * CountOfPixels];
            Logic.FillMatrixOFPixels(MatrixOfUploadPictures, bitmap1, CountOfPixels);
            
            Logic.FillValuePixels(Pixels, MatrixOfUploadPictures, CountOfPixels);
            Logic.CalculateSumB(dataGridView1, dataGridView2, dataGridView3, dataGridView4, Pixels, number);
        }

        private void MainLogicExecuteC(int[,] MatrixOfUploadPictures, Bitmap bitmap1, int number)
        {
            Pixels = new int[CountOfPixels * CountOfPixels];
            Logic.FillMatrixOFPixels(MatrixOfUploadPictures, bitmap1, CountOfPixels);
            
            Logic.FillValuePixels(Pixels, MatrixOfUploadPictures, CountOfPixels);
            Logic.CalculateSumC(dataGridView1, dataGridView2, dataGridView3, dataGridView4, Pixels, number);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count = 1;
            pictureBox1.Refresh();
            int[,] MatrixOfUploadPictures = new int[CountOfPixels, CountOfPixels];
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Brush aBrush = (Brush)Brushes.Black;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bmpPath = openFileDialog.FileName;
                image = Image.FromFile(bmpPath);
            }
            else
            {
                bmpPath = "";
            }           
            bitmap = new Bitmap(image);
            for (int x = 0; x < CountOfPixels; x++)
            {
                for (int y = 0; y < CountOfPixels; y++)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                    {
                        graphics.FillRectangle(aBrush, x, y, 1, 1);
                    }
                }
            }
            MainLogicExecuteA(MatrixOfUploadPictures, bitmap, count);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count = 1;
            pictureBox1.Refresh();
            int[,] MatrixOfUploadPictures = new int[CountOfPixels, CountOfPixels];
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Brush aBrush = (Brush)Brushes.Black;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bmpPath = openFileDialog.FileName;
                image = Image.FromFile(bmpPath);
            }
            else
            {
                bmpPath = "";
            }
            bitmap = new Bitmap(image);
            for (int x = 0; x < CountOfPixels; x++)
            {
                for (int y = 0; y < CountOfPixels; y++)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                    {
                        graphics.FillRectangle(aBrush, x, y, 1, 1);
                    }
                }
            }
            MainLogicExecuteB(MatrixOfUploadPictures, bitmap, count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            count = 1;
            pictureBox1.Refresh();
            int[,] MatrixOfUploadPictures = new int[CountOfPixels, CountOfPixels];
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Brush aBrush = (Brush)Brushes.Black;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bmpPath = openFileDialog.FileName;
                image = Image.FromFile(bmpPath);
            }
            else
            {
                bmpPath = "";
            }
            bitmap = new Bitmap(image);
            for (int x = 0; x < CountOfPixels; x++)
            {
                for (int y = 0; y < CountOfPixels; y++)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                    {
                        graphics.FillRectangle(aBrush, x, y, 1, 1);
                    }
                }
            }
            MainLogicExecuteC(MatrixOfUploadPictures, bitmap, count);
        }    
    }
}
