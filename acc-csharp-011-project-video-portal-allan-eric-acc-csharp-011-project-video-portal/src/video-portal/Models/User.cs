namespace video_portal.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<Channel>? Channels { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
