using CalisthenicsRoutineTracker.Models;
using Microsoft.EntityFrameworkCore;
namespace CalisthenicsRoutineTracker.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Workout> Workouts {get; set;}
        public DbSet<Date> date { get; set; }   
    }
}