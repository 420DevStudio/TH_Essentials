using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH_Essentials.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// Link to the xamarin Guys and gals project: https://github.com/xamarin/mobile-samples/tree/main/LivePlayer/BasicCalculator

namespace TH_Essentials.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaschenrechnerPage : ContentPage
    {
        TaschenrechnerViewModel _viewModel;

        int currentState = 1;
        string myOperator;
        double firstNumber, secondNumber;

        public TaschenrechnerPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TaschenrechnerViewModel();
            OnClear(this, null);
        }

        private void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        private void OnSquareRoot(object sender, EventArgs e)
        {
            if (currentState == -1 || currentState == 1)
            {
                var result = Math.Sqrt(firstNumber);

                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        private void OnPercentage(object sender, EventArgs e)
        {
            Console.WriteLine(currentState);
            if (currentState == -1 || currentState == 1 || currentState == 2)
            {
                var result = CalculatePercentage(firstNumber, secondNumber, myOperator);
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            // Validation before button is pressed
            // if the current result is 0 in text box then we will direct the calculator to exclude 0 when pressing buttons
            if (resultText.Text == "0" || currentState < 0) // at first currentState is 1
            {
                this.resultText.Text = "0"; 

                if (currentState < 0) // value of currentState is 1 so this condition will be excluded
                    currentState *= -1;
            }

            this.resultText.Text += pressed; // this condition is called when currentState is greater and text box will aquire the pressed

            double number; // if we are going to assign two dynamic number for a given variable using try parse method

            if (double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString(""); // enter N0 inside the String to get 123,456 instead of 123456
                if (currentState == 1)
                {
                    firstNumber = number; // currentState is 1 and it will assign firstNumber with the presses variable
                }
                else
                {
                    secondNumber = number; // it will be implemented as the number of currentState changes i. e. 2
                }
            }            
            
            if ((pressed == "." && currentState == 1) || (pressed == "." && currentState == 2))
            {
                //CultureInfo germanCulture = new CultureInfo("de-DE");
                //CultureInfo usCulture = new CultureInfo("en-US");


                if (!resultText.Text.Contains(".") && CultureInfo.CurrentCulture.ToString() == "de-DE") 
                {
                    resultText.Text = resultText.Text + ",";
                    Console.WriteLine(CultureInfo.CurrentCulture.ToString());

                }
                else
                {
                    resultText.Text = resultText.Text + pressed;
                    Console.WriteLine(CultureInfo.CurrentCulture.ToString());

                    //resultText.Text = "";
                    //return;
                }
            }
        }        

        private void OnSquareClicked(object sender, EventArgs e)
        {
            if (currentState == -1 || currentState == 1)
            {
                var result = firstNumber * firstNumber;
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = Calculate(firstNumber, secondNumber, myOperator);

                this.resultText.Text=result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            myOperator = pressed;
        }

        public static double Calculate(double value1, double value2, string mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "/":
                    result = value1 / value2;
                    break;
                case "*":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
            }
            return result;
        }

        public static double CalculatePercentage(double value1, double value2, string mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "/":
                    result = value1 / ((value1 * value2) / 100);
                    break;
                case "*":
                    result = value1 * ((value1 * value2) / 100);
                    break;
                case "+":
                    result = value1 + ((value1*value2) / 100);
                    break;
                case "-":
                    result = value1 - ((value1 * value2) / 100);
                    break;
            }
            return result;
        }
    }
}