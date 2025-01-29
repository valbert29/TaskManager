using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Domain.Entities.Task> Tasks => Set<Domain.Entities.Task>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        // Конфигурация для Task
        modelBuilder.Entity<Domain.Entities.Task>(entity =>
        {
            entity.ToTable("tasks");
            
            entity.HasKey(t => t.Id)
                .HasName("pk_tasks");

            entity.Property(t => t.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()");

            entity.Property(t => t.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(200)")
                .IsRequired();

            entity.Property(t => t.Status)
                .HasColumnName("status")
                .HasColumnType("varchar(20)")
                .HasConversion<string>()
                .IsRequired();

            entity.OwnsOne(t => t.Priority, p =>
            {
                p.Property(pp => pp.Value)
                    .HasColumnName("priority")
                    .HasColumnType("integer")
                    .IsRequired();
            });
        });

        base.OnModelCreating(modelBuilder);
    }
}