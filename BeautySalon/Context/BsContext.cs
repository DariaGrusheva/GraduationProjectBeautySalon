using BeautySalon.Models;
using BeautySalon.Models.Feedback;
using BeautySalon.Models.Materials;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace BeautySalon.Context
{
    public class BsContext : DbContext
    {
        public BsContext(DbContextOptions<BsContext> options) : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ReportCard> ReportCards { get; set; }
        public virtual DbSet<CategoryService> CategoriesServices { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Arrival> Arrivals { get; set; }
        public virtual DbSet<ArrivalComposition> ArrivalCompositions { get; set; }
        public virtual DbSet<Expenditure> Expenditures { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialGroup> MaterialGroups { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<EmployeeCategory>  EmployeeCategories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<AboutUs> AboutUss { get; set; }


       protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
                builder
                .UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=beauty_salon");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryService>()
                .HasMany(c => c.Employees)
                .WithMany(c => c.CategoryServices)
                .UsingEntity<EmployeeCategory>(
                    j => j.HasOne(p => p.Employee)
                    .WithMany(e => e.EmployeeCategories)
                    .HasForeignKey(p => p.EmployeeId),
                    j => j.HasOne(p => p.CategoryService)
                    .WithMany(c => c.EmployeeCategories)
                    .HasForeignKey(p => p.CategoryId));
        }

    }
}
