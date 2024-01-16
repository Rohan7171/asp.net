using studentrepository.DTO;
using studentrepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization; // For XML serialization



namespace CollegeAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private IStudentRepository _studentrepo;
        private readonly StudentService _studentService;

        public StudentsController(IStudentRepository studentrepo, StudentService studentService)
        {
            _studentrepo = studentrepo;
            _studentService = studentService;
        }
        //uploaded to git
        [HttpGet]
        public IActionResult Index()
        {
            var a = _studentrepo.GetAllStudent();
            if (a == null)
            {
                return NotFound();
            }
            return Ok(a);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            Student p = _studentrepo.GetStudentById(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        public IActionResult Creates(Student pt)
        {
            int rs = _studentrepo.CreateStudent(pt);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Added! " + rs);
        }

        [HttpPut]
        public IActionResult Edit(Student pt)
        {
            int rs = _studentrepo.UpdateStudent(pt);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Updated! " + rs);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int rs = _studentrepo.DeleteStudent(id);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Deleted! " + rs);
        }


        [HttpGet("download")]
        public IActionResult DownloadStudents([FromQuery] string format)
        {
            try
            {
                return _studentService.GetReportFileStream(format);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("xml/json")]
        [Consumes("application/xml", "application/json")]
        [Produces("application/xml", "application/json")]
        public IActionResult PostWithXmlOrJson([FromBody] Student student)
        {
            try
            {
                // Perform data processing (e.g., store in database)
                _studentrepo.CreateStudent(student);

                // Determine response format based on Accept header
                    return Ok(student);
                            }
            catch (Exception ex)
            {
                // Handle errors gracefully
                return StatusCode(500, "Error processing request: " + ex.Message);
            }
        }
    }
    }
