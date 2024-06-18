//////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer   Description of change
// 1-19-2022    kriner      Initial creation of file and initial testing
// 1-29-2022    kriner      Creation of all button click methods, documentation of program, final testing
//
// Code in Form1.cs attributed to Charles Costarella in 1-19-2022 and 1-20-2022 lectures
//
// The Form1 program handles the occurrence of different events in the forms of button clicks on the calculator. 
// The events are received from the sender and then handled in seperate ways based on which event (or button click)
// has occurred. The handlers are grouped by number buttons (0-9) and operation buttons (+, -, *, /) with unique
// handlers for the clear entry, clear, decimal, sign, back, and equals buttons. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// the namespace for the Calculator program
namespace Calculator
{
    // declaration of the partial class that holds the Form1 program
    public partial class Form1 : Form
    {
        private string mathOperation = string.Empty; // math operation (i.e. "+", "-", "x", "/") initialized as empty
        private double leftOperand = 0.0; // left operand, or first number, of an equation initialized at 0.0
        private bool beginningMathOp = false; // indicates whether or not a mathematical operation is beginning, initialized as false

        // declaration of constructor for Form1
        public Form1()
        {
            InitializeComponent();
        }

        // whenever a number button is clicked, the new number is appended to the end of the existing number
        // to simulate how a calculator displays numbers. The first number entered does not follow this rule as to
        // avoid leading zeros
        // from Chuck
        private void numBtn_Click(object sender, EventArgs e)
        {
            // if the display window text is a 0 or if the user is beginning a math operation with a
            // decimal, then clear the display window
            if (displayWindow.Text == "0" || beginningMathOp == true && displayWindow.Text != ".")
            {
                displayWindow.Clear();
            }

            //Button btn = (Button)sender;
            //string numString = btn.Text;
            //displayWindow.Text += btn.Text;

            beginningMathOp = false;
            displayWindow.Text += ((Button)sender).Text;
        }

        // sets whatever is currently in the display window to 0 to clear it. All other calculations that have
        // already been performed remain in the background
        // from Chuck
        private void clearEntryBtn_Click(object sender, EventArgs e)
        {
            displayWindow.Text = "0";
        }

        // when clicking the clear button, rather than clearing the last inputted entry like the clear entry button,
        // everything is instead reset back to it's initial state
        private void clearBtn_Click(object sender, EventArgs e)
        {
            displayWindow.Text = "0";
            mathOperation = string.Empty;
            leftOperand = 0.0;
            beginningMathOp = false;
        }

        // the decimalBtn_Click method allows for the use of decimals in calculations by using a conditional statement
        // from Chuck
        private void decimalBtn_Click(object sender, EventArgs e)
        {
            // the text will be displayed if the displayWindow text contains a decimal, if the displayWindow text does
            // not contain a decimal, append the decimal to the existing text and display the text
            displayWindow.Text = displayWindow.Text.Contains(".") ? displayWindow.Text : displayWindow.Text + ".";
        }

        // the equalBtn_Click method evaluates what kind of math operation was requested by the user. After determining
        // this, the resulting number after the operation is outputted to the user
        // from Chuck
        private void equalBtn_Click(object sender, EventArgs e)
        {
            // the program will look through the cases until it reaches the operation that was requested by the user
            // it will then perform and output that operation to the display window. If the default case is reached
            // an error message will be presented to the user
            switch (mathOperation)
            {
                case "+":
                    displayWindow.Text = (leftOperand + double.Parse(displayWindow.Text)).ToString();
                    break;
                case "-":
                    displayWindow.Text = (leftOperand - double.Parse(displayWindow.Text)).ToString();
                    break;
                case "x":
                    displayWindow.Text = (leftOperand * double.Parse(displayWindow.Text)).ToString();
                    break;
                case "/":
                    displayWindow.Text = (leftOperand / double.Parse(displayWindow.Text)).ToString();
                    break;
                default:
                    Console.WriteLine("ERROR: This code should be unreachable.");
                    break;
            }
        }

        // when the add, subtract, multiply, or divide buttons are clicked it signifies the beginning of a
        // mathematical operation. Whatever number is in currently in the display window is considered to be
        // the left operand 
        // from Chuck
        private void mathOpBtn_Click(object sender, EventArgs e)
        {
            // beginning of a new math operation, false turns true
            beginningMathOp = true;

            // Whatever number is in currently in the display window is considered to be the left operand
            leftOperand = double.Parse(displayWindow.Text);

            // records the operator selected by the user
            mathOperation = ((Button)sender).Text;
        }

        // when the sign button is clicked, the sign will switch from positive to negative and vice versa.
        // the exception to this is when attempting to change a 0's sign since negative zero is the same
        // thing as 0
        // from Chuck
        private void signBtn_Click(object sender, EventArgs e)
        {
            // Parse the number in the display and reverse the sign of it (i.e. negative to positive)
            // and then turn it into a string which is then displayed to the user
            displayWindow.Text = (-double.Parse(displayWindow.Text)).ToString();
        }

        // when clicking the back button one number will be removed from the existing number in the display
        // window. This continues until the removal of the last number which is instead replaced with a 0 to
        // signify a return to the calculator's default state
        private void backBtn_Click(object sender, EventArgs e)
        {
            // if the displayed text is longer than 1 character
            if (displayWindow.Text.Length > 1)
            {
                // remove the last character from the string and output the result to the display window
                displayWindow.Text = displayWindow.Text.Substring(0, displayWindow.Text.Length - 1);
            }
            else // if the displayed text is 1 character or shorter
            {
                displayWindow.Text = "0";
            }
        }
    }
}
