using System;
using System.Windows;

namespace wpfCalc {
    /// <summary>
    /// Calculator
    /// </summary>
    public partial class MainWindow : Window {
        double register;
        string operation;
        bool insertionStarted;  //is not appending
        bool isError;
        bool complexUsed;

        public MainWindow() {
            InitializeComponent();
            Reset();
        }

        #region numbers
        private void btnNumber0_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                if (!insertionStarted) {
                    txtDisplay.Text = "0";
                    insertionStarted = true;
                } else if (!txtDisplay.Text.Equals("0")) {
                    txtDisplay.Text += "0";
                }
            }

        }

        private void btnNumber1_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddNumberToDisplay(1);
        }

        private void btnNumber2_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddNumberToDisplay(2);
        }

        private void btnNumber3_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddNumberToDisplay(3);
        }

        private void btnNumber4_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddNumberToDisplay(4);
        }

        private void btnNumber5_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddNumberToDisplay(5);
        }

        private void btnNumber6_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddNumberToDisplay(6);
        }

        private void btnNumber7_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddNumberToDisplay(7);
        }

        private void btnNumber8_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddNumberToDisplay(8);
        }

        private void btnNumber9_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddNumberToDisplay(9);
        }
        private void btnDot_Click(object sender, RoutedEventArgs e) {
            if (!txtDisplay.Text.Contains(",")) {
                if (!insertionStarted) {
                    txtDisplay.Text = "0,";
                    insertionStarted = true;
                } else
                    txtDisplay.Text += ",";
            }
        }

        #endregion

        #region math operations

        private void btnPlus_Click(object sender, RoutedEventArgs e) {
            if(!isError)
                AddArifOperation("+");
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddArifOperation("-");
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddArifOperation("*");
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddArifOperation("/");
        }

        private void btnReciprocal_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddComplexOperation("reciproc");
        }
        private void btnSquareRoot_Click(object sender, RoutedEventArgs e) {
            if (!isError) AddComplexOperation("sqrt");
        }
        private void btnPercent_Click(object sender, RoutedEventArgs e) {
            if (!isError) PercentOperation();
        }
        private void btnEqual_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                txtHistory.Text = $"{txtRegister.Text} {txtDisplay.Text} = {register + double.Parse(txtDisplay.Text)}";
                txtRegister.Text = "";
                txtDisplay.Text = "0";
                register = 0;
            }
        }
        private void btnPlusMinus_Click(object sender, RoutedEventArgs e) {
            if (!isError && !complexUsed) {
                if (txtDisplay.Text == "0") return;

                if (!txtDisplay.Text.StartsWith("-"))
                    txtDisplay.Text = $"-{txtDisplay.Text}";
                else
                    txtDisplay.Text = txtDisplay.Text.TrimStart('-');
                insertionStarted = true;
            }
        }

        #endregion

        #region clear operations

        private void btnClearEntry_Click(object sender, RoutedEventArgs e) {
            if (!isError) {
                txtDisplay.Text = "0";
                insertionStarted = true;
            } else
                Reset();
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

        void AddNumberToDisplay(int number) {
            if (number < 1 || number > 9)
                throw new ArgumentOutOfRangeException($"Number {nameof(number)} is of of range of 1 to 9");

            if (isError) {
                txtDisplay.Text = number.ToString();
                isError = false;
                insertionStarted = true;
            } else if (txtDisplay.Text.Equals("0") || !insertionStarted) {
                txtDisplay.Text = number.ToString();
                insertionStarted = true;
            } else
                txtDisplay.Text += number.ToString();
        }
        void AddArifOperation(string op) {
            if (string.IsNullOrWhiteSpace(op))
                throw new ArgumentNullException($"String {nameof(op)} is empty.");

            if (insertionStarted) {
                if (operation != "") {
                    if (!(operation.Equals("/") && txtDisplay.Text.Equals("0"))) {
                        double displayValue = GetDisplayValue();
                        txtRegister.Text += $" {Math.Round(displayValue, 4)} {op}";

                        if (Calculate(register, displayValue, operation, out double result)) {
                            txtDisplay.Text = Math.Round(result, 4).ToString();
                            register = result;
                        } else {
                            MakeError();
                            return;
                        }
                    } else {
                        MakeError();
                        return;
                    }
                } else {
                    double displayValue = GetDisplayValue();
                    txtRegister.Text += $" {Math.Round(displayValue, 4)} {op}";
                    register = displayValue;
                }
                insertionStarted = false;
            } else {
                if (txtRegister.Text.Length != 0) {
                    if (complexUsed)
                        txtRegister.Text = txtRegister.Text + " " + op;
                    else
                        txtRegister.Text = txtRegister.Text.Remove(txtRegister.Text.Length - 1, 1) + op;
                } else {
                    double displayValue = GetDisplayValue();
                    txtRegister.Text += $"{Math.Round(displayValue, 4)} {op}";
                    if (operation.Equals("/") && txtDisplay.Text.Equals("0")) {
                        MakeError();
                        return;
                    }
                }
            }
            txtDisplay.Text = Math.Round(register, 4).ToString();
            operation = op;
            complexUsed = false;
        }
        void AddComplexOperation(string op) {
            if (!complexUsed) {
                if (string.IsNullOrWhiteSpace(op))
                    throw new ArgumentNullException($"String {nameof(op)} is empty.");

                double displayValue = GetDisplayValue();
                switch (op) {
                    case "sqrt":
                        if (displayValue < 0)
                            MakeError();
                        register = Math.Sqrt(displayValue);
                        break;
                    case "reciproc":
                        if (displayValue == 0)
                            MakeError();
                        register = 1 / displayValue;
                        break;
                    default: return;
                }
                txtRegister.Text += $" {op}({Math.Round(displayValue, 4)})";
                txtDisplay.Text = Math.Round(register, 4).ToString();
                insertionStarted = false;
                complexUsed = true;
            }
        }
        void PercentOperation() {
            if (!complexUsed) {
                register = (GetDisplayValue() / 100) * register;
                txtRegister.Text += $" {Math.Round(register, 4)}";
                txtDisplay.Text = $"{Math.Round(register, 4)}";
                insertionStarted = false;
                complexUsed = true;
            }
        }
        double GetDisplayValue() {
            return double.Parse(txtDisplay.Text);
        }

        void MakeError() {
            isError = true;
            txtDisplay.Text = "Error";
            insertionStarted = false;
        }
        bool Calculate(double firstValue, double secondValue, string operation, out double result) {
            if (string.IsNullOrWhiteSpace(operation))
                throw new ArgumentNullException($"Operation string {nameof(operation)} is empty.");
            result = 0;
            switch (operation) {
                case "+":
                    result = firstValue + secondValue;
                    break;
                case "-":
                    result = firstValue - secondValue;
                    break;
                case "*":
                    result = firstValue * secondValue;
                    break;
                case "/":
                    if (secondValue == 0)
                        return false;

                    result = firstValue / secondValue;
                    break;
                default: return false;
            }
            return true;
        }

        void Reset() {
            operation = "";
            insertionStarted = false;
            isError = false;
            register = 0;
            txtDisplay.Text = "0";
            txtRegister.Text = "";
            txtHistory.Text = "";
            complexUsed = false;
        }

        #endregion

        private void btnClose(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
