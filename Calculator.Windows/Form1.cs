using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Calculator.Logic;

namespace Calculator.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += "0";
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"Receieved {e.KeyCode}");

            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    {
                        button0_Click(sender, e);
                        break;
                    }
                case Keys.D1:
                case Keys.NumPad1:
                    {
                        button1_Click(sender, e);
                        break;
                    }
                case Keys.D2:
                case Keys.NumPad2:
                    {
                        button2_Click(sender, e);
                        break;
                    }
                case Keys.D3:
                case Keys.NumPad3:
                    {
                        button3_Click(sender, e);
                        break;
                    }
                case Keys.D4:
                case Keys.NumPad4:
                    {
                        button4_Click(sender, e);
                        break;
                    }
                case Keys.D5:
                case Keys.NumPad5:
                    {
                        button5_Click(sender, e);
                        break;
                    }
                case Keys.D6:
                case Keys.NumPad6:
                    {
                        button6_Click(sender, e);
                        break;
                    }
                case Keys.D7:
                case Keys.NumPad7:
                    {
                        button7_Click(sender, e);
                        break;
                    }
                case Keys.D8:
                    {
                        if (e.Shift)
                        {
                            // Multiply
                            btnMul_Click(sender, e);
                        }
                        else
                        {
                            button8_Click(sender, e);
                        }

                        break;
                    }
                case Keys.NumPad8:
                    {
                        button8_Click(sender, e);
                        break;
                    }
                case Keys.D9:
                case Keys.NumPad9:
                    {
                        button9_Click(sender, e);
                        break;
                    }
                case Keys.Add:
                    {
                        btnAdd_Click(sender, e);
                        break;
                    }
                case Keys.Oemplus:
                    {
                        if (e.Shift)
                        {
                            // Addition
                            btnAdd_Click(sender, e);
                        }
                        else
                        {
                            // Equals
                            btnEq_Click(sender, e);
                        }

                        break;
                    }
                case Keys.Subtract:
                case Keys.OemMinus:
                    {
                        btnSub_Click(sender, e);
                        break;
                    }
                case Keys.Enter:
                    {
                        btnEq_Click(sender, e);
                        break;
                    }
                case Keys.Divide:
                    {
                        btnDiv_Click(sender, e);
                        break;
                    }
                case Keys.Multiply:
                    {
                        btnMul_Click(sender, e);
                        break;
                    }
                default:
                    {
                        // Do Nothing
                        break;
                    }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += " + ";
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += " - ";
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += " * ";
        }

        private void btnEq_Click(object sender, EventArgs e)
        {
            // Convert to RPN
            string rpn = Parser.ConvertToRPN(this.tbInput.Text);
            this.tbHistory.Text += rpn + Environment.NewLine;

            // Evaluate RPN
            double result = Evaluate.EvaluateRPN(rpn);

            this.tbInput.Text = result.ToString();
        }

        private void btnExpo_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += " ^ ";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool wasHandled = false;

            if (keyData == Keys.Enter)
            {
                // Consume the Enter Key so it does not simulate a click
                wasHandled = true;
            }

            return wasHandled;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            this.tbInput.Text += " / ";
        }
    }

}
