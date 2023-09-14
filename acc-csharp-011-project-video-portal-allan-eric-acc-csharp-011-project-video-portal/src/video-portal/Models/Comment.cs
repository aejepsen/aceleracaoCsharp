namespace video_portal.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? CommentText { get; set; }
        public int VideoId { get; set; }
        public virtual Video? Video { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
