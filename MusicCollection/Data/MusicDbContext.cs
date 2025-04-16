using Microsoft.EntityFrameworkCore;
using MusicCollection.Entities;
using System.Data;

namespace MusicCollection.Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Format> Formats { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<Singer> Singers { get; set; }

        public DbSet<Band> Bands { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<CollectionStatus> CollectionStatuses { get; set; }

        public DbSet<PersonCollection> Collections { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<TrackList> TrackLists { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MusicDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connStr);
        }

        public void PopulateDb()
        {
            Countries.AddRange(new Country() { Name = "Ukraine" },
                               new Country() { Name = "USA" },
                               new Country() { Name = "Britan" });

            SaveChanges();

            Genres.AddRange(new Genre() { Name = "Soul" },
                            new Genre() { Name = "Pop" },
                            new Genre() { Name = "Rock" },
                            new Genre() { Name = "Classical" },
                            new Genre() { Name = "Metal" },
                            new Genre() { Name = "Punk" });

            SaveChanges();

            Persons.AddRange(new Person()
            {
                Name = "Freddie",
                Surname = "Mercury",
                Country = Countries.ElementAt(2)
            },
                             new Person()
                             {
                                 Name = "John",
                                 Surname = "Lennon",
                                 Country = Countries.ElementAt(2)
                             },
                             new Person()
                             {
                                 Name = "Adele",
                                 Surname = string.Empty,
                                 Country = Countries.ElementAt(1)
                             },
                             new Person()
                             {
                                 Name = "Ksina",
                                 Surname = "Kiselgova",
                                 Country = Countries.ElementAt(0)
                             });

            SaveChanges();

            Formats.AddRange(new Format() { Name = "CD" },
                             new Format() { Name = "Vinyl" },
                             new Format() { Name = "Digital" });

            SaveChanges();

            Labels.AddRange(new Label() { Name = "Universal Music Group" },
                            new Label() { Name = "Sony Music Entertainment" },
                            new Label() { Name = "Warner Music Group" });

            SaveChanges();

            Bands.AddRange(new Band() { Name = "Queen" },
                           new Band() { Name = "Beatles" });

            SaveChanges();

            Singers.AddRange(new Singer()
                             {
                                 Person = Persons.ElementAt(0),
                                 Band = Bands.ElementAt(0),
                                 YearFrom = 1970,
                                 YearTo = 1991,
                                 Genres = new List<Genre>() { Genres.ElementAt(1), Genres.ElementAt(2) },
                                 Biography = string.Empty
                             },
                             new Singer()
                             {
                                 Person = Persons.ElementAt(1),
                                 Band = Bands.ElementAt(1),
                                 YearFrom = 1960,
                                 YearTo = 1980,
                                 Genres = new List<Genre>() { Genres.ElementAt(1), Genres.ElementAt(2) },
                                 Biography = string.Empty
                             },
                             new Singer()
                             {
                                 Person = Persons.ElementAt(2),
                                 Band = null,
                                 YearFrom = 2006,
                                 YearTo = 2025,
                                 Genres = new List<Genre>() { Genres.ElementAt(1) },
                                 Biography = "Adele Laurie Blue Adkins, known professionally as Adele," +
                                             " is a British singer and songwriter born on May 5, 1988, in Tottenham, London. " +
                                             "She rose to fame with her debut album 19 in 2008, which showcased her soulful voice and emotional" +
                                             " lyrics. Her second album 21 brought international success, winning multiple Grammy Awards." +
                                             " Adele is known for hits like Hello, Rolling in the Deep, and Someone Like You. " +
                                             "She continues to be one of the best-selling music artists in the world"
                             });

            SaveChanges();

            Albums.AddRange(new Album()
                            {
                                Name = "A Night at the Opera",
                                Singer = Singers.ElementAt(0),
                                Genres = new List<Genre>() { Genres.ElementAt(2) },
                                Year = 1975,
                                Lable = Labels.ElementAt(0),
                                Format = Formats.ElementAt(0)
                            },
                            new Album()
                            {
                                Name = "News of the World",
                                Singer = Singers.ElementAt(0),
                                Genres = new List<Genre>() { Genres.ElementAt(2) },
                                Year = 1977,
                                Lable = Labels.ElementAt(0),
                                Format = Formats.ElementAt(0)
                            },
                            new Album()
                            {
                                Name = "Imagine",
                                Singer = Singers.ElementAt(1),
                                Genres = new List<Genre>() { Genres.ElementAt(1), Genres.ElementAt(2) },
                                Year = 1971,
                                Lable = Labels.ElementAt(1),
                                Format = Formats.ElementAt(0)
                            },
                            new Album()
                            {
                                Name = "21",
                                Singer = Singers.ElementAt(2),
                                Genres = new List<Genre>() { Genres.ElementAt(1), Genres.ElementAt(0) },
                                Year = 2011,
                                Lable = Labels.ElementAt(2),
                                Format = Formats.ElementAt(2)
                            },
                            new Album()
                            {
                                Name = "25",
                                Singer = Singers.ElementAt(2),
                                Genres = new List<Genre>() { Genres.ElementAt(1), Genres.ElementAt(0) },
                                Year = 1977,
                                Lable = Labels.ElementAt(2),
                                Format = Formats.ElementAt(2)
                            });

            SaveChanges();

            Tracks.AddRange(new Track()
                            {
                                Name = "Bohemian Rhapsody",
                                Duration = TimeSpan.FromSeconds(355),
                                Album = Albums.ElementAt(0),
                                AlbumNumber = 5
                            },
                            new Track()
                            {
                                Name = "We Will Rock You",
                                Duration = TimeSpan.FromSeconds(121),
                                Album = Albums.ElementAt(1),
                                AlbumNumber = 3,
                                MusicAuthor=Persons.ElementAt(0),
                                TextAuthor=Persons.ElementAt(0)
                            },
                            new Track()
                            {
                                Name = "We Are the Champions",
                                Duration = TimeSpan.FromSeconds(179),
                                Album = Albums.ElementAt(0),
                                AlbumNumber = 7
                            },
                            new Track()
                            {
                                Name = "Imagine​",
                                Duration = TimeSpan.FromSeconds(178),
                                Album = Albums.ElementAt(2),
                                AlbumNumber = 3,
                                MusicAuthor = Persons.ElementAt(1),
                                TextAuthor = Persons.ElementAt(1)
                            },
                            new Track()
                            {
                                Name = "Instant Karma!",
                                Duration = TimeSpan.FromSeconds(200)
                            },
                            new Track()
                            {
                                Name = "Jealous Guy",
                                Duration = TimeSpan.FromSeconds(256),
                                Album = Albums.ElementAt(2),
                                AlbumNumber = 1
                            },
                            new Track()
                            {
                                Name = "Rolling in the Deep",
                                Duration = TimeSpan.FromSeconds(228),
                                Album = Albums.ElementAt(0),
                                AlbumNumber = 1
                            },
                            new Track()
                            {
                                Name = "Someone Like You",
                                Duration = TimeSpan.FromSeconds(285),
                                Album = Albums.ElementAt(0),
                                AlbumNumber = 2
                            },
                            new Track()
                            {
                                Name = "Hello",
                                Duration = TimeSpan.FromSeconds(295),
                                Album = Albums.ElementAt(0),
                                AlbumNumber = 8
                            });

            SaveChanges();

            CollectionStatuses.AddRange(new CollectionStatus() { Name = "Bought" },
                                        new CollectionStatus() { Name = "Favourite" });

            SaveChanges();

            Collections.AddRange(new PersonCollection()
                                 {
                                     Albums = new List<Album>() { Albums.ElementAt(0) },
                                     CreationData = DateTime.Now,
                                     Status = CollectionStatuses.ElementAt(0)
                                 },
                                 new PersonCollection()
                                 {
                                     Albums = new List<Album>() { Albums.ElementAt(3) },
                                     CreationData = DateTime.Now,
                                     Status = CollectionStatuses.ElementAt(0)
                                 });

            SaveChanges();

            Ratings.AddRange(new Rating()
                             {
                                 Person = Persons.ElementAt(0),
                                 Album = Albums.ElementAt(0),
                                 Score = 5,
                                 Comment = "Cool!"
                             },
                             new Rating()
                             {
                                 Person = Persons.ElementAt(0),
                                 Album = Albums.ElementAt(0),
                                 Score = 5,
                                 Comment = "Very good"
                             },
                             new Rating()
                             {
                                 Person = Persons.ElementAt(1),
                                 Album = Albums.ElementAt(2),
                                 Score = 4,
                                 Comment = "not bad"
                             },
                             new Rating()
                             {
                                 Person = Persons.ElementAt(2),
                                 Album = Albums.ElementAt(3),
                                 Score = 5,
                                 Comment = "Cool!"
                             });

            SaveChanges();

            TrackLists.AddRange(new TrackList()
            {
                Name = "My",
                Author = Persons.ElementAt(3),
                Tracks = new List<Track>() { Tracks.ElementAt(0), Tracks.ElementAt(4) }
            });

            SaveChanges();
        }

        public int GetTrackCount(Album album)
        {
            var res = Tracks.Include(t => t.Album)
                            .Where(t => t.Album != null && t.Album.Id == album.Id)
                            .Count();
            return res;
        }

        public void ShowAlbums(IEnumerable<Album>? albums = null)
        {
            Console.WriteLine("--- Albums ---");

            if (albums == null)
            {
                albums = Albums.Include(a => a.Singer).ThenInclude(s => s.Person)
                               .Include(a => a.Genres)
                               .Include(a => a.Lable)
                               .Include(a => a.Format).ToList();
            }

            foreach (var a in albums)
            {
                Console.WriteLine(a);
                Console.WriteLine($"Tracks: {GetTrackCount(a)}");
                Console.WriteLine();
            }
        }

        public void ShowTracks(IEnumerable<Track>? tracks = null)
        {
            Console.WriteLine("--- Tracks ---");

            if (tracks == null)
            {
                tracks = Tracks.Include(t => t.Album)
                               .Include(t => t.MusicAuthor)
                               .Include(t => t.TextAuthor).ToList();
            }

            foreach (var t in tracks)
            {
                Console.WriteLine(t);
                Console.WriteLine();
            }
        }

        public void ShowSingers(IEnumerable<Singer>? singers = null)
        {
            Console.WriteLine("--- Singers ---");

            if (singers == null)
            {
                singers = Singers.Include(s => s.Person)
                                 .Include(s => s.Genres)
                                 .Include(s => s.Band).ToList();
            }

            foreach (var s in singers)
            {
                Console.WriteLine(s);
                Console.WriteLine();
            }
        }

        public void ShowRatings(IEnumerable<Rating>? ratings = null)
        {
            Console.WriteLine("--- Album Ratings ---");

            if (ratings == null)
            {
                ratings = Ratings.Include(r => r.Person)
                                 .Include(r => r.Album).ToList();
            }

            foreach (var r in ratings)
            {
                Console.WriteLine(r);
                Console.WriteLine();
            }
        }

        public void ShowTrackLists(IEnumerable<TrackList>? trackLists = null)
        {
            Console.WriteLine("--- Track Lists ---");

            if (trackLists == null)
            {
                trackLists = TrackLists.Include(t => t.Author)
                                       .Include(t => t.Tracks).ToList();
            }

            foreach (var t in trackLists)
            {
                Console.WriteLine(t);
                Console.WriteLine();
            }
        }

        public void ShowPersonCollections(IEnumerable<PersonCollection>? collections = null)
        {
            Console.WriteLine("--- Personal Collections ---");

            if (collections == null)
            {
                collections = Collections.Include(t => t.Albums)
                                         .Include(t => t.Status).ToList();
            }

            foreach (var c in collections)
            {
                Console.WriteLine(c);
                Console.WriteLine();
            }
        }

        public void AddSinger(string name, string surname, string band, int yearf, int yeart, string biography)
        {
            var person = Persons.Where(p => p.Name == name && p.Surname == surname)
                                .FirstOrDefault();
            if (person == null)
            {
                person = new Person() { Name = name, Surname = surname };
                Persons.Add(person);

                SaveChanges();
            }
            else
            {
                var s = Singers.Include(s => s.Person)
                               .Where(s => s.Person.Id == person.Id)
                               .FirstOrDefault();
                if (s != null)
                {
                    return;
                }
            }

            var b = (Band)null;
            if (!string.IsNullOrEmpty(band))
            {
                b = Bands.Where(b => b.Name == band)
                         .FirstOrDefault();
                if (b == null)
                {
                    b = new Band() { Name = band };
                    Bands.Add(b);

                    SaveChanges();
                }
            }

            var singer = new Singer()
            {
                Person = person,
                Band = b,
                YearFrom = yearf,
                YearTo = yeart,
                Biography = biography
            };
            Singers.Add(singer);

            SaveChanges();
        }

        public void RemoveSinger(string name, string surname, bool removePerson)
        {
            var person = Persons.Where(p => p.Name == name && p.Surname == surname)
                                .FirstOrDefault();
            if (person != null)
            {
                var s = Singers.Include(s => s.Person)
                               .Where(s => s.Person.Id == person.Id)
                               .FirstOrDefault();
                if (s != null)
                {
                    Singers.Remove(s);

                    if (removePerson)
                    {
                        Persons.Remove(person);
                    }

                    SaveChanges();
                }
            }
        }

        public IEnumerable<Track> FindTracks(string name)
        {
            var tracks = Tracks.Where(t => t.Name.Contains(name))
                               .Include(t => t.Album)
                               .Include(t => t.MusicAuthor)
                               .Include(t => t.TextAuthor)
                               .ToList();
            return tracks;
        }

        public IEnumerable<Album> GetAlbumsSorted()
        {
            var albums = Albums.Include(a => a.Singer).ThenInclude(s => s.Person)
                               .Include(a => a.Genres)
                               .Include(a => a.Lable)
                               .Include(a => a.Format)
                               .OrderBy(a => a.Name)
                               .ToList();
            return albums;
        }
    }
}
