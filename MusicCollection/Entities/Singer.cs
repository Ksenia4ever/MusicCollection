namespace MusicCollection.Entities
{
    public class Singer
    {
        #region Main properties

        public int Id { get; set; }

        public Person Person { get; set; }

        public Band? Band { get; set; }

        public int YearFrom {  get; set; }

        public int YearTo { get; set; }

        public ICollection<Genre>? Genres { get; set; } = new List<Genre>();

        public string Biography {  get; set; }

        #endregion

        public override string ToString()
        {
            var title = $"[{Id}] - {Person?.ToString() ?? "-"}";
            var band = $"Band: {Band?.ToString()}";
            var years = $"Years: {YearFrom}-{YearTo}";
            var genres = $"Genres: {string.Join(", ", Genres.ToList())}";
            var b = !string.IsNullOrEmpty(Biography) ? Biography : "-";
            var boig = $"Biography: {b}";
            var res = string.Join("\r\n", title, band, years, genres, boig);
            return res;
        }
    }
}
