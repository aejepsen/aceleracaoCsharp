using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_validation.Models;
// ok
namespace student_validation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly SchoolContext _context;

    public StudentController(SchoolContext context)
    {
        _context = context;
    }

    // GET: api/Student
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        if (_context.Students == null)
        {
            return NotFound();
        }
        return await _context.Students.ToListAsync();
    }

    // GET: api/Student/{registration}
    [HttpGet("{registration}")]
    public async Task<ActionResult<Student>> GetStudent(int registration)
    {
        if (_context.Students == null)
        {
            return NotFound();
        }
        var student = await _context.Students.FindAsync(registration);

        if (student == null)
        {
            return NotFound();
        }

        return student;
    }

    // PUT: api/Student/{registration}
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{registration}")]
    public async Task<IActionResult> PutStudent(int registration, Student student)
    {
        if (registration != student.Registration)
        {
            return BadRequest();
        }

        _context.Entry(student).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(registration))
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

    // POST: api/Student
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
        if (_context.Students == null)
        {
            return Problem("Entity set 'SchoolContext.Students'  is null.");
        }
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetStudent", new { registration = student.Registration }, student);
    }

    // DELETE: api/Student/{registration}
    [HttpDelete("{registration}")]
    public async Task<IActionResult> DeleteStudent(int registration)
    {
        if (_context.Students == null)
        {
            return NotFound();
        }
        var student = await _context.Students.FindAsync(registration);
        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool StudentExists(int registration)
    {
        return (_context.Students?.Any(e => e.Registration == registration)).GetValueOrDefault();
    }
}
