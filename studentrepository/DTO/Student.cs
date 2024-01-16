using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace studentrepository.DTO
{
    [XmlRoot("Student")]

    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; }
        public string Age { get; set; }
        public string? Adrress { get; set; }
        public string? university { get; set; }

    }
}

