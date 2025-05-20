using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;

namespace project.Models
{
    public class ITIMVCDBContext : DbContext
    {
        public DbSet <Department>Departments{ get; set; }
        public DbSet <Trainee>Trainees{ get; set; }
        public DbSet <Course>Courses{ get; set; }
        public DbSet<CrsResult> CrsResults{ get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public ITIMVCDBContext():base(){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-AQH1P69\\SQLEXPRESS;Initial Catalog=ITIMVC;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

            optionsBuilder.UseLazyLoadingProxies();
                base.OnConfiguring(optionsBuilder);
        }


    }
}
