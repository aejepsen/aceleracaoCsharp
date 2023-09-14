namespace FilterFactory.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            Tracks = new HashSet<Track>();
        }

        public long PlaylistId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
