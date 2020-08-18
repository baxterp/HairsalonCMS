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
        public virtual DbSet<MpOurServices> MpOurServices { get; set; }
        public virtual DbSet<PageFooter> PageFooter { get; set; }
        public virtual DbSet<PublicImages> PublicImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=sql7.hostinguk.net;Database=hairdemo;integrated security=False;User ID=hairdemo;Password=::L1ghting");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "hairdemo");

            modelBuilder.Entity<MpCarousel>(entity =>
            {
                entity.HasKey(e => e.TileId);

                entity.ToTable("mpCarousel", "dbo");

                entity.Property(e => e.TileId).HasColumnName("TileID");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.TileMessage)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TileTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.MpCarousel)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_mpCarousel_publicImages");
            });

            modelBuilder.Entity<MpFlatPageData>(entity =>
            {
                entity.ToTable("mpFlatPageData", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IconImageId).HasColumnName("IconImageID");

                entity.Property(e => e.OurServicesMessage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PageTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WelcomeMessage)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IconImage)
                    .WithMany(p => p.MpFlatPageData)
                    .HasForeignKey(d => d.IconImageId)
                    .HasConstraintName("FK_mpFlatPageData_publicImages");
            });

            modelBuilder.Entity<MpOurServices>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK__MpOurSer__C51BB0EA36B12243");

                entity.ToTable("mpOurServices", "dbo");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.ServiceDescription)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.MpOurServices)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mpOurServices_publicImages");
            });

            modelBuilder.Entity<PageFooter>(entity =>
            {
                entity.ToTable("pageFooter", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FaceBook)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FooterText)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IconImageId).HasColumnName("IconImageID");

                entity.Property(e => e.Instagram)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OpeningTimes1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpeningTimes2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpeningTimes3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpeningTimes4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Twitter)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PublicImages>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__publicIm__7516F4EC30F848ED");

                entity.ToTable("publicImages", "dbo");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.ImageLocation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
