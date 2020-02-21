using System.Linq.Expressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using payroll_app.Models.repository;

namespace payroll_app.Data
{
    public class payroll_app_context:DbContext
    {
        public payroll_app_context(DbContextOptions<payroll_app_context> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasKey(s => s.DepartmentId);
            modelBuilder.Entity<Department>().HasAlternateKey(s => s.DepartmentName);
            modelBuilder.Entity<Department>().HasAlternateKey(s => s.DepartmentCode);

            modelBuilder.Entity<Designation>().HasKey(s => s.DesignationId);
            modelBuilder.Entity<Designation>().HasAlternateKey(s => s.DesignationName);
            modelBuilder.Entity<Designation>().HasAlternateKey(s => s.DesignationCode);

            modelBuilder.Entity<Shift>().HasKey(s => s.ShiftId);
            modelBuilder.Entity<Shift>().HasAlternateKey(s => s.ShiftName);
            modelBuilder.Entity<Shift>().HasAlternateKey(s => s.ShiftCode);

            modelBuilder.Entity<Grade>().HasKey(s => s.GradeId);
            modelBuilder.Entity<Grade>().HasAlternateKey(s => s.GradeName);
            modelBuilder.Entity<Grade>().HasAlternateKey(s => s.GradeCode);

            modelBuilder.Entity<Employee>().HasKey(s => s.EmployeeId);
            modelBuilder.Entity<Employee>().HasAlternateKey(s => s.AadharNo);

            modelBuilder.Entity<AttendanceRegister>().HasKey(s => s.AttendanceRegisterId);

            modelBuilder.Entity<Category>().HasKey(s => s.CategoryId);
            modelBuilder.Entity<Category>().HasAlternateKey(s => s.CategoryName);
            modelBuilder.Entity<Category>().HasAlternateKey(s => s.CategoryCode);
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<AttendanceRegister> AttendanceRegister { get; set; }
        public DbSet<Shift> Shift { get; set; }

    }
}