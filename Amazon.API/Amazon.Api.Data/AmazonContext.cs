using Amazon.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Api.Data;

public partial class AmazonContext : DbContext
{
    public AmazonContext()
    {
    }

    public AmazonContext(DbContextOptions<AmazonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }
    public virtual DbSet<ProductTag> ProductTags { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCart> UserCarts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("Cart_pkey");

            entity.ToTable("Cart");

            entity.HasIndex(e => e.UserId, "Cart_UserId_key").IsUnique();

            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");

            entity.HasOne(d => d.User).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.UserId)
                .HasConstraintName("Cart_UserId_fkey");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("Image_pkey");

            entity.ToTable("Image");

            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.Images).HasColumnName("Image");
            entity.Property(e => e.ImageName).HasMaxLength(100);
            entity.Property(e => e.ImageType).HasMaxLength(100);
            entity.Property(e => e.ImageTypeId).HasDefaultValue(101);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");

            entity.HasOne(d => d.ImageTypes).WithMany(p => p.Images)
                .HasForeignKey(d => d.ImageTypeId)
                .HasConstraintName("Image_ImageTypeId_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("Image_ProductId_fkey");
        });

        modelBuilder.Entity<ImageType>(entity =>
        {
            entity.HasKey(e => e.ImageTypeId).HasName("ImageType_pkey");

            entity.ToTable("ImageType");

            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("Order_ProductId_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Order_UserId_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("Product_pkey");

            entity.ToTable("Product");

            entity.HasIndex(e => new { e.Title, e.Category }, "Product_Title_Category_key").IsUnique();

            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Price).HasPrecision(12, 2);
            entity.Property(e => e.Rating).HasPrecision(3, 1);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Product_UserId_fkey");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.ProductDetailId).HasName("ProductDetail_pkey");

            entity.ToTable("ProductDetail");

            entity.HasIndex(e => e.ProductId, "ProductDetail_ProductId_key").IsUnique();

            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.Discount).HasPrecision(5, 2);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ReturnPolicy).HasMaxLength(100);
            entity.Property(e => e.Shipping).HasMaxLength(100);
            entity.Property(e => e.Sku)
                .HasMaxLength(100)
                .HasColumnName("sku");
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");
            entity.Property(e => e.Warranty).HasMaxLength(100);
            entity.Property(e => e.Weight).HasPrecision(6, 2);

            entity.HasOne(d => d.Product).WithOne(p => p.ProductDetail)
                .HasForeignKey<ProductDetail>(d => d.ProductId)
                .HasConstraintName("ProductDetail_ProductId_fkey");
        });

        modelBuilder.Entity<ProductTag>(entity =>
        {
            entity.HasKey(e => e.ProductTagId).HasName("ProductTag_pkey");

            entity.ToTable("ProductTag");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("ProductTag_ProductId_fkey");

            entity.HasOne(d => d.Tag).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("ProductTag_TagId_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("Review_pkey");

            entity.ToTable("Review");

            entity.HasIndex(e => e.ReviewerEmail, "Review_ReviewerEmail_key").IsUnique();

            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Rating).HasPrecision(3, 1);
            entity.Property(e => e.ReviewerEmail).HasMaxLength(100);
            entity.Property(e => e.ReviewerName).HasMaxLength(100);
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("Review_ProductId_fkey");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("Tag_pkey");

            entity.ToTable("Tag");

            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Tags).HasColumnName("Tag");
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pkey");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "User_Email_key").IsUnique();

            entity.HasIndex(e => e.PhoneNo, "User_PhoneNo_key").IsUnique();

            entity.HasIndex(e => e.Username, "User_Username_key").IsUnique();

            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNo).HasMaxLength(10);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<UserCart>(entity =>
        {
            entity.HasKey(e => e.UserCartId).HasName("UserCart_pkey");

            entity.ToTable("UserCart");

            entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedOn).HasColumnType("timestamp with time zone");

            entity.HasOne(d => d.Cart).WithMany(p => p.UserCarts)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("UserCart_CartId_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.UserCarts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("UserCart_ProductId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
