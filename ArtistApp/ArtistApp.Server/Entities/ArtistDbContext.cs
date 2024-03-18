using Microsoft.EntityFrameworkCore;

namespace ArtistApp.Server.Entities
{
    public class ArtistDbContext : DbContext
    {
        public ArtistDbContext(DbContextOptions<ArtistDbContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artists");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description);
                entity.HasMany(a => a.Albums)
                    .WithOne(a => a.Artist)
                    .HasForeignKey(a => a.ArtistId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Albums");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description);
                entity.Property(e => e.ReleaseYear).HasMaxLength(5);
                entity.HasOne(a => a.Artist)
                    .WithMany(a => a.Albums)
                    .HasForeignKey(a => a.ArtistId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(a => a.Tracks)
                    .WithOne(t => t.Album)
                    .HasForeignKey(t => t.AlbumId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("Tracks");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.HasOne(t => t.Album)
                    .WithMany(a => a.Tracks)
                    .HasForeignKey(t => t.AlbumId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "Zayn Malik", Description = "Zain Javadd Malik (born 12 January 1993), known professionally as Zayn Malik or simply Zayn, is a British singer. Malik auditioned as a solo contestant for the British music competition television series The X Factor in 2010" },
                new Artist { Id = 2, Name = "Robyn Rihana Fenty", Description = "Robyn Rihanna Fenty born February 20, 1988) is a Barbadian singer, businesswoman, and actress" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album { Id = 1, Title = "Gold Pharoah", Description = "Gold Pharaoh (Original Mix) is a song by Proof Db, available on SoundCloud. It is also available on Amazon UK, where it appears on the album Gold Pharoah along with other songs by Proof Db and Zayn Malik", ReleaseYear = 2020, ArtistId = 1 },
                new Album { Id = 2, Title = "Anti", Description = "Anti is the eighth studio album by Barbadian singer Rihanna. It was released on 28 January 2016 by Roc Nation and Westbury Road", ReleaseYear = 2016, ArtistId = 2 }
            );

            modelBuilder.Entity<Track>().HasData(
                new Track { Id = 1, Title = "Deep Spirit", Description = "Remember the time When you were here inside my dream I wish you'll be mine, You're understanding what I mean", AlbumId = 1 },
                new Track { Id = 2, Title = "Needed Me", Description = "Needed Me is a mellowish dubstep-flavored electro-R&B song with trippy, trappy production, and a length of three minutes and five seconds", AlbumId = 2 }
            );
        }

    }
}
