using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using studentrepository.Interfaces;
using System.Globalization;
using System.IO;
using System.Text;

public class StudentService
{
    private readonly IStudentRepository _studentRepo;

    public StudentService(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public FileStreamResult GetReportFileStream(string format)
    {
        if (format == "csv")
        {
            var (report, contentType) = GetCSVReport();
            return CreateFileStreamResult(report, contentType);
        }
        else if (format == "json")
        {
            var (report, contentType) = GetJSONReport();
            return CreateFileStreamResult(report, contentType);
        }
        else
        {
            throw new ArgumentException("Invalid format specified. Supported formats: csv, json");
        }
    }

    private (string report, string contentType) GetCSVReport()
    {
        var students = _studentRepo.GetAllStudent();
        var memoryStream = new MemoryStream();

        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8, 1024, true))
        using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(students);
        }

        memoryStream.Seek(0, SeekOrigin.Begin);
        var report = new StreamReader(memoryStream).ReadToEnd();

        return (report, "text/csv");
    }

    private (string report, string contentType) GetJSONReport()
    {
        var students = _studentRepo.GetAllStudent();
        var jsonReport = JsonConvert.SerializeObject(students);

        return (jsonReport, "application/json");
    }

    
    private FileStreamResult CreateFileStreamResult(string report, string contentType)
    {
        var tempFilePath = Path.GetTempFileName();
        System.IO.File.WriteAllText(tempFilePath, report);

        var fileStream = System.IO.File.OpenRead(tempFilePath);
        return new FileStreamResult(fileStream, contentType);
    }
}
