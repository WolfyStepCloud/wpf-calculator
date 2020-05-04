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
        long number1;
        long number2;
        string operation;
        bool isError;
        public MainWindow() {
            InitializeComponent();
            Reset();
        }

        #region numbers
        private void btnNumber0_Click(object sender, RoutedEventArgs e) {
            if(!isError) 
                txtDisplay.Text = ReturnNumber(0).ToString();
        }

        private void btnNumber1_Click(object sender, RoutedEventArgs e) {
            if (!isError)
                txtDisplay.Text = ReturnNumber(1).ToString();
        }

        private void btnNumber2_Click(object sender, RoutedEventArgs e) {
            if (!isError)
                txtDisplay.Text = ReturnNumber(2).ToString();
        }

        private void btnNumber3_Click(object sender, RoutedEventArgs e) {
            if (!isError)
                txtDisplay.Text = ReturnNumber(3).ToString();
        }

        private void btnNumber4_Click(object sender, RoutedEventArgs e) {
            if (!isError)
                txtDisplay.Text = ReturnNumber(4).ToString();
        }

        private void btnNumber5_Click(object sender, RoutedEventArgs e) {
            if (!isError)
                txtDisplay.Text = ReturnNumber(5).ToString();
        }

        private void btnNumber6_Click(object sender, RoutedEventArgs e) {
            if (!isError)
                txtDisplay.Text = ReturnNumber(6).ToString();
        }

        private void btnNumber7_Click(object sender, RoutedEventArgs e) {
            if (!isError)
                txtDisplay.Text = ReturnNumber(7).ToString();
        }

        private void btnNumber8_Click(object sender, RoutedEventArgs e) {
            if (!isError)
                txtDisplay.Text = ReturnNumber(8).ToString();
        }

        private void btnNumber9_Click(object sender, RoutedEventArgs e) {
            if (!isError)
                txtDisplay.Text = ReturnNumber(9).ToString();
        }

        #endregion

        #region math operations

        private void btnPlus_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                txtDisplay.Text = "+";
                operation = "+";
            }
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                operation = "-";
                txtDisplay.Text = "-";
            }
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                operation = "*";
                txtDisplay.Text = "*";
            }
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                operation = "/";
                txtDisplay.Text = "/";
            }
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
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
                        if (number2 != 0)
                            txtDisplay.Text = (number1 / number2).ToString();
                        else {
                            txtDisplay.Text = "Error";
                            isError = true;
                        }
                        break;
                }
            }
        }
        private void btnPlusMinus_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                if (operation == "") {
                    number1 *= -1;
                    txtDisplay.Text = number1.ToString();
                } else {
                    number2 *= -1;
                    txtDisplay.Text = number2.ToString();
                }
            }
        }

        #endregion

        #region clear operaions

        private void btnClearEntry_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                if (operation == "")
                    number1 = 0;
                else
                    number2 = 0;
                txtDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            Reset();
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                if (operation == "") {
                    number1 = (number1 / 10);
                    txtDisplay.Text = number1.ToString();
                } else {
                    number2 = (number1 / 10);
                    txtDisplay.Text = number2.ToString();
                }
            }
        }

        #endregion

        #region utility functions

        double ReturnNumber(int btnNumber) {
            if (btnNumber >= 0 && btnNumber <= 9) {
                if (operation == "") {
                    return number1 = (number1 * 10) + btnNumber;
                } else {
                    return number2 = (number2 * 10) + btnNumber;
                }
            }
            return 0;
        }
        void Reset() {
            number1 = 0;
            number2 = 0;
            operation = "";
            isError = false;
            txtDisplay.Text = "0";

        }

        #endregion
    }
}
