using System;
using System.Collections.Generic;
using System.IO;

namespace PA1
{
    public class SongFiles
    {
        public static void SaveFile(List<Song> myList)    // stores List data into song.txt file
        {
            
            StreamWriter outFile = new StreamWriter("songs.txt");

            foreach(Song item in myList)
            {
                outFile.Write(item.songID);
                outFile.Write("#");
                outFile.Write(item.songTitle);
                outFile.Write("#");
                outFile.Write(item.timeAdded);
                outFile.WriteLine("");
            }
            outFile.Close();
        }
        public static List<Song> PopulateList()
        {
            List<Song> popList = new List<Song>();

            StreamReader inFile = null;

            try{
            
                inFile = new StreamReader("songs.txt");
                inFile.Close();

            } catch (FileNotFoundException e)
            {
                    
                Console.WriteLine($"File error: {e}\nPlease enter any key to continue. . .");

                Console.ReadKey();

                // inFile.Close();

                return popList;

            }

                inFile = new StreamReader("songs.txt");

                string line = inFile.ReadLine();
 
                while(line != null)
                {
                    string[] temp = line.Split("#");

                    popList.Add(new Song
                    {songID = temp[0], songTitle = temp[1], timeAdded = DateTime.Parse(temp[2])});

                    line = inFile.ReadLine();
                }
                inFile.Close();

            return popList;
        }

    }
}