using Microsoft.EntityFrameworkCore;
using studentrepository.DTO;

namespace studentrepository.Interfaces
{
    public interface IStudentRepository 
    {
        IEnumerable<Student> GetAllStudent();
        Student GetStudentById(int id);
        int CreateStudent(Student student);
        int UpdateStudent(Student student);
        int DeleteStudent(int id);
        
    }
}
