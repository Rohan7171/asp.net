using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Xml.Linq;
using studentrepository.DTO;
using CollegeAPI.test;

[TestFixture]
public class YourControllerTests
{
    private const string BaseUrl = " http://localhost:5120";
    public const string endpoint = "/api/students/xml/json";

    [Test]
    public async Task PostWithXmlOrJson_ValidJsonData_ReturnsOk()
    {
        // Arrange
        var httpClient = new HttpClient();
       // Replace with the actual endpoint of your API

        var student = new Student
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Age = "25",
            Adrress = "123 Main St",
            university = "MIT"
        };

        var jsonContent = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");

        // Act
        var response = await httpClient.PostAsync(BaseUrl + endpoint, jsonContent);

        // Assert
        response.EnsureSuccessStatusCode();
        // Add additional assertions if needed
        Assert.AreEqual(200, (int)response.StatusCode);
    }

    [Test]
    public async Task PostWithXmlOrJson_ValidXmlData_ReturnsOk()
    {
        // Arrange
        var httpClient = new HttpClient();
        var student = new Student
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Age = "25",
            Adrress = "123 Main St",
            university = "MIT"
        };
        Console.WriteLine(student.ToXml());
        var xmlContent = new StringContent(student.ToXml(), Encoding.UTF8, "application/xml");

        // Act
        var response = await httpClient.PostAsync(BaseUrl + endpoint, xmlContent);

        // Assert
        //response.EnsureSuccessStatusCode();
        Assert.AreEqual(200, (int)response.StatusCode);

        // Add additional assertions if needed
    }
}


