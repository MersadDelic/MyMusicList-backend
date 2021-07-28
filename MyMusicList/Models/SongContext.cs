using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyMusicList.Models
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options)
            : base(options){}
        public DbSet<Song> Songs { get; set; }
        
        public override int SaveChanges() 
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        
        private void AddTimestamps() 
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).ModifiedTime = DateTime.Now; // setamo datum izmjene -- pri svakoj izmjeni novi datum

                if (entityEntry.State == EntityState.Added) // ako je status Added
                {
                    ((BaseEntity)entityEntry.Entity).CreatedTime = DateTime.Now;  // setamo datum kreiranja (samo jednom)
                }
            }
        }
    }
}