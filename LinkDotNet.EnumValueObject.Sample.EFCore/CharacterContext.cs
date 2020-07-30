using Microsoft.EntityFrameworkCore;

namespace LinkDotNet.EnumValueObject.Sample.EFCore
{
    public class CharacterContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public CharacterContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasKey(c => c.Id);
            modelBuilder.Entity<Character>().Property(c => c.Origin).HasConversion(
                to => to.Key,
                from => Origin.Create(from).Value);
        }
    }
}