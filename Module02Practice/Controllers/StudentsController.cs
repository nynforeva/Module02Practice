using Microsoft.AspNetCore.Mvc;
using Module02Practice.Models;

namespace Module02Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> students = new()
        {
            new Student
            {
                Id = 1,
                Name = "Alex",
                Group = "SE-301"
            },

            new Student
            {
                Id = 2,
                Name = "Anna",
                Group = "SE-302"
            },

            new Student
            {
                Id = 3,
                Name = "Max",
                Group = "SE-301"
            }
        };

        // GET: api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(students);
        }

        // GET: api/students/2
        [HttpGet("{id:int}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public ActionResult<Student> Create(Student student)
        {
            students.Add(student);

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                student
            );
        }
    }
}