using Microsoft.EntityFrameworkCore;

public class SchoolContext : DbContext
{
    public DbSet<School> Schools { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Lưu ý: Nếu máy bạn dùng SQLEXPRESS thì sửa Server=.\\SQLEXPRESS
        optionsBuilder.UseSqlServer("Server=.;Database=SchoolManagement;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<School>().HasIndex(e => e.Name).IsUnique();
        modelBuilder.Entity<Student>().HasIndex(e => e.StudentId).IsUnique();
        modelBuilder.Entity<Student>().HasIndex(e => e.Email).IsUnique();
    }
}