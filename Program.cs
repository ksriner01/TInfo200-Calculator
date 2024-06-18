// Kyle Riner
// L4calc assignment
// TINFO-200A, Winter 2022

//////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer   Description of change
// 1-19-2022    kriner      Initial creation of file
// 1-29-2022    kriner      Documentation of program
// 
// The Calculator program presents the user with a functional calculator that allows them to perform
// rudimentary operations. The user has the option to either add, subtract, multiply, or divide whatever
// number they wish. They have the ability to alter the sign of numbers to produce negative outputs and
// add decimals to perform more precise calculations. The clear entry and clear buttons allow the user
// to either wipe their most recent input or all calculations performed until that point. The back button
// provides the user the means of removing one digit of whatever number they entered until they return
// to the initial state of the calculator. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// the namespace for the Calculator program
namespace Calculator
{
    // begins declaration of the class that holds the Calculator program
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        // the main method where the Calculator program is executed
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
