using System.Diagnostics;

namespace MusicCollection.Entities
{
    public class PersonCollection
    {
        #region Main properties

        public int Id { get; set; }

        public ICollection<Album> Albums { get; set; } = new List<Album>();

        public DateTime? CreationData { get; set; }

        public CollectionStatus Status { get; set; }

        #endregion

        public override string ToString()
        {
            var title = $"[{Id}]";
            var status = $"Status: {Status?.ToString() ?? "-"}";
            var created = $"Created: {CreationData?.ToString() ?? "-"}";
            var albums = Albums != null ? string.Join("\n\t", Albums.Select(a => a.Name)) : "-";
            var albumlist = $"Albums: {albums}";

            var res = string.Join("\r\n", title, status, created, albumlist);
            return res;
        }
    }
}
