using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// The main features of this app is to give users options for converting distances
    /// </summary>
    /// <author>
    /// Richard Ochei version 0.1
    /// </author>
    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.04;

        private double miles;

        private double feet;
        
        private double metres;

        /// <summary>
        /// This method shows that the program will input the distance that is measured in miles,
        /// will calculate the same distance in feet, and finally output the distance also in
        /// feet.
        /// </summary>

        public void Run()
        {
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("       Convert Miles to Feet              ");
            Console.WriteLine("         by Richard Ochei                 ");
            Console.WriteLine("-------------------------------------------\n");
            int choice = InputChoice();
            ExecuteChoice(choice);
        }

        /// <summary>
        /// This method will give the user the options to either convert the value they
        /// have chosen from miles to feet or feet to miles.
        /// </summary>
        private int InputChoice()
        {
            Console.WriteLine("Do you want to convert miles to feet or feet to miles?");
            Console.WriteLine("1.Miles to feet");
            Console.WriteLine("2.Feet to miles");
            Console.WriteLine("3.Metres to miles");

            int value = (int) ConsoleHelper.InputNumber("enter your choice > ", 1,3);

            if (value == 1)
            {
                return 1;
            }
            else if (value == 2)
            {
                return 2;
            }
            else if (value == 3)
            {
                return 3;
            }
            else
            {
                Console.Beep();
                Console.WriteLine("Please choose either 1, 2 or 3");
                return 0;
            }
        }

        private void ExecuteChoice(int choice)
        {
            if (choice == 1)
            {
                miles = ConsoleHelper.InputNumber("please enter your distance in miles > ");
                feet = miles * FEET_IN_MILES;
                OutputFeet();
            }
            else if (choice == 2)
            {
                feet = ConsoleHelper.InputNumber("please enter your distance in feet > ");
                miles = feet / FEET_IN_MILES;
                OutputMiles();
            }
            else if (choice == 3)
            {
                miles = ConsoleHelper.InputNumber("please enter your distance in miles > ");
                metres = miles * METRES_IN_MILES;
                OutputMetres();
            }
            else
            {
                Console.WriteLine("you have made an invalid choice");
            }
        }

        private void OutputMetres()
        {
            throw new NotImplementedException();
        }

        private void OutputMiles()
        {
            throw new NotImplementedException();
        }


        private void CalculateFeet()
        {
            feet = miles * 5280;
        }

        private void OutputFeet()
        {
            Console.WriteLine(miles + " miles is equal to " + feet + " feet!");
        }
    }
}
