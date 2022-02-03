using System;
using System.Collections.Generic;

namespace PA1
{
    public class Menus
    {
        public string user { get; set; }

        static public string MainMenu(string user)
        {
            Song.UpdateList();
            while(user != "4")
            {
            Console.Clear();
            Console.WriteLine("1) Show All Songs\n2) Add a song\n3) Delete a song\n4) Exit");
            user = Console.ReadLine();
            Route(user);
            }
            return user;
        }
        static void Route(string user)
            {
                Console.Clear();
                if(user == "1")
                {

                    Song.ShowAllSongs();
                    
                }
                if(user == "2")
                {

                    Song.AddASong();
                    
                }
                if(user == "3")
                {

                    Song.DeleteASong();

                }
            }
    }
}