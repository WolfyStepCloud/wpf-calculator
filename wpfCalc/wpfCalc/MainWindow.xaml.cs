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

namespace wpfCalc {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        double number1 = 0;
        double number2 = 0;
        string operation = "";
        public MainWindow() {
            InitializeComponent();
        }

        private void btnNumber0_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(0).ToString();
        }

        private void btnNumber1_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(1).ToString();
        }

        private void btnNumber2_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(2).ToString();
        }

        private void btnNumber3_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(3).ToString();
        }

        private void btnNumber4_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(4).ToString();
        }

        private void btnNumber5_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(5).ToString();
        }

        private void btnNumber6_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(6).ToString();
        }

        private void btnNumber7_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(7).ToString();
        }

        private void btnNumber8_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(8).ToString();
        }

        private void btnNumber9_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = ReturnNumber(9).ToString();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e) {
            operation = "+";
            txtDisplay.Text = "0";
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e) {
            operation = "-";
            txtDisplay.Text = "0";
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e) {
            operation = "*";
            txtDisplay.Text = "0";
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e) {
            operation = "/";
            txtDisplay.Text = "0";
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e) {
            switch (operation) {
                case "+":
                    txtDisplay.Text = (number1 + number2).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (number1 - number2).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (number1 * number2).ToString();
                    break;
                case "/":
                    if(number2 != 0)
                        txtDisplay.Text = (number1 / number2).ToString();
                    else
                        txtDisplay.Text = "Error";
                    break;

            }
        }

        private void btnClearEntry_Click(object sender, RoutedEventArgs e) {
            if (operation == "")
                number1 = 0;
            else
                number2 = 0;
            txtDisplay.Text = "0";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            number1 = number2 = 0;
            operation = "";
            txtDisplay.Text = "0";
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e) {
            if (operation == "") {
                number1 = (number1 / 10);
                txtDisplay.Text = number1.ToString();
            } else {
                number2 = (number1 / 10);
                txtDisplay.Text = number2.ToString();
            }
        }

        private void btnPlusMinus_Click(object sender, RoutedEventArgs e) {
            if (operation == "") {
                number1 *= -1;
                txtDisplay.Text = number1.ToString();
            } else {
                number2 *= -1;
                txtDisplay.Text = number2.ToString();
            }
        }
        double ReturnNumber(int btnNumber) {
            if (btnNumber >= 0) {
                if (operation == "") {
                    return (number1 * 10) + btnNumber;
                } else {
                    return (number2 * 10) + btnNumber;
                }
            }
            return 0;
        }
    }
}
