using video_portal.Models;

namespace video_portal.Repository
{
    public class VideoPortalRepository : IVideoPortalRepository
    {
        private readonly IVideoPortalContext _context;
        public VideoPortalRepository(IVideoPortalContext context)
        {
            _context = context;
        }
        public Video GetVideoById(int videoId)
        {
            return _context.Videos.Where(v => v.VideoId == videoId).First();
        }
        public IEnumerable<Video> GetVideos()
        {
            return _context.Videos.ToList();
        }
        public Channel GetChannelById(int channelId)
        {
            return _context.Channels.Where(c => c.ChannelId == channelId).First();
        }
        public IEnumerable<Channel> GetChannels()
        {
            return _context.Channels.ToList();
        }
        public IEnumerable<Video> GetVideosByChannelId(int channelId)
        {
            return _context.Videos.Where(v => v.ChannelId == channelId);
        }
        public IEnumerable<Comment> GetCommentsByVideoId(int videoId)
        {
            return _context.Comments.Where(c => c.VideoId == videoId);
        }
        public void DeleteChannel(Channel channel)
        {
            var entity = _context.Channels.Where(c => c.ChannelId == channel.ChannelId).First();

            if (entity.Videos != null && entity.Videos.Any())
                throw new InvalidOperationException();

            _context.Channels.Remove(entity);
            _context.SaveChanges();
        }
        public void AddVideoToChannel(Channel channel, Video video)
        {
            if (channel == null || video == null)
                throw new InvalidOperationException();

            var entity = _context.Videos.FirstOrDefault(v => v.VideoId == video.VideoId);

            if (entity == null)
                throw new InvalidOperationException();

            entity.ChannelId = channel.ChannelId;
            entity.Channel = channel;

            _context.SaveChanges();
        }
    }
}
