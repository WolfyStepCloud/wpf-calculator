using System.Windows;

namespace wpfCalc {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        double result;
        string operation;
        bool isAppending;
        bool valueChanged;

        string leftPart, rightPart;

        public MainWindow() {
            InitializeComponent();
            Reset();
        }

        #region numbers
        private void btnNumber0_Click(object sender, RoutedEventArgs e) {
            if (isAppending)
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
            if (!txtDisplay.Text.Contains(",")) {
                txtDisplay.Text += ",";
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

        private void btnReciprocal_Click(object sender, RoutedEventArgs e) {
            addOperation("reciproc");
        }
        private void btnSquareRoot_Click(object sender, RoutedEventArgs e) {
            addOperation("sqrt");
        }
        private void btnEqual_Click(object sender, RoutedEventArgs e) {
            leftPart = txtRegister.Text;
            txtRegister.Text = "";
            switch (operation) {
                case "+":
                    txtDisplay.Text = (result + getDisplayValue()).ToString();
                    rightPart = txtDisplay.Text;
                    break;
                case "-":
                    txtDisplay.Text = (result - getDisplayValue()).ToString();
                    rightPart = txtDisplay.Text;
                    break;
                case "*":
                    txtDisplay.Text = (result * getDisplayValue()).ToString();
                    rightPart = txtDisplay.Text;
                    break;
                case "/":
                    if (txtDisplay.Text == "0") {
                        txtDisplay.Text = "Error";
                    } else {
                        txtDisplay.Text = (result / getDisplayValue()).ToString();
                        rightPart = txtDisplay.Text;
                    }
                    break;
                case "reciproc":
                    if (txtDisplay.Text == "0") {
                        txtDisplay.Text = "Error";
                    } else {
                        txtDisplay.Text = (1 / getDisplayValue()).ToString();
                        rightPart = txtDisplay.Text;
                    }
                    break;
                case "sqrt":
                    if (txtDisplay.Text == "0") {
                        txtDisplay.Text = "Error";
                    } else {
                        txtDisplay.Text = (1 / getDisplayValue()).ToString();
                        rightPart = txtDisplay.Text;
                    }
                    break;
                default:
                    break;
            }
            result = getDisplayValue();
            operation = "";
            isAppending = false;
            txtHistory.Text = $"{leftPart} {rightPart} = {txtDisplay.Text}";
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
            if (txtDisplay.Text != "0") {
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

            if (isAppending)
                txtDisplay.Text += number.ToString();
            else
                txtDisplay.Text = number.ToString();

            isAppending = true;
        }
        void addOperation(string op) {
            operation = op;
            result = double.Parse(txtDisplay.Text);

            if (operation.Equals("sqrt") || operation.Equals("reciproc")) {
                txtRegister.Text = $"{operation}({result})";
            } else
                txtRegister.Text += $"{result} {operation} ";
            txtDisplay.Text = result.ToString();
            isAppending = false;
            leftPart = txtDisplay.Text;

        }
        double getDisplayValue() {
            return double.Parse(txtDisplay.Text);
        }

        void Reset() {
            operation = "";
            isAppending = false;
            valueChanged = false;
            result = 0;
            txtDisplay.Text = "0";
            txtRegister.Text = "";
            txtHistory.Text = "";
            leftPart = "";
            rightPart = "";
        }

        #endregion

    }
}
