using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calcr
{
    public partial class Form1 : Form
    {
        double firstNumber, secondNumber, solve; // Переменные
        int action; // Действие с числами
        bool checkAction = false; // Было ли совершено действие

        public Form1()
        {
            InitializeComponent();
        }

        private void checkAndDelBox()
        {
            if (checkAction == true && textBox2.Text != "")
            {
                textBox3.Text = textBox2.Text;
                textBox2.Clear();
                checkAction = false;
            }
        } 
        
        private void button1_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 9;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            checkAndDelBox();
            textBox1.Text += 0;
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            bool check = false;
            int i = 0;

            do
            {
                if (textBox1.Text == "")
                {
                    check = true;
                    break;
                }
                
                if (textBox1.Text[i] == '.')
                {
                    check = true;
                    break;
                }

                i++;
            } while (i < textBox1.Text.Length);

            if (check == false)
               textBox1.Text += ",";
        }

        private void buttonSubstr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text != "") //Проверяем нужно ли изменить знак действия или продолжить выполнение
            {
                char symb = textBox2.Text[textBox2.Text.Length - 1];
                if (symb == '+' || symb == '-' || symb == '/' || symb == '*')
                {
                    int numbersymbol = textBox2.Text.Length - 1;
                    textBox2.Text = textBox2.Text.Remove(numbersymbol) + "-";
                    action = 2; // Вычитание
                }
            } 
                
            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                firstNumber = double.Parse(textBox1.Text);
                textBox2.Text = textBox1.Text + "-";
                textBox1.Clear();
                action = 2; // Вычитание
            }
        }

        private void buttonMultipl_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text != "") //Проверяем есть ли записи в блоках
            {
                char symb = textBox2.Text[textBox2.Text.Length - 1];
                if (symb == '+' || symb == '-' || symb == '/' || symb == '*')
                {
                    int numbersymbol = textBox2.Text.Length - 1;
                    textBox2.Text = textBox2.Text.Remove(numbersymbol) + "*";
                    action = 3; // Умножение
                }
            }

            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                firstNumber = double.Parse(textBox1.Text);
                textBox2.Text = textBox1.Text + "*";
                textBox1.Clear();
                action = 3; // Умножение
            }
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text != "") //Проверяем есть ли записи в блоках
            {
                char symb = textBox2.Text[textBox2.Text.Length - 1];
                if (symb == '+' || symb == '-' || symb == '/' || symb == '*')
                {
                    int numbersymbol = textBox2.Text.Length - 1;
                    textBox2.Text = textBox2.Text.Remove(numbersymbol) + "/";
                    action = 4; // Деление
                }
            }

            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                firstNumber = double.Parse(textBox1.Text);
                textBox2.Text = textBox1.Text + "/";
                textBox1.Clear();
                action = 4; // Деление
            }
        }

        private void buttonDelet_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textNameSaved.Clear();
            checkAction = false;
            action = 0;
        }

        private async void buttonSaved_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string path = "Сохранённые данные.txt";
                string savedResult = $"Дата:\n{DateTime.Now}\nИмя:\n{textNameSaved.Text}\nРезультат:\n{textBox2.Text}\n ";

                using (FileStream fileStream = new FileStream(path, FileMode.Append))
                {
                    byte[] buffer = Encoding.Default.GetBytes(savedResult);
                    await fileStream.WriteAsync(buffer, 0, buffer.Length);
                }
                char lastChar = textBox2.Text[textBox2.Text.Length - 1];
                if (lastChar != 'р')
                    textBox2.Text += " Сохр";
            }
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                secondNumber = double.Parse(textBox1.Text);

                switch (action)
                {
                    case 1:
                        solve = firstNumber + secondNumber;
                        checkAction = true;
                        break;
                    case 2:
                        solve = firstNumber - secondNumber;
                        checkAction = true;
                        break;
                    case 3:
                        solve = firstNumber * secondNumber;
                        checkAction = true;
                        break;
                    case 4:
                        solve = firstNumber / secondNumber;
                        checkAction = true;
                        break;
                    default:
                        break;
                }
                textBox2.Text += secondNumber + "=" + solve;
                textBox1.Clear();
                action = 0;
            }
        }

        private void buttonAddit_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text != "") //Проверяем есть ли записи в блоках
            {
                char symb = textBox2.Text[textBox2.Text.Length - 1];
                if (symb == '+' || symb == '-' || symb == '/' || symb == '*')
                {
                    int numbersymbol = textBox2.Text.Length - 1;
                    textBox2.Text = textBox2.Text.Remove(numbersymbol) + "+";
                    action = 1; // Сложение
                }
            }

            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                firstNumber = double.Parse(textBox1.Text);
                textBox2.Text = textBox1.Text + "+";
                textBox1.Clear();
                action = 1; // Сложение
            }
        }
    }
}
