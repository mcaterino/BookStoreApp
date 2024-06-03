using System;
using System.Collections.Generic;
using BookStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Publisher> Publishers { get; set; }
    public virtual DbSet<AuthorBook> AuthorBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<AuthorBook>(entity => // No changes needed here
        {
            entity.HasKey(e => e.Id).HasName("PK__AuthorBo__3214EC07E0F9BDF2");

            entity.HasOne(d => d.Author)
              .WithMany(p => p.AuthorBooks)
              .HasForeignKey(d => d.AuthorId)
              .HasConstraintName("FK_AuthorBook_AuthorId");

            entity.HasOne(d => d.Book)
              .WithMany(p => p.AuthorBooks)
              .HasForeignKey(d => d.BookId)
              .HasConstraintName("FK_AuthorBook_BookId");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07E0F9BDF2");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC0789BB7240");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA73B585FA").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasMany(b => b.AuthorBooks)
                .WithOne(ab => ab.Book)
                .HasForeignKey(ab => ab.BookId);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publisher__3214EC07E0F9BDF2");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}