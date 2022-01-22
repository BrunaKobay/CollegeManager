using CollegeManager.Models;
using System.Data.Entity;

namespace CollegeManager.Data
{
    public class DataContext : DbContext
    {
        public DataContext(string connString) : base(connString) 
        {
            Database.SetInitializer<DataContext>(new DbInitializer());
        }

        public DbSet<Course> Coursers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Enrollment>()
                .HasRequired(p => p.Student)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(c => c.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasRequired(p => p.Subject)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(c => c.SubjectId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
