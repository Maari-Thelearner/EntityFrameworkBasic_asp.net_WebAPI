using EmployeeManagementSystemsln.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemsln.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeDetails> Employeedetails { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);
            entity.Property(e => e.EmployeeSalary).IsRequired();
            entity.Property(e => e.EmployeeFirstName).IsRequired();

            //one to one
            entity.HasOne(e => e.EmployeeDetailsRefNav)
                .WithOne(ed => ed.Employee)
                .HasForeignKey<EmployeeDetails>(ed => ed.EmployeeDetailsId);

            //one to many
            entity.HasOne(e => e.ManagerRefNav)
                .WithMany(m => m.Employees)
                .HasForeignKey(m => m.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        });
        modelBuilder.Entity<EmployeeDetails>(entity =>
        {
            entity.HasKey(ed => ed.EmployeeDetailsId);
            entity.Property(ed => ed.PhoneNumber).IsRequired();
            entity.Property(ed => ed.Email).IsRequired();
        });
        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(m => m.ManagerId);
            entity.Property(m => m.ManagerFirstName).IsRequired();
        });
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(p => p.ProjectId);
            entity.Property(p => p.ProjectName).IsRequired();
        });
        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            //many to many
            entity.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });
            entity.HasOne(ep => ep.Employee)
                .WithMany(ep => ep.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);
            entity.HasOne(ep => ep.Project)
                .WithMany(ep => ep.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);
        });
    }
}