using studentrepository.DTO;
using studentrepository.Interfaces;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Moq;
using FluentAssertions;
using Xunit;
using studentrepository.DTO;
using Newtonsoft.Json;
using Assert = NUnit.Framework.Assert;

namespace CollegeAPI.Test
{

    public class postxmlorjson
    {
        [Test]
        public async Task PostStudentJson_ReturnsCreatedStudentJson()
        {
            // Arrange
            var student = new Student()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Age = "25",
                Adrress = "123 Main St",
                university = "MIT"
            };
            string jsonStudent = JsonConvert.SerializeObject(student);
            string url = "http://localhost:7005/api/students/xml/json"; // Adjust URL if needed

            using (var client = new HttpClient())
            {
                // Act
                var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                // Assert
                response.EnsureSuccessStatusCode();
                var createdStudentJson = await response.Content.ReadAsStringAsync();
                var createdStudent = JsonConvert.DeserializeObject<Student>(createdStudentJson);

                Assert.AreEqual(student.Id, createdStudent.Id);
                Assert.AreEqual(student.FirstName, createdStudent.FirstName);
                Assert.AreEqual(student.LastName, createdStudent.LastName);
                Assert.AreEqual(student.Age, createdStudent.Age);
                Assert.AreEqual(student.Adrress, createdStudent.Adrress);
                Assert.AreEqual(student.university, createdStudent.university);
            }
        }
    }

}