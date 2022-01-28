using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsCoursesController : ControllerBase
    {
        private readonly SchoolDBContext _context;

        public StudentsCoursesController(SchoolDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentsCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsCourses>>> GetStudentsCourses()
        {
            return await _context.StudentsCourses.ToListAsync();
        }

        // GET: api/GetActiveStudentsCourses
        [HttpGet("GetActiveStudentsCourses")]
        public async Task<IEnumerable<StudentsCourses>> GetActiveStudentsCourses()
        {
            return  await _context.StudentsCourses.Where(z=>z.Status == "In progress").ToListAsync();
        }
        // GET: api/StudentsCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsCourses>> GetStudentsCourses(int id)
        {
            var studentsCourses = await _context.StudentsCourses.FindAsync(id);

            if (studentsCourses == null)
            {
                return NotFound();
            }

            return studentsCourses;
        }
        
        // PUT: api/StudentsCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsCourses(int id, StudentsCourses studentsCourses)
        {
            if (id != studentsCourses.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentsCourses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsCoursesExists(id))
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

        // POST: api/StudentsCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsCourses>> PostStudentsCourses(StudentsCourses studentsCourses)
        {
            _context.StudentsCourses.Add(studentsCourses);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentsCoursesExists(studentsCourses.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentsCourses", new { id = studentsCourses.StudentId }, studentsCourses);
        }

        // DELETE: api/StudentsCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsCourses(int id)
        {
            var studentsCourses = await _context.StudentsCourses.FindAsync(id);
            if (studentsCourses == null)
            {
                return NotFound();
            }

            _context.StudentsCourses.Remove(studentsCourses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsCoursesExists(int id)
        {
            return _context.StudentsCourses.Any(e => e.StudentId == id);
        }
    }
}
