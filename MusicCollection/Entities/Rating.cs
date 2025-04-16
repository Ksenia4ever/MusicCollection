using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Entities
{
    public class Rating
    {
        #region Main properties

        public int Id { get; set; }

        public Person? Person { get; set; } // Person is nullable beacuse we allow anonymous comments

        public Album Album { get; set; }

        [Range(1, 5)]
        public int? Score { get; set; }

        public string Comment { get; set; }

        #endregion

        public override string ToString()
        {
            var title = $"[{Id}] - {Person?.ToString() ?? "(anonymous)"}";
            var album = $"Album: {Album?.Name ?? "-"}";
            var score = $"Score: {Score?.ToString() ?? "-"}";
            var comment = $"Comment: {Comment}";

            var res = string.Join("\r\n", title, album, score, comment);
            return res;
        }
    }
}
