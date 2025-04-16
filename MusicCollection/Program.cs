using MusicCollection.Data;

namespace MusicCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MusicDbContext())
            {
                //db.PopulateDb();

                db.ShowAlbums();
                db.ShowTracks();
                db.ShowSingers();
                db.ShowRatings();
                db.ShowTrackLists();
                db.ShowPersonCollections();

                Console.WriteLine();
                Console.WriteLine("--- Add New Singer (J.Elton) ---");
                db.AddSinger("John", "Elton", string.Empty, 1973, 2025, string.Empty);
                db.ShowSingers();

                Console.WriteLine();
                Console.WriteLine("--- Remove Singer (J.Elton) ---");
                db.RemoveSinger("John", "Elton", true);
                db.ShowSingers();

                Console.WriteLine();
                Console.WriteLine("--- Find tracks with \"we\" ---");
                var tacks = db.FindTracks("We");
                db.ShowTracks(tacks);

                Console.WriteLine();
                Console.WriteLine("--- Get albums sorted by alphabet ---");
                var albums = db.GetAlbumsSorted();
                db.ShowAlbums(albums);
            }
        }
    }
}
