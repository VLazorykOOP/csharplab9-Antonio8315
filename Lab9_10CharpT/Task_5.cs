using System;
using System.Collections;
#nullable disable

namespace Task_5
{
    public class Task_5
    {
        public class Song
        {
            public string Title { get; set; }
            public string Artist { get; set; }
            public double DurationMinutes { get; set; }

            public Song(string title, string artist, double duration)
            {
                Title = title;
                Artist = artist;
                DurationMinutes = duration;
            }

            public override string ToString()
            {
                return $" {Title} — {Artist} ({DurationMinutes} min)";
            }
        }

        public class MusicDisc
        {
            public string DiscName { get; set; }
            public ArrayList Songs { get; private set; }

            public MusicDisc(string name)
            {
                DiscName = name;
                Songs = new ArrayList();
            }

            public void AddSong(Song song)
            {
                Songs.Add(song);
            }

            public void RemoveSong(string title)
            {
                Songs.Remove(Songs.Cast<Song>().FirstOrDefault(s => s.Title == title));
            }

            public void PrintSongs()
            {
                Console.WriteLine($" Диск: {DiscName}");
                foreach (Song s in Songs)
                {
                    Console.WriteLine($"   {s}");
                }
            }
        }

        public class MusicCatalog
        {
            private Hashtable catalog = new Hashtable();

            public void AddDisc(string discName)
            {
                if (!catalog.ContainsKey(discName))
                    catalog[discName] = new MusicDisc(discName);
            }

            public void RemoveDisc(string discName)
            {
                catalog.Remove(discName);
            }

            public void AddSongToDisc(string discName, Song song)
            {
                if (catalog[discName] is MusicDisc disc)
                {
                    disc.AddSong(song);
                }
            }

            public void RemoveSongFromDisc(string discName, string songTitle)
            {
                if (catalog[discName] is MusicDisc disc)
                {
                    disc.RemoveSong(songTitle);
                }
            }

            public void ShowCatalog()
            {
                foreach (DictionaryEntry entry in catalog)
                {
                    MusicDisc disc = (MusicDisc)entry.Value;
                    disc.PrintSongs();
                }
            }

            public void ShowDisc(string discName)
            {
                if (catalog[discName] is MusicDisc disc)
                {
                    disc.PrintSongs();
                }
            }

            public void SearchByArtist(string artist)
            {
                Console.WriteLine($"Пошук пісень виконавця: {artist}");
                foreach (DictionaryEntry entry in catalog)
                {
                    MusicDisc disc = (MusicDisc)entry.Value;
                    foreach (Song song in disc.Songs)
                    {
                        if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($" {disc.DiscName}: {song}");
                        }
                    }
                }
            }
        }
        public void main5()
        {
            MusicCatalog catalog = new MusicCatalog();

            catalog.AddDisc("Best Rock");
            catalog.AddDisc("Chill Vibes");

            catalog.AddSongToDisc("Best Rock", new Song("Bohemian Rhapsody", "Queen", 6.0));
            catalog.AddSongToDisc("Best Rock", new Song("Back in Black", "AC/DC", 4.2));

            catalog.AddSongToDisc("Chill Vibes", new Song("Lovely", "Billie Eilish", 3.4));
            catalog.AddSongToDisc("Chill Vibes", new Song("Ocean Eyes", "Billie Eilish", 3.0));

            Console.WriteLine("Каталог:");
            catalog.ShowCatalog();

            Console.WriteLine("Диск:");
            catalog.ShowDisc("Chill Vibes");

            Console.WriteLine("\nSearch Billie Eilish:");
            catalog.SearchByArtist("Billie Eilish");

            Console.WriteLine("\nВидалення пісні 'Back in Black' із диску 'Best Rock':");
            catalog.RemoveSongFromDisc("Best Rock", "Back in Black");

            catalog.ShowDisc("Best Rock");
        }
    }
}