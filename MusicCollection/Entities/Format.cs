using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Entities
{
    public class Format
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
