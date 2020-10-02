using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "0";
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
                            ;
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
                case Keys.Oemplus:
                    {
                        if (e.Shift)
                        {
                            // Addition
                            btnAdd_Click(sender, e);
                        }

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
            this.textBox1.Text += "+";
        }
    }

}
