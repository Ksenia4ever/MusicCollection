using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Entities
{
    public class TrackList
    {
        #region Main properties

        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public Person Author { get; set; }

        public ICollection<Track> Tracks { get; set; } = new List<Track>();

        public DateTime CreationData { get; set; }= DateTime.Now;

        #endregion

        public override string ToString()
        {
            var title = $"[{Id}] - {Name}";
            var author = $"Author: {Author?.ToString() ?? "-"}";
            var created = $"Created: {CreationData.ToString()}";
            var tracks = Tracks != null ? string.Join("\n\t", Tracks.Select(t => t.Name)) : "-";
            var tracklist = $"Tracks: {tracks}";

            var res = string.Join("\r\n", title, author, created, tracklist);
            return res;
        }
    }
}
