using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HairDemoSite.Areas.Public.Data.SiteData
{
    public partial class siteDataDbContext : DbContext
    {
        public siteDataDbContext()
        {
        }

        public siteDataDbContext(DbContextOptions<siteDataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MpCarousel> MpCarousel { get; set; }
        public virtual DbSet<MpFlatPageData> MpFlatPageData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=sql7.hostinguk.net;Database=hairdemo;integrated security=False;User ID=hairdemo;Password=::L1ghting");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "hairdemo");

            modelBuilder.Entity<MpCarousel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mpCarousel", "dbo");

                entity.Property(e => e.TileId)
                    .HasColumnName("TileID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TileImageLocation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TileMessage)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TileTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MpFlatPageData>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mpFlatPageData", "dbo");

                entity.Property(e => e.OurServicesMessage)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
