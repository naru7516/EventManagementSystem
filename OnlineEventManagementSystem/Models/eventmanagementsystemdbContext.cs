using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineEventManagementSystem.Models;

namespace OnlineEventManagementSystem.Models;

public partial class eventmanagementsystemdbContext : DbContext
{
    public eventmanagementsystemdbContext()
    {
    }

    public eventmanagementsystemdbContext(DbContextOptions<eventmanagementsystemdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BuisnessService> BuisnessServices { get; set; }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackStatus> FeedbackStatuses { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=eventmanagementsystemdb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area)
                .HasMaxLength(45)
                .HasColumnName("area");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .HasColumnName("city");
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(45)
                .HasColumnName("house_number");
            entity.Property(e => e.Pincode)
                .HasMaxLength(6)
                .HasColumnName("pincode");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .HasColumnName("state");
        });

        modelBuilder.Entity<BuisnessService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("buisness_services");

            entity.HasIndex(e => e.BusinessId, "serviceprovidersid_idx");

            entity.HasIndex(e => e.ServicesId, "servicesid_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ServicesId).HasColumnName("services_id");

            entity.HasOne(d => d.Business).WithMany(p => p.BuisnessServices)
                .HasForeignKey(d => d.BusinessId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("buisness_id");

            entity.HasOne(d => d.Services).WithMany(p => p.BuisnessServices)
                .HasForeignKey(d => d.ServicesId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("services_id");
        });

        modelBuilder.Entity<Business>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("businesses");

            entity.HasIndex(e => e.AddressId, "business_address_id_idx");

            entity.HasIndex(e => e.ContactNumber, "contactnumber_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.LoginId, "loginid_idx");

            entity.HasIndex(e => e.RegistrationNumber, "registration_number_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(10)
                .HasColumnName("contact_number");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(45)
                .HasColumnName("registration_number");
            entity.Property(e => e.WorkingStatus).HasColumnName("working_status");

            entity.HasOne(d => d.Address).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("business_address_id");

            entity.HasOne(d => d.Login).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("business_login_id");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(45)
                .HasColumnName("category_description");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(45)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.HasIndex(e => e.AddressId, "client_address_id_idx");

            entity.HasIndex(e => e.ContactNumber, "contactnumber_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => new { e.LoginId, e.AddressId }, "loginid_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(10)
                .HasColumnName("contact_number");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Address).WithMany(p => p.Clients)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("client_address_id");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("feedback");

            entity.HasIndex(e => e.ClientId, "clientid_idx");

            entity.HasIndex(e => e.FeedbackStatusId, "feedbackstatusid_idx");

            entity.HasIndex(e => e.BusinessServiceId, "fsp-sid_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BusinessReply)
                .HasMaxLength(100)
                .HasColumnName("business_reply");
            entity.Property(e => e.BusinessServiceId).HasColumnName("business_service_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .HasColumnName("comment");
            entity.Property(e => e.FeedbackStatusId).HasColumnName("feedback_status_id");

            entity.HasOne(d => d.BusinessService).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.BusinessServiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("feedback_buisness_service_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("feedback_client_id");

            entity.HasOne(d => d.FeedbackStatus).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.FeedbackStatusId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("feedback_status_id");
        });

        modelBuilder.Entity<FeedbackStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("feedback_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FeedbackStatus1)
                .HasMaxLength(45)
                .HasColumnName("feedback_status");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("login");

            entity.HasIndex(e => e.Username, "logincol_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserTypeId, "roleid_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .HasColumnName("password");
            entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");

            entity.HasOne(d => d.UserType).WithMany(p => p.Logins)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("user_type_id");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.ClientId, "clientid_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingDate).HasColumnName("booking_date");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(45)
                .HasColumnName("payment_mode");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("client_id");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order_details");

            entity.HasIndex(e => e.OrderId, "orderid_idx");

            entity.HasIndex(e => e.BuisnessServiceId, "sp-sid_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuisnessServiceId).HasColumnName("buisness_service_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.BuisnessService).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BuisnessServiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("business_service_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("order_id");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("services");

            entity.HasIndex(e => e.CategoriesId, "categories_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoriesId).HasColumnName("categories_id");
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(45)
                .HasColumnName("service_description");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(45)
                .HasColumnName("service_name");

            entity.HasOne(d => d.Categories).WithMany(p => p.Services)
                .HasForeignKey(d => d.CategoriesId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("categories_id");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_type");

            entity.HasIndex(e => e.UserType1, "rolename_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserType1)
                .HasMaxLength(45)
                .HasColumnName("user_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<OnlineEventManagementSystem.Models.CRegister>? CRegister { get; set; }

    public DbSet<OnlineEventManagementSystem.Models.BRegister>? BRegister { get; set; }
}
