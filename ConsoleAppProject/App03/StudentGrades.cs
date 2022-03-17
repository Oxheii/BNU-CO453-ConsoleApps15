using System;
using System.Text.RegularExpressions;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This app will prompt a user to select from a list of options:
    /// input marks, output marks, output stats, output grade profile,
    /// and quit.
    /// </summary>
    /// 
    /// <author>
    /// Richard Okon Ochei - Version 1.0
    /// </author>
    public class StudentGrades
    {
        // Constants
        public const int LowestMark = 0;
        public const int LowestGradeF = 39;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;
        public const string AllowedChars = @"^[0-9]*$";

        // Properties
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public int AddMark { get; set; }

        public string InputMark { get; set; }

        private int studentIndex = 0;

        /// <summary>
        /// Class constructor called when an object
        /// is created and sets up an array of Students.
        /// </summary>
        public StudentGrades()
        {
            Students = new string[]
            {
                "Richard", "Stephen", "Mercy",
                "John", "Josiah", "MC",
                "Ricky", "K2Trappy", "Michael",
                "Biggie"
            };

            GradeProfile = new int[(int)Grades.A + 1];

            Marks = new int[Students.Length];             
        }

        /// <summary>
        /// The method used to initiate the program
        /// calls to other methods to output the heading, show the options,
        /// and select an option.
        /// </summary>
        public void Run()
        {
            OutputHeading();
            ShowOptions();
            SelectOption();
        }

        /// <summary>
        /// Outputs the heading of the application
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine();
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("        Student Marks ");
            Console.WriteLine("        by Richard Ochei        ");
            Console.WriteLine("------------------------------\n");
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a menu of options for the user to select from.
        /// </summary>
        private void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine(" 1. Input Marks | 2. Output Marks | 3. Output Stats");
            Console.WriteLine(" 4. Output Grade Profile | 5. Quit");

            //studentIndex = 0;
            SelectOption();
        }

        /// <summary>
        /// Prompts the user to select an option.
        /// If the user input does not match an option, the user is prompted again.
        /// </summary>
        private void SelectOption()
        {
            Console.Write("\n Please enter your choice > ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StudentMarks();
                    break;

                case "2":
                    OutputMarks();
                    break;

                case "3":
                    OutputStats();
                    break;

                case "4":
                    OutputGradeProfile();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine(" Invalid option.\n");
                    SelectOption();
                    break;
            }
        }

        /// <summary>
        /// Calls other methods for user to input student marks,
        /// calculate stats, calculate grade profile and show options again.
        /// </summary>
        public void StudentMarks()
        {
            InputMarks();

            CalculateStats();

            CalculateGradeProfile();

            ShowOptions();
        }

        /// <summary>
        /// Input a mark between 0 - 100 for each
        /// student and stores value in the Marks array.
        /// Resets studentIndex to zero for when this method is called next.
        /// The studentIndex cannot be limited to this scope as it is required for
        /// error handling.
        /// </summary>
        private void InputMarks()
        {
            Console.WriteLine("\n Please enter a mark for each student:\n");

            while (studentIndex < Students.Length)
            {
                Console.Write($" Mark for { Students[studentIndex] } > ");

                InputMark = Console.ReadLine();

                ValidateInput();

                Marks[studentIndex] = AddMark;

                studentIndex++;
            }

            studentIndex = 0;
        }

        /// <summary>
        /// List all the students and display their
        /// name and current mark
        /// </summary>
        public void OutputMarks()
        {
            Console.WriteLine("\n Student marks:");

            int i = 0;
            while (i < Students.Length)
            {
                Console.Write($"\n Mark for { Students[i] } > {Marks[i]}");

                i++;
            }

            Console.WriteLine("\n");

            ShowOptions();
        }

        /// <summary>
        /// Convert a student mark to a grade
        /// from F (Fail) to A (First Class)
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= LowestMark && mark < LowestGradeD)
            {
                return Grades.F;
            }

            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                return Grades.D;
            }

            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                return Grades.C;
            }

            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                return Grades.B;
            }

            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                return Grades.A;
            }

            return Grades.A;
        }

        /// <summary>
        /// Calculate and display the minimum, maximum,
        /// and mean mark for all the students
        /// </summary>
        public void CalculateStats()
        {
            Minimum = Marks[0];
            Maximum = Marks[0];

            double total = 0;

            foreach(int mark in Marks)
            {
                if (mark > Maximum) Maximum = mark;

                if (mark < Minimum) Minimum = mark;

                total += mark;
            }

            Mean = total / Marks.Length;
        }

        /// <summary>
        /// Displays the maximum, minimum and mean marks
        /// </summary>
        private void OutputStats()
        {
            Console.WriteLine($"\n Maximum mark is {Maximum}");
            Console.WriteLine($" Minimum mark is {Minimum}");
            Console.WriteLine($" Mean mark is {Mean}\n");

            ShowOptions();
        }

        /// <summary>
        /// Calculates the grade profile for the class of students.
        /// </summary>
        public void CalculateGradeProfile()
        {
            for(int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach(int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);

                GradeProfile[(int)grade]++;
            }
        }

        /// <summary>
        /// Displays the grade profile for the class of students.
        /// </summary>
        private void OutputGradeProfile()
        {
            Grade grade = Grade.F;

            Console.WriteLine();

            foreach(int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;

                Console.WriteLine($" Grade {grade} {percentage}% Count {count}");

                grade++;
            }

            Console.WriteLine();

            ShowOptions();
        }

        /// <summary>
        /// Checks that the input is not blank.
        /// Checks the input is a number.
        /// Checks the number is between 0 and 100.
        /// If not the HandleError method is called.
        /// If input is valid the input is converted to an int and returned.
        /// </summary>
        private int ValidateInput()
        {
            if (InputMark != "" && Regex.IsMatch(InputMark, AllowedChars))
            {
                AddMark = Convert.ToInt32(InputMark);
            }

            else
            {
                HandleError();

            }

            if (AddMark < LowestMark || AddMark > HighestMark)
            {

                HandleError();
            }

            else
            {
                AddMark = Convert.ToInt32(InputMark);
            }

            return AddMark;
        }

        /// <summary>
        /// Tells the user the expected range of mark to input.
        /// Prompts the user to re enter the mark for a student.
        /// Calls the ValidateInput method to check input again.
        /// </summary>
        private void HandleError()
        {
            Console.WriteLine($" Enter a value in the range of {LowestMark} and" +
                $" {HighestMark}!");

            Console.Write($"\n Mark for { Students[studentIndex] } > ");

            InputMark = Console.ReadLine();

            ValidateInput();
        }
    }
}
