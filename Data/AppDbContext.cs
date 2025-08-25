using Microsoft.EntityFrameworkCore;

namespace SoyAgaci.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Person> People => Set<Person>();
        public DbSet<Marriage> Marriages => Set<Marriage>();
        public DbSet<ParentChild> ParentChildren => Set<ParentChild>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Person>().Property(p => p.Name).HasMaxLength(200).IsRequired();
            b.Entity<ParentChild>().HasIndex(pc => new { pc.ParentId, pc.ChildId }).IsUnique();
        }
    }

    public enum Gender { Unknown=0, Male=1, Female=2 }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateOnly? Birth { get; set; }
        public DateOnly? Death { get; set; }
        public string? Notes { get; set; }
    }

    public class Marriage
    {
        public int Id { get; set; }
        public int Spouse1Id { get; set; }
        public int Spouse2Id { get; set; }
        public DateOnly? Start { get; set; }
        public DateOnly? End { get; set; }
    }

    public enum RelationCertainty { Certain=0, Probable=1, Possible=2 }

    public class ParentChild
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public string Type { get; set; } = "biological";
        public RelationCertainty Certainty { get; set; } = RelationCertainty.Certain;
    }
}
