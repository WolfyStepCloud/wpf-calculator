using System.Windows;

namespace wpfCalc {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        double register;
        string operation;
        bool valueChanged;
        bool isError;
        /*
         * TODO:
         * make register 
         * 
         * onOperationArif_Click:
         *      store displayValue into register
         *      show in txtReg register value and operation sign
         *      show in txtDisplay register value
         *      if last operation is / and the displayValue is zero, then isError = true
         * if isError:
         *      C clears
         *      CE also clears
         * sqrt and reciproc:
         *      sqrt:
         *          if(value < 0) isError = true;
         *      reciproc:
         *          if(value == 0) isError = true;
         *      
         *      store the value in register
         *      show in txtRegister "operation(txtDisplayValue)"
         *      show in txtDisplay register value
         * percent:
         *      percent of reg
         * history:
         *      if(isError) return;
         *      
         *      register = register (operation) txtDisplay;
         *      txtReg (txtDisplay.Text) = register
         */

        public MainWindow() {
            InitializeComponent();
            Reset();
        }

        #region numbers
        private void btnNumber0_Click(object sender, RoutedEventArgs e) {
            if (valueChanged)
                txtDisplay.Text += "0";
            else if (!txtDisplay.Text.Equals("0"))
                txtDisplay.Text = "0";
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
            } else if (!valueChanged)
                txtDisplay.Text = "0,";
        }

        #endregion

        #region math operations

        private void btnPlus_Click(object sender, RoutedEventArgs e) {
            addArifOperation("+");
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e) {
            addArifOperation("-");
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e) {
            addArifOperation("*");
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e) {
            addArifOperation("/");
        }

        private void btnReciprocal_Click(object sender, RoutedEventArgs e) {
        }
        private void btnSquareRoot_Click(object sender, RoutedEventArgs e) {
        }
        private void btnEqual_Click(object sender, RoutedEventArgs e) {
            
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

            if(!valueChanged || isError) {
                txtDisplay.Text = number.ToString();
                valueChanged = true;
            }else
                txtDisplay.Text += number.ToString();
        }
        void addArifOperation(string op) {
            if (operation.Equals("/") && txtDisplay.Text.Equals(0)) {
                txtDisplay.Text = "Error";
                isError = true;
            } else if (valueChanged) {
                txtRegister.Text += $" {txtDisplay.Text} {op}";
            } else {
                txtRegister.Text = txtRegister.Text.Remove(txtRegister.Text.Length - 1, 1) + op;
            }
            operation = op;
            valueChanged = false;
        }
        double getDisplayValue() {
            return double.Parse(txtDisplay.Text);
        }
        void Reset() {
            operation = "";
            valueChanged = false;
            isError = false;
            register = 0;
            txtDisplay.Text = "0";
            txtRegister.Text = "";
            txtHistory.Text = "";
        }

        #endregion

    }
}
