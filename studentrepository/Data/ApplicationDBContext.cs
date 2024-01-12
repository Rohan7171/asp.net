using studentrepository.DTO;
using Microsoft.EntityFrameworkCore;

namespace studentrepository.Data
{

    public class AppDBContext : DbContext
        {
            public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
            {
            }
            public virtual DbSet<Student> Students { get; set; }
        }

    }