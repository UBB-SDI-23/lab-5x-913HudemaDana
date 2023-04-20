namespace Domain.DTOs
{
    internal class AlbumAndAvgVinyl
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Lyrics { get; set; }
        public DateTime? RealiseDate { get; set; } = DateTime.Now;
        public int? BandId { get; set; }
        public int? ArtistId { get; set; }
        public long? AverageVinylSize { get; set; }
    }
}
