using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string boxTop = "";
        string boxBot = "";

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNeg_Click(object sender, EventArgs e)
        {
            // If equation is not empty
            if (boxTop.Length > 0)
            {
                // If there is no negative symbol
                if (boxTop[boxTop.Length - 1] != '-')
                {
                    // Add negative symbol
                    boxTop += "-";
                } 
                else
                {
                    // Remove the symbol
                    boxTop = boxTop.Substring(0, boxTop.Length - 1);
                }
            }
            else
            {
                // Add negative symbol to empty string
                boxTop += "-";
            }
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonAC_Click(object sender, EventArgs e)
        {
            // Clear everything by setting both strings to empty
            boxTop = "";
            boxBot = "";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            // Add modulus symbol
            boxTop += "%";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            // Add division symbol
            boxTop += "/";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            // Add addition symbol
            boxTop += "+";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            // Add subtraction symbol
            boxTop += "-";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            // Add multiplication symbol
            boxTop += "x";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonDec_Click(object sender, EventArgs e)
        {
            // Add decimal
            boxTop += ".";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            // Catch any improper input
            try
            {
                // Store the string of input
                string equation = boxTop;
                // String of ordered operations
                string operators = "x/%+-";
                // Store the numbers for operation
                double x, y;
                // Store current operation
                // Index of end of first number and end of second number
                int currentOp = 0, j, k;

                // Cycle through order of operations
                for (int i = 0; i < equation.Length && currentOp < 5; i++)
                {
                    string hold = "";

                    // If a symbol is found that is not a negative symbol assoc with sci notation
                    if (equation[i] == operators[currentOp] && equation[i - 1] != 'E' && i != 0)
                    {
                        // Cycle through equation and store first number
                        for (j = i -1; j >= 0; j--)
                        {
                            // Break if there is a symbol that is not the first char in string or next to another
                            if (operators.Contains(equation[j]) && j != 0 && !operators.Contains(equation[j - 1]))
                            {
                                break;
                            }

                            // Store the good chars
                            hold += equation[j];
                        }

                        // Reverse string
                        char[] c = hold.ToCharArray();
                        Array.Reverse(c);
                        hold = new string(c);

                        // Convert string to double and set hold to empty
                        x = Convert.ToDouble(hold);
                        hold = "";

                        // Cycle through equation and store second number
                        for (k = i + 1; k < equation.Length; k++)
                        {
                            // Break if there is a symbol that is not next to another
                            if (operators.Contains(equation[k]) && operators.Contains(equation[k + 1]))
                            {
                                break;
                            }

                            // Store the good chars
                            hold += equation[k];
                        }

                        // Convert string to double and set hold to empty string
                        y = Convert.ToDouble(hold);
                        hold = "";

                        // Switch case to perform correct operation on the numbers
                        switch (operators[currentOp])
                        {
                            // Multiply
                            case 'x':
                                x *= y;
                                break;
                            // Divide
                            case '/':
                                x /= y;
                                break;
                            // Modulus
                            case '%':
                                x %= y;
                                break;
                            // Add
                            case '+':
                                x += y;
                                break;
                            // Subtract
                            case '-':
                                x -= y;
                                break;
                        }

                        // Put the result into the result string

                        // Get left side of equation
                        for (int m = 0; m <= j; m++)
                        {
                            hold += equation[m];
                        }
                        // Place answer in
                        hold += x.ToString();
                        // Get right side of equation
                        for (int m = k; m < equation.Length; m++)
                        {
                            hold += equation[m];
                        }
                        // Save result and restart loop
                        equation = hold;
                        boxBot = equation;
                        i = 0;
                    }

                    // If no symbol was equal to the current operation go to the next
                    if (i == equation.Length - 1)
                    {
                        currentOp++;
                        i = 0;
                    }
                }
                boxBot = equation;
                textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
            }

            // If any error occurs, it is most likely bc of formatting, tell the user
            catch (Exception ex)
            {
                boxBot = "Error! Check your Equation!";
                textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
            }
        }

        private void buttonNum1_Click(object sender, EventArgs e)
        {
            boxTop += "1";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNum2_Click(object sender, EventArgs e)
        {
            boxTop += "2";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNum3_Click(object sender, EventArgs e)
        {
            boxTop += "3";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNum4_Click(object sender, EventArgs e)
        {
            boxTop += "4";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNum5_Click(object sender, EventArgs e)
        {
            boxTop += "5";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNum6_Click(object sender, EventArgs e)
        {
            boxTop += "6";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNum7_Click(object sender, EventArgs e)
        {
            boxTop += "7";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNum8_Click(object sender, EventArgs e)
        {
            boxTop += "8";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNum9_Click(object sender, EventArgs e)
        {
            boxTop += "9";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }

        private void buttonNum0_Click(object sender, EventArgs e)
        {
            boxTop += "0";
            textBox1.Text = boxTop + Environment.NewLine + "-----------------------" + Environment.NewLine + boxBot;
        }        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
