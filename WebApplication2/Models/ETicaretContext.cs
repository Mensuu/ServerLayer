﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class ETicaretContext : DbContext
{
    public ETicaretContext()
    {
    }

    public ETicaretContext(DbContextOptions<ETicaretContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VMusteri> VMusteris { get; set; }
    public virtual DbSet<VUrun> VUruns { get; set; }
    public virtual DbSet<VSiparis> VSipariss { get; set; }
    public virtual DbSet<VSiparisDurumu> VSiparisDurumus { get; set; }
    public virtual DbSet<VTahsilat> VTahsilats { get; set; }
    public virtual DbSet<VTahsilatTipi> VTahsilatTipis { get; set; }
    public virtual DbSet<VUrunKategorisi> VUrunKategorisis { get; set; }
    public virtual DbSet<VSehir> VSehirs { get; set; }
    public virtual DbSet<VOdeme> VOdemes { get; set; }
    public virtual DbSet<Cinsiyet> Cinsiyets { get; set; }

    public virtual DbSet<Musteri> Musteris { get; set; }

    public virtual DbSet<Odeme> Odemes { get; set; }

    public virtual DbSet<OdemeKanali> OdemeKanalis { get; set; }

    public virtual DbSet<ParaBirimi> ParaBirimis { get; set; }

    public virtual DbSet<Sehir> Sehirs { get; set; }

    public virtual DbSet<Sipari> Siparis { get; set; }

    public virtual DbSet<SiparisDurumu> SiparisDurumus { get; set; }

    public virtual DbSet<Tahsilat> Tahsilats { get; set; }

    public virtual DbSet<TahsilatTipi> TahsilatTipis { get; set; }

    public virtual DbSet<Urun> Uruns { get; set; }

    public virtual DbSet<UrunKategorisi> UrunKategorisis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\;Database=E-Ticaret;User Id=sa; Password=123;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VMusteri>(entity =>
        {
            entity.ToView("VMusteri");
            entity.HasNoKey();

        });

        modelBuilder.Entity<VUrun>(entity =>
        {
            entity.ToView("VUrun");
            entity.HasNoKey();

        });
        modelBuilder.Entity<VSiparis>(entity =>
        {
            entity.ToView("VSiparis");
            entity.HasNoKey();

        });
        modelBuilder.Entity<VSiparisDurumu>(entity =>
        {
            entity.ToView("VSiparisDurumu");
            entity.HasNoKey();

        });
        modelBuilder.Entity<VTahsilat>(entity =>
        {
            entity.ToView("VTahsilat");
            entity.HasNoKey();

        });
        modelBuilder.Entity<VTahsilatTipi>(entity =>
        {
            entity.ToView("VTahsilatTipi");
            entity.HasNoKey();

        });
        modelBuilder.Entity<VUrunKategorisi>(entity =>
        {
            entity.ToView("VUrunKategorisi");
            entity.HasNoKey();

        });
        modelBuilder.Entity<VSehir>(entity =>
        {
            entity.ToView("VSehir");
            entity.HasNoKey();

        });
        modelBuilder.Entity<VOdeme>(entity =>
        {
            entity.ToView("VOdeme");
            entity.HasNoKey();

        });

        modelBuilder.Entity<Cinsiyet>(entity =>
        {
            entity.ToTable("Cinsiyet");

            entity.Property(e => e.CinsiyetId).HasColumnName("CinsiyetID");
            entity.Property(e => e.Cinsiyet1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Cinsiyet");
        });

        modelBuilder.Entity<Musteri>(entity =>
        {
            entity.HasKey(e => e.MusteriId).HasName("PK_Musteri1");

            entity.ToTable("Musteri");

            entity.Property(e => e.MusteriId)
                .ValueGeneratedOnAdd()
                .HasColumnName("MusteriID");
            entity.Property(e => e.Adres).IsUnicode(false);
            entity.Property(e => e.CinsiyetId).HasColumnName("CinsiyetID");
            entity.Property(e => e.DogumTarihi).HasColumnType("date");
            entity.Property(e => e.MusteriAdi)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.MusteriSoyadi)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.SehirId).HasColumnName("SehirID");

            entity.HasOne(d => d.Cinsiyet).WithMany(p => p.Musteris)
                .HasForeignKey(d => d.CinsiyetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Musteri_Cinsiyet");

            entity.HasOne(d => d.MusteriNavigation).WithOne(p => p.Musteri)
                .HasForeignKey<Musteri>(d => d.MusteriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Musteri_Sehir");
        });

        modelBuilder.Entity<Odeme>(entity =>
        {
            entity.ToTable("Odeme");

            entity.Property(e => e.OdemeId).HasColumnName("OdemeID");
            entity.Property(e => e.Aciklama).IsUnicode(false);
            entity.Property(e => e.MusteriId).HasColumnName("MusteriID");
            entity.Property(e => e.OdemeKanaliId).HasColumnName("OdemeKanaliID");
            entity.Property(e => e.OdemeTarihi).HasColumnType("date");
            entity.Property(e => e.ParaBirimiId).HasColumnName("ParaBirimiID");
            entity.Property(e => e.ToplamTutar).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Musteri).WithMany(p => p.Odemes)
                .HasForeignKey(d => d.MusteriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Odeme_Musteri");

            entity.HasOne(d => d.OdemeKanali).WithMany(p => p.Odemes)
                .HasForeignKey(d => d.OdemeKanaliId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Odeme_OdemeKanali");

            entity.HasOne(d => d.ParaBirimi).WithMany(p => p.Odemes)
                .HasForeignKey(d => d.ParaBirimiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Odeme_ParaBirimi");
        });

        modelBuilder.Entity<OdemeKanali>(entity =>
        {
            entity.HasKey(e => e.OdemeKanaliId).HasName("PK_OdemeKanalı");

            entity.ToTable("OdemeKanali");

            entity.Property(e => e.OdemeKanaliId).HasColumnName("OdemeKanaliID");
            entity.Property(e => e.OdemeKanali1)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("OdemeKanali");
        });

        modelBuilder.Entity<ParaBirimi>(entity =>
        {
            entity.ToTable("ParaBirimi");

            entity.Property(e => e.ParaBirimiId).HasColumnName("ParaBirimiID");
            entity.Property(e => e.ParaBirimi1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ParaBirimi");
        });

        modelBuilder.Entity<Sehir>(entity =>
        {
            entity.ToTable("Sehir");

            entity.Property(e => e.SehirId).HasColumnName("SehirID");
            entity.Property(e => e.Sehir1)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("Sehir");
        });

        modelBuilder.Entity<Sipari>(entity =>
        {
            entity.HasKey(e => e.SiparisId);

            entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
            entity.Property(e => e.MusteriId).HasColumnName("MusteriID");
            entity.Property(e => e.ParaBirimiId).HasColumnName("ParaBirimiID");
            entity.Property(e => e.SiparisDetayları).IsUnicode(false);
            entity.Property(e => e.SiparisDurumuId).HasColumnName("SiparisDurumuID");
            entity.Property(e => e.SiparisTarihi).HasColumnType("date");
            entity.Property(e => e.ToplamTutar).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Musteri).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.MusteriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Siparis_Musteri");

            entity.HasOne(d => d.ParaBirimi).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.ParaBirimiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Siparis_ParaBirimi");

            entity.HasOne(d => d.SiparisDurumu).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.SiparisDurumuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Siparis_SiparisDurumu");
        });

        modelBuilder.Entity<SiparisDurumu>(entity =>
        {
            entity.ToTable("SiparisDurumu");

            entity.Property(e => e.SiparisDurumuId).HasColumnName("SiparisDurumuID");
            entity.Property(e => e.SiparisDurumu1)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("SiparisDurumu");
        });

        modelBuilder.Entity<Tahsilat>(entity =>
        {
            entity.ToTable("Tahsilat");
            entity.HasKey(e => e.TahsilatId).HasName("PK_Tahsilat");
            entity.Property(e => e.TahsilatId).HasColumnName("TahsilatID");
            entity.Property(e => e.MusteriId).HasColumnName("MusteriID");
            entity.Property(e => e.ParaBirimiId).HasColumnName("ParaBirimiID");
            entity.Property(e => e.UrunId).HasColumnName("UrunID");
            entity.Property(e => e.TahsilatTipiId).HasColumnName("TahsilatTipiID");
            entity.Property(e => e.ToplamTutar).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Musteri).WithMany(p => p.Tahsilats)
                .HasForeignKey(d => d.MusteriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tahsilat_Musteri");

            entity.HasOne(d => d.ParaBirimi).WithMany(p => p.Tahsilats)
                .HasForeignKey(d => d.ParaBirimiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tahsilat_ParaBirimi");

            entity.HasOne(d => d.Urun).WithMany(p => p.Tahsilats)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tahsilat_Urun");

            entity.HasOne(d => d.TahsilatTipi).WithMany(p => p.Tahsilats)
                .HasForeignKey(d => d.TahsilatTipiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tahsilat_TahsilatTipi");
        });

        modelBuilder.Entity<TahsilatTipi>(entity =>
        {
            entity.ToTable("TahsilatTipi");

            entity.Property(e => e.TahsilatTipiId).HasColumnName("TahsilatTipiID");
            entity.Property(e => e.TahilatTipi)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Urun>(entity =>
        {
            entity.ToTable("Urun");

            entity.Property(e => e.UrunId).HasColumnName("UrunID");
            entity.Property(e => e.Fiyati).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ParaBirimiId).HasColumnName("ParaBirimiID");
            entity.Property(e => e.UrunAdi)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.UrunKodu)
                .HasMaxLength(10)
                .IsFixedLength();
            //entity.Property(e => e.UrunKategorisiId).HasColumnName("UrunKategorsiID");

            entity.HasOne(d => d.ParaBirimi).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.ParaBirimiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Urun_ParaBirimi");
            entity.HasOne(d => d.UrunKategorisi).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.UrunKategorisiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Urun_UrunKategorisi");
        });

        modelBuilder.Entity<UrunKategorisi>(entity =>
        {
            entity.ToTable("UrunKategorisi");

            entity.Property(e => e.UrunKategorisiId).HasColumnName("UrunKategorisiID");
            entity.Property(e => e.UrunKategorisi1)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("UrunKategorisi");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
