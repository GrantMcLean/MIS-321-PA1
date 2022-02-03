using System;
using System.Collections.Generic;
using System.IO;
namespace PA1
{
    class Program
    {
        static void Main(string[] args)
        {
            OpeningStatement(); // welcomes user
            string user = " ";
            while(user != "4")
            {
                user = Menus.MainMenu(user); // accesses menu class
            }
        }
        static void OpeningStatement()
        {
            Console.WriteLine("Welcome to Big Al's Playlist!\nPlease keep all song selection family friendly.\nThank you!\nPlease enter any key to continue. . .");
            Console.ReadKey();
        }
    }
}
