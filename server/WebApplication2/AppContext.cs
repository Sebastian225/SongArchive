using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().ToTable("Albums");
            modelBuilder.Entity<Song>().ToTable("Songs");
            modelBuilder.Entity<Review>().ToTable("Reviews");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Person>().ToTable("Persons");

            //1-M
            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasOne(x => x.album)
                 .WithMany(x => x.songs)
                 .HasForeignKey(x => x.album_id);
            });

            //M-M
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(x => x.id);

                entity.HasOne(x => x.album)
                 .WithMany(x => x.reviews)
                 .HasForeignKey(x => x.album_id);

                entity.HasOne(x => x.user)
                 .WithMany(x => x.reviews)
                 .HasForeignKey(x => x.user_id);
            });

            //1-1
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(x => x.person)
                    .WithOne(x => x.user)
                    .HasForeignKey<User>(x => x.personId);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Data Source=DESKTOP-A5N2R41;Initial Catalog=Belphegor;Integrated Security=True");
    }
}
