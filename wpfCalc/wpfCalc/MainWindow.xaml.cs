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
        double result = 0;
        string operation = "";
        bool enteringValue = false; //TODO: rename isAppending



        public MainWindow() {
            InitializeComponent();
            Reset();
        }

        #region numbers
        private void btnNumber0_Click(object sender, RoutedEventArgs e) {
            if (enteringValue) 
                txtDisplay.Text = "0";
            else if (txtDisplay.Text != "0") 
                txtDisplay.Text += "0";
        }

        private void btnNumber1_Click(object sender, RoutedEventArgs e) {
            addNumberToDisplay(1);
        }

        private void btnNumber2_Click(object sender, RoutedEventArgs e) {
            addNumberToDisplay(2);
        }

        private void btnNumber3_Click(object sender, RoutedEventArgs e) {
            addNumberToDisplay(3);
        }

        private void btnNumber4_Click(object sender, RoutedEventArgs e) {
            addNumberToDisplay(4);
        }

        private void btnNumber5_Click(object sender, RoutedEventArgs e) {
            addNumberToDisplay(5);
        }

        private void btnNumber6_Click(object sender, RoutedEventArgs e) {
            addNumberToDisplay(6);
        }

        private void btnNumber7_Click(object sender, RoutedEventArgs e) {
            addNumberToDisplay(7);
        }

        private void btnNumber8_Click(object sender, RoutedEventArgs e) {
            addNumberToDisplay(8);
        }

        private void btnNumber9_Click(object sender, RoutedEventArgs e) {
            addNumberToDisplay(9);
        }
        private void btnDot_Click(object sender, RoutedEventArgs e) {
            if (!txtDisplay.Text.Contains(".")){
                txtDisplay.Text += ".";
            }
        }

        #endregion

        #region math operations

        private void btnPlus_Click(object sender, RoutedEventArgs e) {
            addOperation("+");
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e) {
            addOperation("-");
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e) {
            addOperation("*");
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e) {
            addOperation("/");
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e) {
            switch (operation){
                case "+":
                    txtDisplay.Text = (result + getDisplayValue()).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - getDisplayValue()).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (result * getDisplayValue()).ToString();
                    break;
                case "/":
                    if (txtDisplay.Text == "0") {
                        txtDisplay.Text = "Error";
                    }
                    else
                        txtDisplay.Text = (result / getDisplayValue()).ToString();
                    break;
                default:
                    break;
            }
            result = getDisplayValue();
            txtRegister.Text = "";
            operation = "";
            enteringValue = true;
        }
        private void btnPlusMinus_Click(object sender, RoutedEventArgs e) {
            if (txtDisplay.Text == "0") return;

            if (!txtDisplay.Text.StartsWith("-"))
                txtDisplay.Text = $"-{txtDisplay.Text}";
            else
                txtDisplay.Text = txtDisplay.Text.TrimStart('-');
        }

        #endregion

        #region clear operaions

        private void btnClearEntry_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = "0";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            Reset();
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e) {
            if(txtDisplay.Text != "0") {
                if (txtDisplay.Text.Length == 1)
                    txtDisplay.Text = "0";
                else
                    txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }

        }

        #endregion

        #region utility functions

        void addNumberToDisplay(int number) {
            if (number < 1 || number > 9) return;

            if(enteringValue)
                txtDisplay.Text = "";
            txtDisplay.Text += number.ToString();
            enteringValue = false;
        }
        void addOperation(string op) {
            operation = op;
            result = double.Parse(txtDisplay.Text);
            txtRegister.Text = $"{result} {operation}";
            txtDisplay.Text = result.ToString();
            enteringValue = true;
        }
        double getDisplayValue() {
            return double.Parse(txtDisplay.Text);
        }
        void Reset() {
            operation = "";
            enteringValue = true;
            result = 0;
            txtDisplay.Text = "0";
            txtRegister.Text = "";
            txtHistory.Text = "";
        }

        #endregion

    }
}
