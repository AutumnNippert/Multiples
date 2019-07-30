using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiples_finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double num1 { get; private set; }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int number = int.Parse(numberBox.Text);
            num1 = Math.Sqrt(number);
            //Useless If always returns true
            if (num1 % 1 == 0)
            {
                Double num2 = num1;
                equasionBox.Text = num1.ToString() + " x " + num2.ToString();
            }
            else
            {
                int[,] multiples = new int[number*number, 2];
                int count = 0;
                for (int i = 1; i <= Math.Sqrt(number); i++)
                {
                    for (int j = 1; j <= number; j++)
                    {
                        Console.WriteLine(count.ToString());
                        if (i * j == number)
                        {
                            multiples[count,0] = i;
                            multiples[count, 1] = j;
                        }
                        count++;
                    }
                }

                int diff = multiples[0,0] - multiples[0,1];
                int[] bestPair = new int[2];
                bestPair[0] = multiples[0, 0];
                bestPair[1] = multiples[0, 1];
                int bound0 = multiples.GetUpperBound(0);
                int bound1 = multiples.GetUpperBound(1);
                for (int i = 0; i <= multiples.GetLength(0) -1; i++)
                {
                     int diffCur = multiples[i, 0] - multiples[i, 1];
                    if(diffCur < diff)
                    {
                        bestPair[0] = multiples[i, 0];
                        bestPair[1] = multiples[i, 1];
                    }
                }
                equasionBox.Text = bestPair[0] + " x " + bestPair[1];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
