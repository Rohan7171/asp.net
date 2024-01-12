using studentrepository.DTO;
using studentrepository.Interfaces;
using Microsoft.Extensions.Configuration;
using studentrepository.Data;

namespace studentrepository.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;

        // Uncomment if using a database:
        private readonly AppDBContext _context;

        public StudentRepository(IConfiguration configuration, AppDBContext db)
        {
            _configuration = configuration;
             _context = db;

        }

    public int CreateStudent(Student student)
        {
            
                int result = -1;
                if (student == null)
                {
                    result = 0;
                }
                else
                {
                    // Access university name from appsettings.json
                    student.university = _configuration["University"];
                    _context.Students.Add(student);
                    _context.SaveChanges();
                    result = student.Id;
                }
                return result;
            
        }

        public IEnumerable<Student> GetAllStudent()
        {
           
                // Add SQL query to fetch students from the database
                return _context.Students.ToList(); // Replace with actual database query
            
        }

        public Student GetStudentById(int id)
        {
           
             
                    return _context.Students.Find(id); // Assuming _context is an Entity Framework DbContext
               
            
        }

        public int UpdateStudent(Student student)
        {
          
                // Add SQL operations to update student in the database
                return student.Id; // Replace with actual result of database update
            
        }

        public int DeleteStudent(int id)
        {
           
                // Add SQL operations to delete student from the database
                return id; // Replace with actual result of database deletion
            
        }

       
    }
}
