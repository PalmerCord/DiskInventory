using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiskInventory.Models
{
    public partial class disk_inventorycpContext : DbContext
    {
        public disk_inventorycpContext()
        {
        }

        public disk_inventorycpContext(DbContextOptions<disk_inventorycpContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Artist> Artists { get; set; }
        //public virtual DbSet<ArtistType> ArtistTypes { get; set; }
        //public virtual DbSet<Borrower> Borrowers { get; set; }
        //public virtual DbSet<Disk> Disks { get; set; }
        //public virtual DbSet<DiskHasArtist> DiskHasArtists { get; set; }
        //public virtual DbSet<DiskHasBorrower> DiskHasBorrowers { get; set; }
        //public virtual DbSet<DiskType> DiskTypes { get; set; }
        //public virtual DbSet<Genre> Genres { get; set; }
        //public virtual DbSet<Status> Statuses { get; set; }
        //public virtual DbSet<ViewBorrowerNoLoans> ViewBorrowerNoLoans { get; set; }
        public virtual DbSet<Borrower> Borrowers { get; set; }
        public virtual DbSet<Disk> Disks { get; set; }
        public virtual DbSet<DiskHasBorrower> DiskHasBorrowers { get; set; }
        public virtual DbSet<DiskType> DiskTypes { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<ViewBorrowerNoLoans> ViewBorrowerNoLoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLDEV01;Database=disk_inventorycp;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.ArtistTypeId).HasColumnName("artist_type_id");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(60);

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(60);

                entity.HasOne(d => d.ArtistType)
                    .WithMany(p => p.Artist)
                    .HasForeignKey(d => d.ArtistTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__artist__artist_t__32E0915F");
            });

            modelBuilder.Entity<ArtistType>(entity =>
            {
                entity.ToTable("artist_type");

                entity.Property(e => e.ArtistTypeId).HasColumnName("artist_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Borrower>(entity =>
            {
                entity.ToTable("borrower");

                entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(60);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(60);

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasColumnName("phone_num")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Disk>(entity =>
            {
                entity.ToTable("disk");

                entity.Property(e => e.DiskId).HasColumnName("disk_id");

                entity.Property(e => e.DiskName)
                    .IsRequired()
                    .HasColumnName("disk_name")
                    .HasMaxLength(60);

                entity.Property(e => e.DiskTypeId).HasColumnName("disk_type_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.DiskType)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.DiskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk__disk_type___300424B4");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk__genre_id__2E1BDC42");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk__status_id__2F10007B");
            });


            modelBuilder.Entity<DiskHasBorrower>(entity =>
            {
                entity.ToTable("disk_has_borrower");

                entity.Property(e => e.DiskHasBorrowerId).HasColumnName("disk_has_borrower_id");

                entity.Property(e => e.BorrowedDate).HasColumnName("borrowed_date");

                entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");

                entity.Property(e => e.DiskId).HasColumnName("disk_id");

                entity.Property(e => e.ReturnedDate).HasColumnName("returned_date");

                entity.HasOne(d => d.Borrower)
                    .WithMany(p => p.DiskHasBorrowers)
                    .HasForeignKey(d => d.BorrowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk_has___borro__35BCFE0A");

                entity.HasOne(d => d.Disk)
                    .WithMany(p => p.DiskHasBorrowers)
                    .HasForeignKey(d => d.DiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk_has___disk___36B12243");
            });

            modelBuilder.Entity<DiskType>(entity =>
            {
                entity.ToTable("disk_type");

                entity.Property(e => e.DiskTypeId).HasColumnName("disk_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewBorrowerNoLoans>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Borrower_No_Loans");

                entity.Property(e => e.BorrowerId)
                    .HasColumnName("borrower_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(60);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

//            modelBuilder.Entity<Borrower>(entity =>
//            {
//                entity.ToTable("borrower");

//                entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");

//                entity.Property(e => e.Fname)
//                    .IsRequired()
//                    .HasMaxLength(60)
//                    .HasColumnName("fname");

//                entity.Property(e => e.Lname)
//                    .IsRequired()
//                    .HasMaxLength(60)
//                    .HasColumnName("lname");

//                entity.Property(e => e.PhoneNum)
//                    .IsRequired()
//                    .HasMaxLength(15)
//                    .IsUnicode(false)
//                    .HasColumnName("phone_num");
//            });

//            modelBuilder.Entity<Disk>(entity =>
//            {
//                entity.ToTable("disk");

//                entity.Property(e => e.DiskId).HasColumnName("disk_id");

//                entity.Property(e => e.DiskName)
//                    .IsRequired()
//                    .HasMaxLength(60)
//                    .HasColumnName("disk_name");

//                entity.Property(e => e.DiskTypeId).HasColumnName("disk_type_id");

//                entity.Property(e => e.GenreId).HasColumnName("genre_id");

//                entity.Property(e => e.ReleaseDate)
//                    .HasColumnType("date")
//                    .HasColumnName("release_date");

//                entity.Property(e => e.StatusId).HasColumnName("status_id");

//                entity.HasOne(d => d.DiskType)
//                    .WithMany(p => p.Disk)
//                    .HasForeignKey(d => d.DiskTypeId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__disk__disk_type___2E1BDC42");

//                entity.HasOne(d => d.Genre)
//                    .WithMany(p => p.Disk)
//                    .HasForeignKey(d => d.GenreId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__disk__genre_id__2C3393D0");

//                entity.HasOne(d => d.Status)
//                    .WithMany(p => p.Disk)
//                    .HasForeignKey(d => d.StatusId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__disk__status_id__2D27B809");
//            });

//            modelBuilder.Entity<DiskHasBorrower>(entity =>
//            {
//                entity.ToTable("disk_has_borrower");

//                entity.Property(e => e.DiskHasBorrowerId).HasColumnName("disk_has_borrower_id");

//                entity.Property(e => e.BorrowedDate).HasColumnName("borrowed_date");

//                entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");

//                entity.Property(e => e.DiskId).HasColumnName("disk_id");

//                entity.Property(e => e.ReturnedDate).HasColumnName("returned_date");

//                entity.HasOne(d => d.Borrower)
//                    .WithMany(p => p.DiskHasBorrowers)
//                    .HasForeignKey(d => d.BorrowerId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__disk_has___borro__35BCFE0A");

//                entity.HasOne(d => d.Disk)
//                    .WithMany(p => p.DiskHasBorrowers)
//                    .HasForeignKey(d => d.DiskId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__disk_has___disk___36B12243");
//            });

//            modelBuilder.Entity<DiskType>(entity =>
//            {
//                entity.ToTable("disk_type");

//                entity.Property(e => e.DiskTypeId).HasColumnName("disk_type_id");

//                entity.Property(e => e.Description)
//                    .IsRequired()
//                    .HasMaxLength(20)
//                    .IsUnicode(false)
//                    .HasColumnName("description");
//            });

//            modelBuilder.Entity<Genre>(entity =>
//            {
//                entity.ToTable("genre");

//                entity.Property(e => e.GenreId).HasColumnName("genre_id");

//                entity.Property(e => e.Description)
//                    .IsRequired()
//                    .HasMaxLength(20)
//                    .IsUnicode(false)
//                    .HasColumnName("description");
//            });

//            modelBuilder.Entity<Status>(entity =>
//            {
//                entity.ToTable("status");

//                entity.Property(e => e.StatusId).HasColumnName("status_id");

//                entity.Property(e => e.Description)
//                    .IsRequired()
//                    .HasMaxLength(20)
//                    .IsUnicode(false)
//                    .HasColumnName("description");
//            });

//            modelBuilder.Entity<ViewBorrowerNoLoans>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToView("View_Borrower_No_Loans");

//                entity.Property(e => e.BorrowerId)
//                    .ValueGeneratedOnAdd()
//                    .HasColumnName("borrower_id");

//                entity.Property(e => e.Fname)
//                    .IsRequired()
//                    .HasMaxLength(60)
//                    .HasColumnName("fname");

//                entity.Property(e => e.Lname)
//                    .IsRequired()
//                    .HasMaxLength(60)
//                    .HasColumnName("lname");
//            });



//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}

