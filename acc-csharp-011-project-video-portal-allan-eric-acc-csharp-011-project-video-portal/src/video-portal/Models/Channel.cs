namespace video_portal.Models
{
    public class Channel
    {
        public int ChannelId { get; set; }
        public string? ChannelName { get; set; }
        public string? ChannelDescription { get; set; }
        public string? Url { get; set; }
        public virtual ICollection<Video>? Videos { get; set; }
        public virtual ICollection<User>? Owners { get; set; }
    }
}
