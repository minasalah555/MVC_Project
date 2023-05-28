using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using University.Models;

namespace University.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<RegisterViewModel> Accounts { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Departments> departments { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<proffessor> proffessor { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<assistant_course> assistant_course { get; set; }
        public DbSet<assistant_proffessor> assistant_proffessor { get; set; }
        public DbSet<proffessor_course> proffessor_course { get; set; }
        public DbSet<student_assistant> student_assistant { get; set; }
        public DbSet<student_course> student_course { get; set; }
        public DbSet<student_proffessor> student_proffessor { get; set; }

    }
}
