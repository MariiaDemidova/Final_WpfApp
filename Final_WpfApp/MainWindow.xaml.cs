using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Final_WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double firstNum;
        public double secondNum;
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in ButtonGrid.Children)
            {
                Button buttn = (Button)el;
                buttn.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string add = btn.Content.ToString();
            if(add == "+" || add == "-" || add == "/" || add == "*")
            {
                if (Result.Text.Contains("+") || Result.Text.Contains("-") || Result.Text.Contains("/") || Result.Text.Contains("*"))
                {
                    Calculate1();
                    StartCalculate();
                    Result.Text += add;
                }
                else
                {
                    StartCalculate();
                    Result.Text += add;
                }
                //StartCalculate();
                //Result.Text += add;
            }
            else if (add == "=")
            {
                Calculate1();
            }
            else if(add == "C")
            {
                Result.Text = null;
            }
            else if (add == "√x")
            {
                if (Result.Text.Contains("+") || Result.Text.Contains("-") || Result.Text.Contains("/") || Result.Text.Contains("*"))
                {
                    Calculate1();
                    Result.Text = Math.Sqrt(Convert.ToDouble(Result.Text)).ToString();
                }
                else
                {
                    StartCalculate();
                    Result.Text = Math.Sqrt(firstNum).ToString();
                }
            }
            else if (add == "x²")
            {
                if (Result.Text.Contains("+") || Result.Text.Contains("-") || Result.Text.Contains("/") || Result.Text.Contains("*"))
                {
                    Calculate1();
                    Result.Text = Math.Pow(Convert.ToDouble(Result.Text), 2).ToString();
                }
                else
                {
                    StartCalculate();
                    Result.Text = Math.Pow(firstNum, 2).ToString();
                }
            }
            else if (add == "⇐")
            {
                if (Result.Text.Length!=0)
                {
                    Result.Text = Result.Text.Remove(Result.Text.Length-1);
                }
            }
            else
            {
                Result.Text += add;
            }
        }

        private void StartCalculate()
        {
            firstNum = Convert.ToDouble(Result.Text);
        }

        private void Calculate1()
        {
                if(Result.Text.Contains("+"))
                {
                    string calculate = Result.Text.Remove(0,Result.Text.IndexOf("+"));
                    secondNum = Convert.ToDouble(calculate);
                    Result.Text = (firstNum + secondNum).ToString();
                }
                else if (Result.Text.Contains("-"))
                {
                    string calculate = Result.Text.Remove(0, Result.Text.IndexOf("-"));
                    secondNum = Convert.ToDouble(calculate);
                    Result.Text = (firstNum - secondNum).ToString();

                }
                else if (Result.Text.Contains("/"))
                {
                    string calculate = Result.Text.Remove(0, Result.Text.IndexOf("/"));
                    secondNum = Convert.ToDouble(calculate);
                    Result.Text = (firstNum / secondNum).ToString();
                }
                else if (Result.Text.Contains("*"))
                {
                    string calculate = Result.Text.Remove(0, Result.Text.IndexOf("*"));
                    secondNum = Convert.ToDouble(calculate);
                    Result.Text = (firstNum * secondNum).ToString();
                }
        }
        }
    }
