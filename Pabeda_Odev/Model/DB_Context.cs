using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Model
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=REZAN;Database=Pabeda_Odev;Trusted_Connection=True;");
        //}
        public virtual DbSet<Ogrenci> Ogrenci { get; set; }
        public virtual DbSet<Ogretmen> Ogretmen { get; set; }
        public virtual DbSet<Okul> Okul { get; set; }
        public virtual DbSet<OgrenciOgretmen> OgrenciOgretmen { get; set; }
        public virtual DbSet<OgretmenOkul> OgretmenOkul { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ogrenci>()
                .HasOne(e => e.Okul)
                .WithMany(e => e.Ogrenci)
                .HasForeignKey(e => e.OkulID);

            modelBuilder.Entity<OgretmenOkul>()
                .HasOne(e => e.Ogretmen)
                .WithMany(e => e.OgretmenOkul)
                .HasForeignKey(e => e.OgretmenID);

            modelBuilder.Entity<OgretmenOkul>()
                .HasOne(e => e.Okul)
                .WithMany(e => e.OgretmenOkul)
                .HasForeignKey(e => e.OkulID);

            modelBuilder.Entity<OgrenciOgretmen>()
                .HasOne(e => e.Ogrenci)
                .WithMany(e => e.OgrenciOgretmen)
                .HasForeignKey(e => e.OgrenciID);

            modelBuilder.Entity<OgrenciOgretmen>()
                .HasOne(e => e.Ogretmen)
                .WithMany(e => e.OgrenciOgretmen)
                .HasForeignKey(e => e.OgretmenID);
        }
    }
}
