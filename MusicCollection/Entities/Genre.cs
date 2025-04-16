using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Entities
{
    public class Genre
    {
        #region Main properties

        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        #endregion

        #region ManyToMany relations

        public ICollection<Album> Albums { get; set; } = new List<Album>();

        public ICollection<Singer> Singers { get; set; } = new List<Singer>();

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}
