using studentrepository.Data;
using studentrepository.Repositories.Implementations;
using studentrepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using studentrepository.DTO;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<StudentService, StudentService>();
var isTrue = bool.Parse(builder.Configuration["UseHardcodedData"]);

if (isTrue)
{
    builder.Services.AddSingleton<List<Student>>(MyStaticData.Students);

    builder.Services.AddScoped<IStudentRepository, DatabaseStudentDataProvider>();

}
else
{
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();
}



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
