using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TelHai.DotNet.Classes.HW01.AliDrawshy
{
    // enum genre
    public enum Genre
    {
        Pop,
        Rock,
        Jazz,
        Classical,
        HipHop,
        Electronic,
        Other
    }
    public class Song
    {
        private static int nextId = 1;
        private int id;
        private string title;
        private string artist;
        private int year;
        private double duration;
        private Genre genre;

        // empty cons
        public Song()
        {

        }
        public Song(string title, string artist, int year, double duration ,Genre genre)
        {
            this.id = nextId++;
            Title = title;
            Artist = artist;
            Year = year;
            Duration = duration;
            Genre = genre;
        }
       
        public int Id => id;

        //prop
        public required string Title{
            get => title;
            set { 
                if(value == null)
                {
                    throw new ArgumentNullException("value is null");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("the value is less than two 2");
                }
                title = value;

            }

        }
        //prop
        public required string Artist
        {
            get => artist;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value is null");
                }
                
                artist = value;

            }

        }
        //prop
        public  int Year
        {
            get => year;
            set
            {
                
                if (value < 1900 || value > 2025)
                {
                    throw new ArgumentException("the value is not between 1900 and 2025");
                }
                year = value;

            }

        }
        //prop
        public double Duration 
        {
            get => duration;
            set
            {

                if (value <0 || value>20 )
                {
                    throw new ArgumentException("the value is should be greater than 0 and less than 20 ");
                }

                duration = value;

            }

        }
        //prop
        public Genre Genre {

            get => genre;
            set
            {
                if (!Enum.IsDefined(typeof(Genre),value)) 
                {
                    throw new ArgumentException("the value is not from the enum ");
                }
                genre = value;
            }
        }
        public void print()
        {
            Console.WriteLine(ToString());
        }
        
        public override string? ToString()
        {
           return  $"ID: {id}\n, Title: {Title}\n, Artist: {Artist}\n, Year: {Year}\n, Duration: {Duration}\n";
        }
    }
}
