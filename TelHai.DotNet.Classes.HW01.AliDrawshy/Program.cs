using System;

namespace TelHai.DotNet.Classes.HW01.AliDrawshy
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Spotify s = new Spotify();
            s.Run();

            var song = new Song
            {
                Title = "Salf W Dayn",
                Artist = "George Wassouf",
                Year = 2003,
                Duration = 5.48,
                Genre = Genre.Classical
            };

            var song1 = new Song
            {
                Title = "saber wrady",
                Artist = "George Wassouf",
                Year = 2004,
                Duration = 4.30,
                Genre = Genre.Other
            };

            var song2 = new Song("lose control", "jojo", 2022, 4.50, Genre.Classical)
            {
                Title = "lose control",
                Artist = "jojo",
                Duration = 4.50
            };

            var playlist = new Playlist
            {
                Name = "My Favorites",
                Songs = {
                    new Song { Title = "Song1", Artist = "A" },
                    new Song { Title = "Song2", Artist = "B" }
                }
            };

            var playlist1 = new Playlist
            {
                Name = "In car ",
                Songs = {
                    new Song { Title = "Song3", Artist = "c" },
                    new Song { Title = "Song4", Artist = "d" }
                }
            };

            var musicLibrary = new MusicLibrary
            {
                Playlists = { new Playlist { Name = "Library A" } }
            };

            var musicLibrary1 = new MusicLibrary
            {
                Playlists = { new Playlist { Name = "Library B" } }
            };

            var musicLibrary2 = new MusicLibrary
            {
                Playlists = { new Playlist { Name = "Library C" } }
            };

            Console.WriteLine("\n=== VALIDATION TESTS START ===");

            //Test func
            void Test(string name, Action action)
            {
                Console.WriteLine($"\n--- {name} ---");
                try
                {
                    action();
                    Console.WriteLine(" Passed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Exception: {ex.GetType().Name} - {ex.Message}");
                }
            }

            // Tests for the songs 

            Test("Title = null", () =>
            {
                var s = new Song
                {
                    Title = null!,
                    Artist = "A",
                    Year = 2000
                };
            });

            Test("Title length < 2", () =>
            {
                var s = new Song
                {
                    Title = "A",
                    Artist = "A",
                    Year = 2000
                };
            });

            Test("Artist = null", () =>
            {
                var s = new Song
                {
                    Title = "Valid",
                    Artist = null!,
                    Year = 2000
                };
            });

            Test("Year < 1900", () =>
            {
                var s = new Song
                {
                    Title = "Valid",
                    Artist = "A",
                    Year = 1500
                };
            });

            Test("Year > 2025", () =>
            {
                var s = new Song
                {
                    Title = "Valid",
                    Artist = "A",
                    Year = 2030
                };
            });

            Test("Duration < 0", () =>
            {
                var s = new Song
                {
                    Title = "Valid",
                    Artist = "A",
                    Year = 2000,
                    Duration = -5
                };
            });

            Test("Duration > 20", () =>
            {
                var s = new Song
                {
                    Title = "Valid",
                    Artist = "A",
                    Year = 2000,
                    Duration = 99
                };
            });

            /// Test for the PlayList 

            Test("Playlist name too short", () =>
            {
                var p = new Playlist { Name = "Hi" };
            });

            Test("Playlist Songs = null", () =>
            {
                var p = new Playlist { Name = "My fav songs"};
                p.Songs = null!;
            });

            Test("AddSong works", () =>
            {
                var p = new Playlist { Name = "MyList" };
                var ss = new Song
                {
                    Title = null,
                    Artist = "justin baber",
                    Year = 2000
                };
                p.AddSong(ss);
            });

            Test("RemoveSong works", () =>
            {
                var p = new Playlist { Name = "MyList" };
                var ss1 = new Song
                {
                    Title = "turn tv off",
                    Artist = null,
                    Year = 2000
                };
                p.AddSong(ss1);
                p.RemoveSong(ss1.Id);
            });

            Test("FindSong works", () =>
            {
                var p = new Playlist { Name = "MyList" };
                var ss2 = new Song
                {
                    Title = null,
                    Artist = "justin baber",
                    Year = 2000
                };
                p.AddSong(ss2);
                if (p.FindSong(ss2.Id) == null) throw new Exception("Not found");
            });

            Test("Total duration correct", () =>
            {
                var p = new Playlist { Name = "MyList" };
                var ss3 = new Song
                {
                    Title = "A",
                    Artist = "B",
                    Year = 2000,
                    Duration = 3
                };
                var ss4 = new Song
                {
                    Title = "C",
                    Artist = "D",
                    Year = 2000,
                    Duration = 4
                };
                p.AddSong(ss3);
                p.AddSong(ss4);
                if (p.GetTotalDuration() != 7) throw new Exception("Wrong total");
            });

            /// Tests for the MusicLibrary

            Test("AddPlaylist works", () =>
            {
                var ml = new MusicLibrary();
                ml.AddPlaylist(new Playlist { Name = "Te" });
            });

            Test("GetPlaylist works", () =>
            {
                var ml = new MusicLibrary();
                var p = new Playlist { Name = "t"};
                ml.AddPlaylist(p);
                if (ml.GetPlaylist(p.Id) == null) throw new Exception("Not found");
            });

            Test("RemovePlaylist works", () =>
            {
                var ml = new MusicLibrary();
                var p = new Playlist { Name = "" };
                ml.AddPlaylist(p);
                ml.RemovePlaylist(p.Id);
            });

            Test("GetPlaylistNames works", () =>
            {
                var ml = new MusicLibrary();
                ml.AddPlaylist(new Playlist { Name = "A" });
                ml.AddPlaylist(new Playlist { Name = "B" });

                var names = ml.GetPlaylistNames();
                if (names.Count != 2) throw new Exception("Wrong count");
            });
        }
    }
}
