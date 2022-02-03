using System;
using System.Collections.Generic;
namespace PA1
{
    public class Song
    {
        public static Song currSongs;
        public static List<Song> myList = new List<Song>();

        public  string songTitle { get; set; }
        public  string songID { get; set; }
        public  DateTime timeAdded { get; set; }
        public bool active { get; set; }
        static public void UpdateList() // repopulates list when program is first opened
        {
            myList.AddRange(SongFiles.PopulateList());
        }
        static public void ShowAllSongs()   // displays all not deleted songs 
        {
                myList.Sort(Song.CompareDate);
                foreach (var song in myList)
                {

                    if(song.active == true)
                    {
                        Console.Write("ID: " + song.songID + ", ");

                        Console.Write("Song Title: " + song.songTitle + ", ");

                        Console.Write("Time Added: " + song.timeAdded);

                        Console.WriteLine("");
                    }

                }

            Console.WriteLine("Please enter any key to continue. . .");

            Console.ReadKey();

        }
        static public void AddASong()   // adds a song to mySongs and saves it to file
        {
        
            Console.WriteLine("What is the title of the song which you would like to add?");

            string title = Console.ReadLine();      // stores user entered song title

             Guid ID = Guid.NewGuid();               // generates Guid

            string newID = Convert.ToBase64String(ID.ToByteArray());

            DateTime time = DateTime.Now;           // obtains current time

            bool act = true;

            myList.Add (new Song {songID = newID, songTitle = title, timeAdded = time, active = act});

            SongFiles.SaveFile(myList); // adds List data to songs.txt file

        }
        static public void DeleteASong()    // soft delete
        {
             int location = -1;

            location = SelectID();

            if(location == -1)  // checks if song ID was not found
            {

                Console.Clear();
                Console.WriteLine("Song not found.\nMake sure you entered it correctly.\nPlease enter any key to continue. . .");
                Console.ReadKey();

            }
        }
        static public int SelectID()    // checks if user input matches stored ID
        {

            ShowAllSongs();
 
            Console.WriteLine("Which song would you like to delete?\n(Please enter the entire ID)");
           
            string location = Console.ReadLine();

            int i = 0;
            foreach(var song in myList)
            {
                    if(song.songID.CompareTo(location) == 0)
                    {
                        song.active = false;
                        SongFiles.SaveFile(myList);
                        return 0;
                    }
                i++;
            }
            i = 0;
            return -1;

        }
        public static int CompareDate(Song x, Song y)   // sorts list by time added
        {
            
            return y.timeAdded.CompareTo(x.timeAdded);

        }
    }
}