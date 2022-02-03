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
        public static bool active { get; set; }
        static public void UpdateList()
        {
            myList.AddRange(SongFiles.PopulateList());
        }
        static public void ShowAllSongs()
        {
                myList.Reverse();
                foreach (var Song in myList)
                {

                    Console.Write("ID: " + Song.songID + ", ");

                    Console.Write("Song Title: " + Song.songTitle + ", ");

                    Console.Write("Time Added: " + Song.timeAdded);
                    Console.WriteLine("");

                }
                myList.Reverse();
            Console.WriteLine("Please enter any key to continue. . .");

            Console.ReadKey();

        }
        static public void AddASong()
        {
        
            Console.WriteLine("What is the title of the song which you would like to add?");

            string title = Console.ReadLine();      // stores user entered song title

             Guid ID = Guid.NewGuid();               // generates Guid

            string newID = Convert.ToBase64String(ID.ToByteArray());

            DateTime time = DateTime.Now;           // obtains current time

            // bool act = true;

            myList.Add (new Song {songID = newID, songTitle = title, timeAdded = time});

            SongFiles.SaveFile(myList); // adds List data to songs.txt file

        }
        static public void DeleteASong()
        {
            int location = -1;

            location = SelectID();

            if(location != -1)
            {

                // myList.Remove(new Song() {songID = location});
                myList.RemoveAt(location);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Song not found.\nMake sure you entered it correctly.\nPlease enter any key to continue. . .");
                Console.ReadKey();
            }

        }
        static public int SelectID()
        {

            ShowAllSongs();
 
            Console.WriteLine("Which song would you like to remove?\n(Please enter the first few digits of the ID)");
           
            string location = Console.ReadLine();

            foreach(var song in myList)
            {
                int i = 0;
                        // if(song.songID.CompareTo(location) == 0)
                        // {
                        //    return location;
                        // }
                    if(song.songID.CompareTo(location) == 0)
                    {
                        // return song.songID.IndexOf(location);
                        return i;
                    }
                i++;
            }

            return -1;
        }
        public override string ToString()
        {
            return songID + ", " + songTitle + ", " + timeAdded;
        }
    }
}