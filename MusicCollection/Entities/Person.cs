using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Entities
{
    public class Person
    {
        #region Main properties

        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Surname { get; set; }

        public Country? Country { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
