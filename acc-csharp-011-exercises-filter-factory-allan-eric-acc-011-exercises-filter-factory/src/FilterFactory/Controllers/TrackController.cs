using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilterFactory.Models;
using FilterFactory.Filters;

namespace FilterFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly MusicContext _context;

        public TrackController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/Track
        [HttpGet]
        [AddHeaderFilter("X-Action-Name", "GetTracks")]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            if (_context.Tracks == null)
            {
                return NotFound();
            }
            return await _context.Tracks.ToListAsync();
        }

        // GET: api/Track/{id}
        [HttpGet("{id}")]
        [AddHeaderFilter("X-Action-Name", "GetTrack")]
        public async Task<ActionResult<Track>> GetTrack(long id)
        {
            if (_context.Tracks == null)
            {
                return NotFound();
            }
            var track = await _context.Tracks.FindAsync(id);

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }

        // PUT: api/Track/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(long id, Track track)
        {
            if (id != track.TrackId)
            {
                return BadRequest();
            }

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Track
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(Track track)
        {
            if (_context.Tracks == null)
            {
                return Problem("Entity set 'MusicContext.Tracks'  is null.");
            }
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrack", new { id = track.TrackId }, track);
        }

        // DELETE: api/Track/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(long id)
        {
            if (_context.Tracks == null)
            {
                return NotFound();
            }
            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrackExists(long id)
        {
            return (_context.Tracks?.Any(e => e.TrackId == id)).GetValueOrDefault();
        }
    }
}
