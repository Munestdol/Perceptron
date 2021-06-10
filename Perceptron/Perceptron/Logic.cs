using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Perceptron
{
    
        public static class Logic
        {
            public const float threshold = 1f;
            public const double changeLambda = 1;

    
       
        public static void FillMatrixOFPixels(int[,] matrixOfPixelsOFPicture, Bitmap bitmap, int size)
            {
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        if (bitmap.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                        {
                            matrixOfPixelsOFPicture[x, y] = 1;
                        }
                        else
                        {
                            matrixOfPixelsOFPicture[x, y] = 0;
                        }
                    }
                }
            }
            
            public static void FillValuePixels(int[] temp, int[,] matrixOfPixels, int size)
            {
                int count = default;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        temp[count] = matrixOfPixels[i, j];
                        count++;
                    }
                }
            }

            public static void CalculateSumA(DataGridView ConnectionTable, DataGridView LabmdaA, DataGridView LabmdaB, DataGridView LabmdaC, int[] temp, int numberOfPicture = 0)
            {
                var result = 0;
                var RowNUmber = LabmdaA.Rows.Add();
                var RowNUmberB = LabmdaB.Rows.Add();
                var RowNUmberC = LabmdaC.Rows.Add();
                var YNumber = ConnectionTable.Rows.Add();
                ConnectionTable.Rows[YNumber].Cells[0].Value = string.Format($"Y-A{numberOfPicture}");
                for (int i = 1; i < ConnectionTable.Columns.Count; i++)
                {
                    result = 0;

                    for (int j = 0; j < temp.Length; j++)
                    {
                        result = result + (temp[j] * int.Parse(ConnectionTable.Rows[j].Cells[i].Value.ToString()));
                    }

                    if (result >= threshold)
                    {
                        ConnectionTable.Rows[YNumber].Cells[i].Value = 1.ToString();
                        LabmdaA.Rows[RowNUmber].Cells[i].Value = double.Parse(LabmdaA.Rows[RowNUmber - 1].Cells[i].Value.ToString()) + changeLambda;
                        LabmdaB.Rows[RowNUmberB].Cells[i].Value = double.Parse(LabmdaB.Rows[RowNUmberB - 1].Cells[i].Value.ToString()) - changeLambda;
                        LabmdaC.Rows[RowNUmberC].Cells[i].Value = double.Parse(LabmdaC.Rows[RowNUmberC - 1].Cells[i].Value.ToString()) - changeLambda;

                    }
                    else if (result < threshold)
                    {
                        ConnectionTable.Rows[YNumber].Cells[i].Value = 0.ToString();
                        LabmdaA.Rows[RowNUmber].Cells[i].Value = double.Parse(LabmdaA.Rows[RowNUmber - 1].Cells[i].Value.ToString());
                        LabmdaB.Rows[RowNUmberB].Cells[i].Value = double.Parse(LabmdaB.Rows[RowNUmberB - 1].Cells[i].Value.ToString());
                        LabmdaC.Rows[RowNUmberC].Cells[i].Value = double.Parse(LabmdaB.Rows[RowNUmberC - 1].Cells[i].Value.ToString());
                    }
                }


            }
            public static void CalculateSumB(DataGridView ConnectionTable, DataGridView LabmdaA, DataGridView LabmdaB, DataGridView LabmdaC, int[] temp, int numberOfPicture = 0)
            {
                var result = 0;
                var RowNUmber = LabmdaA.Rows.Add();
                var RowNUmberB = LabmdaB.Rows.Add();
                var RowNUmberC = LabmdaC.Rows.Add();
                var YNumber = ConnectionTable.Rows.Add();
                ConnectionTable.Rows[YNumber].Cells[0].Value = string.Format($"Y-B{numberOfPicture}");
                for (int i = 1; i < ConnectionTable.Columns.Count; i++)
                {
                    result = 0;

                    for (int j = 0; j < temp.Length; j++)
                    {
                        result = result + (temp[j] * int.Parse(ConnectionTable.Rows[j].Cells[i].Value.ToString()));

                    }

                    if (result >= threshold)
                    {
                        ConnectionTable.Rows[YNumber].Cells[i].Value = 1.ToString();
                        LabmdaA.Rows[RowNUmber].Cells[i].Value = double.Parse(LabmdaA.Rows[RowNUmber - 1].Cells[i].Value.ToString()) - changeLambda;
                        LabmdaB.Rows[RowNUmberB].Cells[i].Value = double.Parse(LabmdaB.Rows[RowNUmberB - 1].Cells[i].Value.ToString()) + changeLambda;
                        LabmdaC.Rows[RowNUmberC].Cells[i].Value = double.Parse(LabmdaC.Rows[RowNUmberC - 1].Cells[i].Value.ToString()) - changeLambda;

                    }
                    else if (result < threshold)
                    {
                        ConnectionTable.Rows[YNumber].Cells[i].Value = 0.ToString();
                        LabmdaA.Rows[RowNUmber].Cells[i].Value = double.Parse(LabmdaA.Rows[RowNUmber - 1].Cells[i].Value.ToString());
                        LabmdaB.Rows[RowNUmberB].Cells[i].Value = double.Parse(LabmdaB.Rows[RowNUmberB - 1].Cells[i].Value.ToString());
                        LabmdaC.Rows[RowNUmberC].Cells[i].Value = double.Parse(LabmdaB.Rows[RowNUmberC - 1].Cells[i].Value.ToString());
                    }
                }


            }
            public static void CalculateSumC(DataGridView ConnectionTable, DataGridView LabmdaA, DataGridView LabmdaB, DataGridView LabmdaC, int[] temp, int numberOfPicture = 0)
            {
                var result = 0;
                var RowNUmber = LabmdaA.Rows.Add();
                var RowNUmberB = LabmdaB.Rows.Add();
                var RowNUmberC = LabmdaC.Rows.Add();
                var YNumber = ConnectionTable.Rows.Add();
                ConnectionTable.Rows[YNumber].Cells[0].Value = string.Format($"Y-C{numberOfPicture}");
                for (int i = 1; i < ConnectionTable.Columns.Count; i++)
                {
                    result = 0;

                    for (int j = 0; j < temp.Length; j++)
                    {
                        result = result + (temp[j] * int.Parse(ConnectionTable.Rows[j].Cells[i].Value.ToString()));

                    }

                    if (result >= threshold)
                    {
                        ConnectionTable.Rows[YNumber].Cells[i].Value = 1.ToString();
                        LabmdaA.Rows[RowNUmber].Cells[i].Value = double.Parse(LabmdaA.Rows[RowNUmber - 1].Cells[i].Value.ToString()) - changeLambda;
                        LabmdaB.Rows[RowNUmberB].Cells[i].Value = double.Parse(LabmdaB.Rows[RowNUmberB - 1].Cells[i].Value.ToString()) - changeLambda;
                        LabmdaC.Rows[RowNUmberC].Cells[i].Value = double.Parse(LabmdaC.Rows[RowNUmberC - 1].Cells[i].Value.ToString()) + changeLambda;

                    }
                    else if (result < threshold)
                    {
                        ConnectionTable.Rows[YNumber].Cells[i].Value = 0.ToString();
                        LabmdaA.Rows[RowNUmber].Cells[i].Value = double.Parse(LabmdaA.Rows[RowNUmber - 1].Cells[i].Value.ToString());
                        LabmdaB.Rows[RowNUmberB].Cells[i].Value = double.Parse(LabmdaB.Rows[RowNUmberB - 1].Cells[i].Value.ToString());
                        LabmdaC.Rows[RowNUmberC].Cells[i].Value = double.Parse(LabmdaC.Rows[RowNUmberC - 1].Cells[i].Value.ToString());
                    }
                }

            }
            public static void CalculateSum(DataGridView ConnectionTable, DataGridView LabmdaA, DataGridView LabmdaB, DataGridView LabmdaC, int[] temp)
            {

                var result = 0;
                var sumA = 0;
                var subB = 0;
                var sumC = 0;
                var YNumber = ConnectionTable.Rows.Add();
                var row = ConnectionTable.Rows.Count - 2;
                ConnectionTable.Rows[YNumber].Cells[0].Value = string.Format($"Y-Unknow");
                for (int i = 1; i < ConnectionTable.Columns.Count; i++)
                {
                    result = 0;

                    for (int j = 0; j < temp.Length; j++)
                    {
                        result = result + (temp[j] * int.Parse(ConnectionTable.Rows[j].Cells[i].Value.ToString()));
                    }

                    if (result >= threshold)
                    {
                        ConnectionTable.Rows[YNumber].Cells[i].Value = 1.ToString();


                    }
                    else if (result < threshold)
                    {
                        ConnectionTable.Rows[YNumber].Cells[i].Value = 0.ToString();

                    }
                }

                for (int i = 1; i < ConnectionTable.Columns.Count; i++)
                {

                    sumA += (int)(double.Parse(ConnectionTable.Rows[YNumber].Cells[i].Value.ToString()) * double.Parse(LabmdaA.Rows[LabmdaA.Rows.Count - 2].Cells[i].Value.ToString()));
                    subB += (int)(double.Parse(ConnectionTable.Rows[YNumber].Cells[i].Value.ToString()) * double.Parse(LabmdaB.Rows[LabmdaB.Rows.Count - 2].Cells[i].Value.ToString()));
                    sumC += (int)(double.Parse(ConnectionTable.Rows[YNumber].Cells[i].Value.ToString()) * double.Parse(LabmdaC.Rows[LabmdaC.Rows.Count - 2].Cells[i].Value.ToString()));
                }


            int aR = 1000+sumA;
            int bR = 1000 + subB;
            int cR = 1000 + sumC;

            if(aR>bR)
            {
                if (aR > cR)
                {
                    aR = 1;
                    bR = 0;
                    cR = 0;
                }else
                {
                    aR = 0;
                    bR = 0;
                    cR = 1;
                }
            }else if (bR > cR)
            {
                aR = 0;
                bR = 1;
                cR = 0;
            } else
            {
                aR = 0;
                bR = 0;
                cR = 1;
            }

            //MessageBox.Show($" sumA = {sumA}, SumB = {subB}, sumC = {sumC}");
            MessageBox.Show($" Class A = {aR}, Class B = {bR}, Class C = {cR}", "");
        }
        }
    }


