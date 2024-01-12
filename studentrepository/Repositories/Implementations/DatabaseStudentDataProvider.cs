using studentrepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentrepository.Data;
using Microsoft.Extensions.Configuration;
using studentrepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace studentrepository.Repositories.Implementations
{// Static data provider
   

    public class DatabaseStudentDataProvider : IStudentRepository
    {

        private readonly List<Student> _students = MyStaticData.Students;

        public DatabaseStudentDataProvider(List<Student> students)
        {
            _students = students;
        }

        
        public Student GetStudentById(int id) => _students.FirstOrDefault(s => s.Id == id);


        public int CreateStudent(Student student)
        {
               
                    student.Id = _students.Count + 1;
                    _students.Add(student);
                    return student.Id;
             
        }

        public int DeleteStudent(int id)
        {
            _students.RemoveAll(s => s.Id == id);
            return id;
        }

        

        public IEnumerable<Student> GetAllStudent()
        {
            return _students;
        }

       
        public int UpdateStudent(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Age = student.Age;
                existingStudent.Adrress = student.Adrress;
                existingStudent.university = "University";
            }
            return student.Id;
        }

       
    }
    


}
