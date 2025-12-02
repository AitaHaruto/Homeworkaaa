using System;
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
        private void Operator(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            if(textBox1.Text!="")
            {
                    num1=Convert.ToDouble(textBox1.Text);
                    textBox2.Text = textBox1.Text + btn.Text;
                    textBox1.Text = "";
                    enzanshi = btn.Text;

            }
        }

       
        private void dott_Click(object sender, EventArgs e)
        {  //小数点を複数押せないようにする.
           
            if (!textBox1.Text.Contains("."))
            {
               if(textBox1.Text=="")
                {
                     textBox1.Text="0.";  

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
            //ここに演算処理を書いてください.
            if (enzanshi == "+")
            {
                textBox1.Text = $"{num1 + num2}";

            }
           else if (enzanshi == "-")
            {
                textBox1.Text = $"{num1 - num2}";

            }
            else if(enzanshi == "×")
            {
                textBox1.Text = $"{num1 * num2}";
            }
            else if (enzanshi == "/")
            {
                textBox1.Text = $"{num1 / num2}";
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
            if(textBox1.Text=="4545"||textBox1.Text=="1919")
             {
                MessageBox.Show("君、すべってるよ。");
                textBox1.Text="";
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
