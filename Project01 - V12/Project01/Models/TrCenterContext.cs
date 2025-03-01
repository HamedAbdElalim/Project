using Microsoft.EntityFrameworkCore;

namespace Project01.Models
{
    public class TrCenterContext :DbContext
    {
        public TrCenterContext(DbContextOptions<TrCenterContext> options) : base(options)
        {
            
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }

        public DbSet<Instructor> Instructor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=HAMED;Database=TrainingCenter;Trusted_Connection=True;Encrypt=False");
        }


    }
}
