using System;
using System.IO;
using System.Runtime.CompilerServices;
using VideoGameLab;
using System.Globalization;
using CsvHelper;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        string projectRootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();

        string filePath = projectRootFolder + "/videogames.csv";


        List<VideoGame> videoGames = ReadVideoGamesFromFile(filePath);

        // Sort the list by title
        videoGames.Sort();
        

        // Step 3: Display sorted list
        Console.WriteLine("Sorted List of Video Games:");
        foreach (var game in videoGames)
        {
            Console.WriteLine(game);
        }
        Console.WriteLine("-------------------------------------------------------------------------");
        PublisherData();

      
        Console.WriteLine("-------------------------------------------------------------------------");
        
       GenreData();
      
        Console.WriteLine("-------------------------------------------------------------------------");

         void  PublisherData()
        {
            Console.WriteLine("Please choose a publisher to return data on");
            string publisher = Console.ReadLine();

            List<VideoGame> gamesFromPublisher = videoGames.Where(g => g.Publisher == publisher).ToList();
            gamesFromPublisher.Sort();
            Console.WriteLine($"\n Games from {publisher} Sorted aplhabetically:");
            foreach (var game in gamesFromPublisher)
            {
                Console.WriteLine(game);
            }
            //calculate percentage of games from electornic arts
            double publisherPercentage = (double)gamesFromPublisher.Count / videoGames.Count * 100;
            Console.WriteLine($"Total of Games: {videoGames.Count}");
            Console.WriteLine($"Total of Games published by {publisher}: {gamesFromPublisher.Count}");
            Console.WriteLine($"Total Percent of games developed by {publisher}: {publisherPercentage:F2}%");

        }

        void GenreData()
        {
            Console.WriteLine("Please choose a genre to return data on");
            string genre = Console.ReadLine();

            List<VideoGame> genreGames = videoGames.Where(g => g.Genre == genre).ToList();
            genreGames.Sort();
            Console.WriteLine($"\n Games from {genre} Sorted aplhabetically:");
            foreach (var game in genreGames)
            {
                Console.WriteLine(game);
            }

            double genrePercentage = (double)genreGames.Count / videoGames.Count * 100;
            Console.WriteLine($"Total of  Games: {videoGames.Count}");
            Console.WriteLine($"Total of {genre} Games: {genreGames.Count}");
            Console.WriteLine($"Total Percent of {genre} Games: {genrePercentage:F2}%");
        }
        static List<VideoGame> ReadVideoGamesFromFile(string filename)
        {
            List<VideoGame> games = new List<VideoGame>();

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filename);

                foreach (var line in lines)
                {
                    // Split each line by tabs assuming it's a tab-separated file
                    string[] columns = line.Split(',');

                    // Create a VideoGame object and populate its properties
                    VideoGame game = new VideoGame
                    {
                        Name = columns[0],
                        Platform = columns[1],
                        Year = columns[2],
                        Genre = columns[3],
                        Publisher = columns[4],
                        NA_Sales = columns[5],
                        EU_Sales = columns[6],
                        JP_Sales = columns[7],
                        Other_Sales = columns[8],
                        Global_Sales = columns[9]


                      
                    };

                    // Add the game to the list
                    games.Add(game);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return games;
        }
    }
}
           /* using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Read all records from the CSV file
                var videoGames = csv.GetRecords<VideoGame>().ToList();

                // Process the video game data
                foreach (var game in videoGames)
                {
                    Console.WriteLine($"Name: {game.Name}, Platform: {game.Platform}, Year: {game.Year}, Genre: {game.Genre},Publisher:{game.Publisher} , NA Sales: {game.NA_Sales}, EU Sales: {game.EU_Sales} , Jp Sales: {game.JP_Sales} , Other Sales: {game.Other_Sales} , Global Sales: {game.Global_Sales}");
                }
            }
        
    }
}
*/