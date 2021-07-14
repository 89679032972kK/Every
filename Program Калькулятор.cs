MyMatrix.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Matrix
{
    class MyMatrix
    {
        int[,] a = new int[3, 3];

        // передача значений
        public void Set(int i, int j, int znach)
        {
            a[i, j] = znach;
        }

        // сложение
        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            MyMatrix NewMatrix = new MyMatrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NewMatrix.a[i, j] = matrix1.a[i, j] + matrix2.a[i, j];
                }
            }
            return NewMatrix;
        }

        // вывод матрицы
        public string Visual(int i, int j)
        {
            return a[i, j].ToString();
        }

        // вывод всей и сразу. Хд
        public DataGridView FullVisual(DataGridView dt)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dt.Rows[j].Cells[i].Value = a[i, j];
                }
            }
            return dt;
        }
        // вычитание
        public static MyMatrix operator – (MyMatrix matrix1, MyMatrix matrix2)
        {
            MyMatrix NewMatrix = new MyMatrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NewMatrix.a[i, j] = matrix1.a[i, j] – matrix2.a[i, j];
                }
            }
            return NewMatrix;
        }

        // транспонирование
        public MyMatrix Trans()
        {
            MyMatrix NewMatrix = new MyMatrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NewMatrix.a[i, j] = a[j, i];
                }
            }
            return NewMatrix;
        }

        // умножение
        public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
        {
            MyMatrix NewMatrix = new MyMatrix();
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    //int a = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        //a += matrix1.a [j, k] * matrix2.a [i, j];
                        NewMatrix.a[i, k] += matrix1.a[j, k] * matrix2.a[i, j];
                    }
                    //NewMatrix.a [i, k] = a;
                }
            }
            return NewMatrix;
        }

        // заполнение
        public void Zapoln(DataGridView grid)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a[i, j] = Convert.ToInt32(grid.Rows[j].Cells[i].Value);
                }
            }
        }
    }
}


Form1.cs
using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Data;
using System. Drawing;
using System. Linq;
using System. Text;
using System. Windows. Forms;

namespace Matrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView2.Rows.Add();
                dataGridView3.Rows.Add();
                //dataGridView1. Rows[i].Cells[0].Value = i. ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyMatrix matrix1 = new MyMatrix();
            MyMatrix matrix2 = new MyMatrix();
            MyMatrix matrix3;
            matrix1.Zapoln(dataGridView1);
            matrix2.Zapoln(dataGridView2);
            matrix3 = (matrix1 + matrix2);
            matrix3.FullVisual(dataGridView3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyMatrix matrix1 = new MyMatrix();
            MyMatrix matrix2 = new MyMatrix();
            MyMatrix matrix3;
            matrix1.Zapoln(dataGridView1);
            matrix2.Zapoln(dataGridView2);
            matrix3 = (matrix1 – matrix2);
            matrix3.FullVisual(dataGridView3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyMatrix matrix1 = new MyMatrix();
            MyMatrix matrix3;
            matrix1.Zapoln(dataGridView1);
            matrix3 = matrix1.Trans();
            matrix3.FullVisual(dataGridView3);
        }

        private void button4_Click(object sender, EventArgs e)
