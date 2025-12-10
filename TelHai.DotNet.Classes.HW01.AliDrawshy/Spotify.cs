using System;
using System.Collections.Generic;

namespace TelHai.DotNet.Classes.HW01.AliDrawshy
{
    public class Spotify
    {
        private MusicLibrary library = new MusicLibrary();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("======== Music Library Menu - (By Ali Drawshy 214080350) ========");
                Console.WriteLine("1. Create new Playlist");
                Console.WriteLine("2. Create new Song");
                Console.WriteLine("3. Add Song to Playlist");
                Console.WriteLine("4. Display all Songs in a Playlist");
                Console.WriteLine("5. Delete Song from Playlist by ID");
                Console.WriteLine("6. Show all Playlists");
                Console.WriteLine("7. Show Songs by Genre");
                Console.WriteLine("8. Delete Playlist by ID");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": CreatePlaylist(); break;
                    case "2": CreateSong(); break;
                    case "3": AddSongToPlaylist(); break;
                    case "4": ShowSongsInPlaylist(); break;
                    case "5": DeleteSongById(); break;
                    case "6": ShowAllPlaylists(); break;
                    case "7": ShowSongsByGenre(); break;
                    case "8": DeletePlaylist(); break;
                    case "0": return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        //Create Playlist
        private void CreatePlaylist()
        {
            Console.Write("Enter playlist name: ");
            string name = Console.ReadLine();

            try
            {
                var p = new Playlist { Name = name };
                library.AddPlaylist(p);

                Console.WriteLine("Playlist created successfully. ID = " + p.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Create Song
        private void CreateSong()
        {
            try
            {
                Console.Write("Enter song title: ");
                string title = Console.ReadLine();

                Console.Write("Enter artist name: ");
                string artist = Console.ReadLine();

                Console.Write("Enter release year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Enter duration (minutes): ");
                double duration = double.Parse(Console.ReadLine());

                Console.WriteLine("Choose genre:");
                foreach (var g in Enum.GetValues(typeof(Genre)))
                    Console.WriteLine($"{(int)g} - {g}");

                Console.Write("Select: ");
                Genre genre = (Genre)int.Parse(Console.ReadLine());

                var s = new Song
                {
                    Title = title,
                    Artist = artist,
                    Year = year,
                    Duration = duration,
                    Genre = genre
                };

                Console.WriteLine($" Song created successfully.");
                s.print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //Add Song to Playlist 
        private void AddSongToPlaylist()
        {
            Console.Write("Enter Playlist ID: ");
            int pid = int.Parse(Console.ReadLine());

            var playlist = library.GetPlaylist(pid);
            if (playlist == null)
            {
                Console.WriteLine("Playlist not found.");
                return;
            }

            Console.Write("Enter song title: ");
            string title = Console.ReadLine();

            Console.Write("Enter artist name: ");
            string artist = Console.ReadLine();

            Console.Write("Enter release year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter duration: ");
            double duration = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose genre:");
            foreach (var g in Enum.GetValues(typeof(Genre)))
                Console.WriteLine($"{(int)g} - {g}");

            Genre genre = (Genre)int.Parse(Console.ReadLine());

            try
            {
                var s = new Song
                {
                    Title = title,
                    Artist = artist,
                    Year = year,
                    Duration = duration,
                    Genre = genre
                };

                playlist.AddSong(s);
                Console.WriteLine(" Song added to playlist.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //Show Songs in Playlist
        private void ShowSongsInPlaylist()
        {
            Console.Write("Enter Playlist ID: ");
            int pid = int.Parse(Console.ReadLine());

            var playlist = library.GetPlaylist(pid);
            if (playlist == null)
            {
                Console.WriteLine("Playlist not found.");
                return;
            }

            Console.WriteLine("\nSongs in playlist:");
            foreach (var song in playlist.Songs)
                Console.WriteLine(song.ToString());
        }

        // Delete Song by ID 
        private void DeleteSongById()
        {
            Console.Write("Enter Playlist ID: ");
            int pid = int.Parse(Console.ReadLine());

            var playlist = library.GetPlaylist(pid);
            if (playlist == null)
            {
                Console.WriteLine("Playlist not found.");
                return;
            }

            Console.Write("Enter Song ID to delete: ");
            int sid = int.Parse(Console.ReadLine());

            playlist.RemoveSong(sid);

            Console.WriteLine(" If the song existed, it was deleted.");
        }

        //Show All Playlists
        private void ShowAllPlaylists()
        {
            Console.WriteLine("All Playlists:");

            foreach (var p in library.Playlists)
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Songs: {p.Songs.Count}");
        }

        // Show Songs by Genre 
        private void ShowSongsByGenre()
        {
            Console.Write("Enter Playlist ID: ");
            int pid = int.Parse(Console.ReadLine());

            var playlist = library.GetPlaylist(pid);
            if (playlist == null)
            {
                Console.WriteLine("Playlist not found.");
                return;
            }

            Console.WriteLine("Choose genre:");
            foreach (var g in Enum.GetValues(typeof(Genre)))
                Console.WriteLine($"{(int)g} - {g}");

            Genre genre = (Genre)int.Parse(Console.ReadLine());

            Console.WriteLine($"\nSongs in genre {genre}:");
            foreach (var s in playlist.Songs)
                if (s.Genre == genre)
                    Console.WriteLine(s.ToString());
        }

        // Delete Playlist 
        private void DeletePlaylist()
        {
            Console.Write("Enter Playlist ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            library.RemovePlaylist(id);

            Console.WriteLine(" If the playlist existed, it was deleted.");
        }
    }
}
