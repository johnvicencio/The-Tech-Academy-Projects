using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstChallenge.Models
{
    public class ComicBookManager
    {
        public static List<ComicBook> GetComicBooks()
        {
            return new List<ComicBook> {
                new ComicBook {ComicBookId=1, ComicTitle="Action Comics", EpisodeNumber=41, EpisodeTitle="Not So Super Man", Characters = new List<Character>{ new Character { CharacterId=1, Name="Superman" }}},
                new ComicBook {ComicBookId=2, ComicTitle="Batman Superman", EpisodeNumber=13, EpisodeTitle="Crossways", Characters = new List<Character>{new Character {CharacterId=1, Name="Superman" }, new Character {CharacterId=2, Name="Batman"}}},
                new ComicBook {ComicBookId=3, ComicTitle="Arkham", EpisodeNumber=17, EpisodeTitle="Darkest Knight", Characters= new List<Character>{new Character {CharacterId=2, Name="Batman" }}}
            };
        }
    }

    public class ComicBook
    {
        public int ComicBookId { get; set; }
        public string ComicTitle { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeTitle { get; set; }
        public List<Character> Characters { get; set; }
    }

    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
    }
}