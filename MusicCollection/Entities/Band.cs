using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Entities
{
    public class Band
    {
        #region Main properties

        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}
