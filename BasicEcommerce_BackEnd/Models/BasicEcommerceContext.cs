using BasicEcommerce_BackEnd.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BasicEcommerce_BackEnd.Models;

public partial class BasicEcommerceContext : DbContext
{
    private readonly AppSettings AppSettings;
    public BasicEcommerceContext(IOptions<AppSettings> appSettings)
    {
        AppSettings = appSettings.Value;
    }

    public BasicEcommerceContext(DbContextOptions<BasicEcommerceContext> options, IOptions<AppSettings> appSettings)
        : base(options)
    {
        AppSettings = appSettings.Value;
    }

    public virtual DbSet<ApiUser> ApiUsers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(this.AppSettings.ConnectionStrings.DefaultConnection);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiUser>(entity =>
        {
            entity.HasKey(e => e.IdApiUser).HasName("PK__ApiUser__109E8152D97FFEB8");

            entity.ToTable("ApiUser");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Idclient).HasName("PK__Client__F113BB075CBF836B");

            entity.ToTable("Client");

            entity.Property(e => e.IdNumberPerson)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumbre)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Person).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdNumberPerson)
                .HasConstraintName("FK__Client__IdNumber__286302EC");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Order__C38F30095E4CE3ED");

            entity.ToTable("Order");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("money");

            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Idclient)
                .HasConstraintName("FK__Order__TotalAmou__31EC6D26");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.IdOrderDetail).HasName("PK__OrderDet__D8E06C5154C58214");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Amount).HasColumnType("money");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK__OrderDeta__IdOrd__34C8D9D1");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__OrderDeta__IdPro__35BCFE0A");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.IdNumber).HasName("PK__Person__62DF803211E19143");

            entity.ToTable("Person");

            entity.Property(e => e.IdNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__2E8946D4AE3C65B1");

            entity.ToTable("Product");

            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__B7C9263883EC9E66");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdNumberPerson)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdNumberPerson)
                .HasConstraintName("FK__Users__password__2D27B809");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
