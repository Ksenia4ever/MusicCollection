using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Entities
{
    public class Country
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
