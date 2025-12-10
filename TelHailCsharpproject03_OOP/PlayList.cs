using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelHailCsharpproject03_OOP;
using TelHai.CS.CsharpCourse.Services;
using TelHai.CS.CsharpCourse.Services.Logging;
namespace TelHailCsharpproject03_OOP
{
    public class PlayList
    {
        private List<string> songs;
        private string name;
        
        //Empty ctor

        public PlayList():this("NO NAME")
        {
            Logger.Log("In Embty ctor ", LogLevel.Debug);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public PlayList(string name)
        {
            //no property with setter
            // this.name=name;
            Name = name; //set with valditation 
            songs = new List<string>();
        }
        public string Name
        {
            get { return name.ToUpper(); }
            set { 
                if (string.IsNullOrEmpty(value)){
                    name = "<NO PLAYLIST NAME>";
                    
                }
                name = value;

            }
        }
        /// <summary>
        /// Auto Properties
        /// </summary>
        public int Id { get; set; }

        public int MyProperty { get; set; }
        /// <summary>
        /// Get The Count Of The Songs
        /// </summary>
        public int Count
        {
            get => songs.Count; 
        }
        //public int Count => songs.Count;
        
    }
}
