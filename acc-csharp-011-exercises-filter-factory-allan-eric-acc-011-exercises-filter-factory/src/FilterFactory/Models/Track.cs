namespace FilterFactory.Models
{
    public partial class Track
    {
        public Track()
        {
            Playlists = new HashSet<Playlist>();
        }

        public long TrackId { get; set; }
        public string Name { get; set; } = null!;
        public string? Composer { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
