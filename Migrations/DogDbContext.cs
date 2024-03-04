using midterm_project.Models;
using Microsoft.EntityFrameworkCore;

namespace midterm_project.Migrations;

public class DogDbContext : DbContext 
{
    public DbSet<Dog> Dog { get; set; }

    public DogDbContext(DbContextOptions<DogDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Dog>(entity =>
        {
            entity.HasKey(e => e.DogId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Breed).IsRequired();
            entity.Property(e => e.Gendre).IsRequired();  
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.ImgUrl).IsRequired();
        });
    }
}
