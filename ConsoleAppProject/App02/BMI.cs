using System;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This a BMI converter for App 02 and i have added a public class for
    /// the height and weight which are in double numbers
    /// </summary>
    /// <author>
    /// Richard ochei | version 0.1
    /// </author>
    public class BMI
    {
        private double height;

        private double weight;

        /// <summary>
        /// Added a public class for Calc which will give the main parts of the
        /// BMI and the imperial and metric measurements and the health message
        /// </summary>
        public void CalculateIndex()
        {
            OutputHeader();
            double BMIIndex = 0;
            int Unit = GetUnits();
            if (Unit == 1) BMIIndex = CalcMetricBMI();
            else if (Unit == 2) BMIIndex = CalcImperialBMI();
            OutputHealthMessage(BMIIndex);
        }

        /// <summary>
        /// This is my header for when i start my program it will show this message
        /// </summary>
        public void OutputHeader()
        {
            Console.WriteLine();
            Console.WriteLine(" =============================== ");
            Console.WriteLine("     BMI Calculator              ");
            Console.WriteLine("     by Richard Ochei            ");
            Console.WriteLine(" =============================== ");
            Console.WriteLine();
        }

        internal void DisplayMenu()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// i have made a private class for getunits and when the prgram starts
        /// it will tell you to enter imperial or metric
        /// </summary>
        /// <returns></returns>
        private int GetUnits()
        {
            int unit = 0;
            Console.WriteLine("Enter Metric or Imperial > ");
            string value = Console.ReadLine();
            if (String.Equals(value, "metric")) unit = 1;
            else if (String.Equals(value, "imperial")) unit = 2;
            return unit;
        }

        /// <summary>
        /// this private class is when you enter metric and it will tell you
        /// to enter your height in metres and your weight in kg, also at the bottom
        /// it gives the calculation of your BMI.
        /// </summary>
        /// <returns></returns>
        private double CalcMetricBMI()
        {
            Console.Write("Please enter your height in metres > ");
            string value = Console.ReadLine();
            height = Convert.ToDouble(value);

            Console.Write("Please enter your weight in kg > ");
            value = Console.ReadLine();
            weight = Convert.ToDouble(value);

            double index = weight / (height * height);
            return index;
        }

        /// <summary>
        /// i have added a health message for each weight class and a special
        /// message for BAME catagories by adding if's and else if's
        /// </summary>
        /// <param name="BMIIndex"></param>
        private void OutputHealthMessage(double BMIIndex)
        {
            Console.Write("Your BMI is > ");
            Console.WriteLine(BMIIndex);

            if (BMIIndex < 18.50) Console.WriteLine("You are underweight");
            else if (BMIIndex < 25) Console.WriteLine("You are normal");
            else if (BMIIndex < 30) Console.WriteLine("You are overweight");
            else if (BMIIndex < 35) Console.WriteLine("You are obese class 1");
            else if (BMIIndex < 40) Console.WriteLine("You are obese class 2");
            else Console.WriteLine("You are obese class 3");

            Console.WriteLine("");
            if (BMIIndex > 23 && BMIIndex < 27.5)
            {
                Console.WriteLine("If you are Black, Asian or a member of other ethnic minority groups, ");
                Console.WriteLine("you have an increased risk of developing chronic conditions such as type 2 diabetes ");

            }
            else if (BMIIndex >= 27.5)
            {
                Console.WriteLine("If you are Black, Asian or a member of other ethnic minority groups, ");
                Console.WriteLine("you have a high risk of developing chronic conditions such as type 2 diabetes ");
            }

        }

        /// <summary>
        /// this class is for the imperial calculations and is the same for metric.
        /// </summary>
        /// <returns></returns>
        private double CalcImperialBMI()
        {
            Console.Write("Please enter your height in inches > ");
            string value = Console.ReadLine();
            height = Convert.ToDouble(value);

            Console.Write("Please enter your weight in pounds > ");
            value = Console.ReadLine();
            weight = Convert.ToDouble(value);

            double index = weight * 703 / (height * height);
            return index;
        }


    }


}