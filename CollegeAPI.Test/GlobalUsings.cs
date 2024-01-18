global using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using studentrepository.DTO;
using System.Xml.Linq;
// ... other code

namespace CollegeAPI.test
{
    public static class StudentExtensions
    {
        public static string ToXml(this Student student)
        {
            // Implement the logic to convert the Student object to XML
            // For example, using System.Xml.Linq.XElement
                 var xml = new XElement("Student",
        new XElement("Id", student.Id),
        new XElement("FirstName", student.FirstName),
        new XElement("LastName", student.LastName),
        new XElement("Age", student.Age),
        student.Adrress != null ? new XElement("Address", student.Adrress) : null,
        student.university != null ? new XElement("University", student.university) : null
   
            );
            return xml.ToString();
        }
    }
}