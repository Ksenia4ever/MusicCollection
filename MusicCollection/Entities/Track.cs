using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Entities
{
    public class Track
    {
        #region Main properties

        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public Album? Album { get; set; }

        [Range(1,int.MaxValue)]
        public int AlbumNumber {  get; set; }

        public Person? MusicAuthor { get; set; }

        public Person? TextAuthor { get; set; }

        #endregion

        #region ManyToMany relations

        public ICollection<TrackList> TrackLists { get; set; } = new List<TrackList>();

        #endregion

        public override string ToString()
        {
            var title = $"[{Id}] - {Name}";
            var duration = $"Duration: {Duration.ToString()}";
            var album = $"Album: {Album?.Name ?? "-"}";
            var anum = $"Track#: {AlbumNumber}";
            var mauthor = $"Music author: {MusicAuthor?.ToString() ?? "-"}";
            var tauthor = $"Text author: {TextAuthor?.ToString() ?? "-"}";

            var res = string.Join("\r\n", title, duration, album, anum, mauthor, tauthor);
            return res;
        }
    }
}
