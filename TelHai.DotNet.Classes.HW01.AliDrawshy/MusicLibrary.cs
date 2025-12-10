using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelHai.DotNet.Classes.HW01.AliDrawshy
{
    public class MusicLibrary
    {
        public List<Playlist> playlists;

        public MusicLibrary()
        {
            playlists = new List<Playlist>();
        }
        //pop
        public List<Playlist> Playlists
        {

            get => playlists;
            set
            {
                playlists = value;
            }
        }
        //addplaylist
        public void AddPlaylist(Playlist p)
        {
            playlists.Add(p);
        }
        //getPlayList
        public Playlist GetPlaylist(int id)
        {
            foreach (Playlist p in playlists)
            {
                if (p.Id == id) return p;
            }
            return null;

        }
        //remove PlayList
        public void RemovePlaylist(int id)
        {
            foreach (Playlist p in playlists)
            {
                if (p.Id == id)
                {
                    playlists.Remove(p);
                    return;

                }
            }
        }
        //get PlayList Name
        public List<string> GetPlaylistNames()
        {
            List<string> lst=new List<string>();
            foreach (Playlist p in playlists)
            {
                lst.Add(p.Name);
            }
            return lst;
        }


    }
}
