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
        private void AdjustFontSize(TextBox tb)
        {
            using (Graphics g = tb.CreateGraphics())
            {
                // 現在のフォントサイズから開始
                float fontSize = tb.Font.Size;
                SizeF textSize = g.MeasureString(tb.Text, tb.Font);

                // テキストが幅を超えている間、フォントサイズを縮小
                while (textSize.Width > tb.Width && fontSize > 8) // 最小サイズを 8pt に設定
                {
                    fontSize -= 0.5f;
                    tb.Font = new Font(tb.Font.FontFamily, fontSize);
                    textSize = g.MeasureString(tb.Text, tb.Font);
                }
            }
        }

     
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (textBox1.Text.Contains("E"))
            {
                textBox1.Text = "";
                textBox2.Text = "";
                num1 = 0;
                num2 = 0;
            }
            textBox1.Text += btn.Text;

        }


        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Font= new Font(textBox1.Font.FontFamily, 40);
            textBox2.Font = new Font(textBox2.Font.FontFamily, 25);
            num1 = 0;
            num2 = 0;


        }
        private void Operator(object sender, EventArgs e)
        {
            Button btn = (Button)sender;


            if (textBox1.Text != "")
            {
                if(textBox2.Text!=""
                 &&(textBox2.Text.EndsWith("+")
                 ||textBox2.Text.EndsWith("-")
                 ||textBox2.Text.EndsWith("×")
                 ||textBox2.Text.EndsWith("÷")))
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
                    if (textBox1.Text.Contains("E"))
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        num1 = 0;
                        num2 = 0;
                    }
                    else 
                    {
                        // 1回目の演算
                        num1 = Convert.ToDouble(textBox1.Text);
                    }
                        
                }

                enzanshi = btn.Text;
                textBox2.Text = num1.ToString() + btn.Text;
                textBox1.Text = "";
                textBox1.Font = new Font(textBox1.Font.FontFamily, 40);
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

                if (textBox1.TextLength == 8)
                {
                    textBox1.Font = new Font(textBox1.Font.FontFamily, 40);
                }
                else if (textBox1.Font.Size != 40)
                {
                    float newSize = textBox1.Font.Size + 1.0f;

                    textBox1.Font = new Font(textBox1.Font.FontFamily, newSize);
                }

            }
            else if (textBox1.Text == string.Empty
                  && textBox2.Text != string.Empty)
            {
                textBox1.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                textBox2.Text = "";




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
            if (textBox1.Text == "4545" || textBox1.Text == "1919"|| textBox1.Text == "081"|| textBox1.Text == "072")
            {
                textBox2.Text = "滑ってるやつに";
                textBox1.Text ="使われるのしんどいわ～";
                MessageBox.Show("君、すべってるよ。");
                Application.Exit();
                
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            AdjustFontSize(textBox1);
            Subetteru();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AdjustFontSize(textBox2);
        }


    }
}
