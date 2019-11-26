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

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int number = int.Parse(numberBox.Text);
            double num1 = Math.Sqrt(number);
            // Double returns square root, this checks to see if number is a perfect square
            if (num1 % 1 == 0)
            {
                equasionBox.Text = num1.ToString() + " x " + num1.ToString();
            }
            else
            {

                /* Overview of Algorithm
                 * Start at the closest possible pair of numbers, the square root who have a difference of 0.
                 * If there is no integer square root, slowly increase the difference between the two numbers
                 *     If the two numbers multiply to a larger number:
                 *         decrease the first number.
                 *     otherwise, if they're too small:
                 *         increase the second number.
                 *     if they multiply to the target:
                 *         stop, we have the answer.
                 *
                 * The algorithm can immediately stop once it has found two numbers that multiply to the target.
                 * With each time through the loop, the difference between the numbers gets larger and larger each time.
                 * If there were a pair of numbers that are closer together then we would have found them already.
                 */

                /* Example
                 * Target Number = 117
                 * sqrt(117) ~= 10.8 which is converted to 10
                 * Set Num1 = 10
                 * Set Num2 = 10
                 * Num1 * Num2 = 100 < 117
                 * Num2 = Num2 + 1 = 11
                 * Num1 * Num2 = 110 < 117
                 * Num2 = Num2 + 1 = 12
                 * Num1 * Num2 = 120 > 117
                 * Num1 = Num1 - 1 = 9
                 * Num1 * Num2 = 108 < 117
                 * Num2 = Num2 + 1 = 13
                 * Num1 * Num2 = 117
                 * Done.
                 * Num1 = 9, Num2 = 13
                 */

                // start the best pair at the square root (converts the double into an integer)
                int[] bestPair = { (int)num1, (int)num1 };

                // keep track of the product of the pair
                int product = bestPair[0] * bestPair[1];

                // when the numbers multiply to number, we have the closest pair
                while (product != number)
                {
                    if (product > number)
                    {
                        // if the product is too large
                        // decrease the first number
                        bestPair[0] = bestPair[0] - 1;
                    } else if (product < number)
                    {
                        // if the product is too small
                        // increase the second number
                        bestPair[1] = bestPair[1] + 1;
                    }

                    // recalculate the product
                    product = bestPair[0] * bestPair[1];
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
