using System;
using System.Collections.Generic;
using System.IO;

namespace PA1
{
    public class SongFiles
    {
        public static void SaveFile(List<Song> mySongs)    // stores List data into songs.txt file
        {
            
            StreamWriter outFile = new StreamWriter("songs.txt");

            foreach(Song item in mySongs)
            {
                outFile.Write(item.songID);
                outFile.Write("#");
                outFile.Write(item.songTitle);
                outFile.Write("#");
                outFile.Write(item.timeAdded);
                outFile.Write("#");
                outFile.Write(item.active);
                outFile.WriteLine("");
            }
            outFile.Close();
        }
        public static List<Song> PopulateList() // returns data from file to populate mySongs at beginning of program
        {
            List<Song> popList = new List<Song>();

            StreamReader inFile = null;

            try{
            
                inFile = new StreamReader("songs.txt");
                inFile.Close();

            } catch (FileNotFoundException e)   // catches if file does not exist
            {
                    
                Console.WriteLine($"File error: {e}\nPlease enter any key to continue. . .");

                Console.ReadKey();

                return popList;

            }

                inFile = new StreamReader("songs.txt");

                string line = inFile.ReadLine();
 
                while(line != null)
                {
                    string[] temp = line.Split("#");

                    popList.Add(new Song
                    {songID = temp[0], songTitle = temp[1], timeAdded = DateTime.Parse(temp[2]), active = bool.Parse(temp[3])});

                    line = inFile.ReadLine();
                }
                inFile.Close();

            return popList;
        }

    }
}