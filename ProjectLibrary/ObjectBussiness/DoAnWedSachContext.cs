using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectLibrary.ObjectBussiness;

public partial class DoAnWedSachContext : DbContext
{
    public DoAnWedSachContext()
    {
    }

    public DoAnWedSachContext(DbContextOptions<DoAnWedSachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookImage> BookImages { get; set; }

    public virtual DbSet<BookReview> BookReviews { get; set; }

    public virtual DbSet<DiscountCoupon> DiscountCoupons { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderHistory> OrderHistories { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivity> UserActivities { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserPaymentHistory> UserPaymentHistories { get; set; }

    public virtual DbSet<UserRegHistory> UserRegHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-MQLOUCSR\\SQLEXPRESS;Database=DoAnWedSach;User Id=sa;Password=012345;TrustServerCertificate=true;Trusted_Connection=SSPI;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.AuthorId).HasColumnName("Author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("Author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.AuthorId).HasColumnName("Author_id");
            entity.Property(e => e.GenreId).HasColumnName("Genre_id");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PublisherId).HasColumnName("Publisher_id");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_Authors");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_Books_Genres");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("FK_Books_Publishers");
        });

        modelBuilder.Entity<BookImage>(entity =>
        {
            entity.HasKey(e => e.ImageId);

            entity.Property(e => e.ImageId).HasColumnName("Image_id");
            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("Image_url");

            entity.HasOne(d => d.Book).WithMany(p => p.BookImages)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_BookImages_Books");
        });

        modelBuilder.Entity<BookReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId);

            entity.Property(e => e.ReviewId).HasColumnName("Review_id");
            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.ReviewDate)
                .HasColumnType("datetime")
                .HasColumnName("Review_date");
            entity.Property(e => e.ReviewText)
                .HasColumnType("text")
                .HasColumnName("Review_text");

            entity.HasOne(d => d.Book).WithMany(p => p.BookReviews)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_BookReviews_Books");

            entity.HasOne(d => d.User).WithMany(p => p.BookReviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_BookReviews_Customers");
        });

        modelBuilder.Entity<DiscountCoupon>(entity =>
        {
            entity.HasKey(e => e.CouponId);

            entity.Property(e => e.CouponId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Coupon_id");
            entity.Property(e => e.CouponCode)
                .HasMaxLength(50)
                .HasColumnName("Coupon_code");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Discount_percentage");
            entity.Property(e => e.ExpiryDate).HasColumnName("Expiry_date");

            entity.HasOne(d => d.Coupon).WithOne(p => p.DiscountCoupon)
                .HasForeignKey<DiscountCoupon>(d => d.CouponId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscountCoupons_Orders");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.GenreId).HasColumnName("Genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(255)
                .HasColumnName("Genre_name");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.Property(e => e.NotificationId).HasColumnName("Notification_id");
            entity.Property(e => e.SentDate)
                .HasColumnType("datetime")
                .HasColumnName("Sent_date");

            entity.HasOne(d => d.TitleNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.Title)
                .HasConstraintName("FK_Notifications_Customers");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.CouponId).HasColumnName("Coupon_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_date");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_amount");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderDetailId).HasColumnName("Order_detail_id");
            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Book).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_OrderDetails_Books");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetails_Orders");
        });

        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.ToTable("OrderHistory");

            entity.Property(e => e.OrderHistoryId).HasColumnName("Order_history_id");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .HasColumnName("Order_status");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_date");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderHistory_Orders");

            entity.HasOne(d => d.User).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OrderHistory_Customers");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.Property(e => e.PublisherId).HasColumnName("Publisher_id");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(255)
                .HasColumnName("Publisher_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.ToTable("Shipping");

            entity.Property(e => e.ShippingId).HasColumnName("Shipping_id");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.ShipDate)
                .HasColumnType("datetime")
                .HasColumnName("Ship_date");
            entity.Property(e => e.ShippingStatus)
                .HasMaxLength(50)
                .HasColumnName("Shipping_status");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(50)
                .HasColumnName("Tracking_number");

            entity.HasOne(d => d.Order).WithMany(p => p.Shippings)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Shipping_Orders");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Customers");

            entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            entity.Property(e => e.Email).HasMaxLength(500);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Users_Roles");

            entity.HasOne(d => d.UserNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_UserDetail");
        });

        modelBuilder.Entity<UserActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId);

            entity.ToTable("UserActivity");

            entity.Property(e => e.LogDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserActivity_Users");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserDetail");
        });

        modelBuilder.Entity<UserPaymentHistory>(entity =>
        {
            entity.HasKey(e => e.PaymentHistoryId);

            entity.ToTable("UserPaymentHistory");

            entity.HasOne(d => d.User).WithMany(p => p.UserPaymentHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserPaymentHistory_Users");
        });

        modelBuilder.Entity<UserRegHistory>(entity =>
        {
            entity.HasKey(e => e.RegistrationId);

            entity.ToTable("UserRegHistory");

            entity.Property(e => e.RegistrationId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.UserRegHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserRegHistory_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    internal void LogUserActivity(int userId, string v1, string v2)
    {
        throw new NotImplementedException();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
