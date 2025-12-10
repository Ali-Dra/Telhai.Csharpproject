using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace TelHai.DotNet.Classes.HW01.AliDrawshy
{
    public class Playlist
    {
        private static int nextId = 1;
        private int id;
        private string name;
        List<Song> songs;

        public Playlist(string name) : this() { Name = name; }
        public Playlist( string name, List<Song> songs) : this(name) { 
            
            songs=songs ?? new List<Song>();

        }
        //Empty cons
        public Playlist() {
            this.id = ++nextId;
            songs = new List<Song>();   
        }
        //prop
        public required string Name
        {
            get => name;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("the value is les than 3");
                }
                name = value;
            }
        }
        public int Id => id;
        //prop
        public List<Song> Songs
        {
            get => songs;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                songs = value;
            }

        }

        public void print()
        {
            Console.WriteLine(ToString);
        }

        public override string? ToString()
        {
            foreach (Song song in songs)
            {
                Console.WriteLine(song.ToString());
            }
            return base.ToString();
        }
        public void AddSong(Song song) { 
            songs.Add(song);
        }
        public void RemoveSong(int songID) { 
            foreach (Song song2 in songs)
            {
                if(song2.Id == songID)
                {
                    songs.Remove(song2);
                    return;
                }
                
            }
        }
        public Song? FindSong(int songid)
        {
            foreach (Song song in songs)
            {
                if (song.Id == songid)
                {
                    return song;
                }
                
            }
            return null;
        }
        public double GetTotalDuration()
        {
            double total = 0;
            foreach (Song song in songs) {
                total += song.Duration;
            }
            return total;
        }

    }

}
