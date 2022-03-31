using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Richard Ochei 20/02/2022
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("   BNU CO453 Applications Programming 2021-2022  ");
            Console.WriteLine("                by Richard Ochei                  ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();


            
            NetworkApp social = new NetworkApp();
            SocialNetwork socialnetwork = new Socialnetwork();

            social.DisplayMenu();
            Console.Beep();
        }
    }
}


