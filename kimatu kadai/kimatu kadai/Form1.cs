using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private string enzanshi;
        private double num1;
        private double num2;



        public Form1()
        {
            InitializeComponent();
        }


        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
        }


        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void Operator(object sender, EventArgs e)
        {
            Button btn = (Button)sender;


            if (textBox1.Text != "")
            {
                if(textBox2.Text.EndsWith("+")||textBox2.Text.EndsWith("-")
             ||textBox2.Text.EndsWith("×")||textBox2.Text.EndsWith("÷"))
                {
                    // 連続計算
                    num2 = Convert.ToDouble(textBox1.Text);
                    switch (enzanshi)
                    {
                        case "+": num1 = num1 + num2; break;
                        case "-": num1 = num1 - num2; break;
                        case "×": num1 = num1 * num2; break;
                        case "÷":
                            if (num2 == 0)
                            {
                                textBox1.Text = "Error";
                                return;
                            }
                            num1 = num1 / num2;
                            break;
                    }
                }
                else
                {
                    // 1回目の演算
                    num1 = Convert.ToDouble(textBox1.Text);
                }

                enzanshi = btn.Text;
                textBox2.Text = num1.ToString() + btn.Text;
                textBox1.Text = "";
            }
        }



        private void dott_Click(object sender, EventArgs e)
        {  //小数点を複数押せないようにする.

            if (!textBox1.Text.Contains("."))
            {
                if (textBox1.Text == "")
                {
                    textBox1.Text = "0.";

                }
                else
                {
                    textBox1.Text = textBox1.Text + ".";
                }
            }
        }

        private void Backspace(object sender, EventArgs e)
        {  //数値がないのにバックスペースを押したときに発生する例外を阻止.
            if (textBox1.Text != string.Empty)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

            }

        }
        private void Shisokuenzan()
        {

            if (textBox1.Text != "")
            {
                num2 = Convert.ToDouble(textBox1.Text);
                switch (enzanshi)
                {
                    case "+": textBox1.Text = Convert.ToString(num1 + num2); break;
                    case "-": textBox1.Text = Convert.ToString(num1 - num2); break;
                    case "×": textBox1.Text = Convert.ToString(num1 * num2); break;
                    case "÷":
                        if (num2 == 0)
                        {
                            textBox1.Text = "Error";
                        }
                        else
                        {
                            textBox1.Text = Convert.ToString(num1 / num2);
                        }
                        break;

                }
                textBox2.Text = "";
                enzanshi = null;
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Shisokuenzan();
        }
        private void Subetteru()
        {
            if (textBox1.Text == "4545" || textBox1.Text == "1919")
            {
                MessageBox.Show("君、すべってるよ。");
                textBox1.Text = "";
                Application.Exit();
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            Subetteru();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
