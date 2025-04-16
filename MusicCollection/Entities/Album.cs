using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Entities
{
    public class Album
    {
        #region Main properties

        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public Singer Singer { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public int? Year {  get; set; }

        public Label? Lable { get; set; }

        public Format? Format { get; set; }

        #endregion

        #region ManyToMany relations

        public ICollection<PersonCollection> PersonCollections { get; set; } = new List<PersonCollection>();

        #endregion

        public override string ToString()
        {
            var title = $"[{Id}] - {Name}";
            var singer = $"Singer: {Singer?.Person?.ToString() ?? string.Empty}";
            var genres = $"Genres: {string.Join(", ", Genres.ToList())}";
            var year = $"Year: {Year?.ToString() ?? "-"}";
            var label = $"Label: {Lable?.ToString() ?? "-"}";
            var format = $"Format: {Format?.ToString() ?? "-"}";

            var res = string.Join("\r\n", title, singer, genres, year, label, format);
            return res;
        }
    }
}
