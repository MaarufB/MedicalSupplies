using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MedicalSuppliesWeb.Model;
using Microsoft.Extensions.Hosting;

namespace MedicalSuppliesModels.Context
{
    public class MSDBContext : IdentityDbContext<ApplicationUser>
    {
        

        

        public MSDBContext(DbContextOptions<MSDBContext> options) : base(options)
        {
           
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerFacility> CustomerFacilities { get; set; }
        public DbSet<CustomerInvoice> CustomerInvoices { get; set; }
        public DbSet<CustomerInvoiceItem> CustomerInvoiceItems { get; set; }
        public DbSet<CustomerNumber> CustomerNumbers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderItem> CustomerOrderItems { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityAddress> FacilityAddresses { get; set; }
        public DbSet<FacilityNumber> FacilityNumbers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ManufacturerAddress> ManufacturerAddresses { get; set; }
        public DbSet<ManufacturerNumber> ManufacturerNumbers { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierAddress> SupplierAddresses { get; set; }
        public DbSet<SupplierInvoice> SupplierInvoices { get; set; }
        public DbSet<SupplierInvoiceItem> SupplierInvoiceItems { get; set; }
        public DbSet<SupplierNumber> SupplierNumbers { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
        public DbSet<SupplierOrderItem> SupplierOrderItems { get; set; }

        public DbSet<TicketStatus> TicketStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HCA52EN;Initial Catalog=MedSup;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerFacility>()
        .HasKey(cf => new { cf.CustomerId, cf.FacilityId });

            modelBuilder.Entity<CustomerFacility>()
                .HasOne(cf => cf.Customer)
                .WithMany(c => c.CustomerFacilities)
                .HasForeignKey(cf => cf.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomerFacility>()
                .HasOne(cf => cf.Facility)
                .WithMany(f => f.CustomerFacilities)
                .HasForeignKey(cf => cf.FacilityId)
                .OnDelete(DeleteBehavior.Restrict);
                  

            base.OnModelCreating(modelBuilder);
        }

        public void SeedData()
        {
            var categories = new List<Category>
                {
                    new Category { CategoryId = 1, CategoryName = "Category 1" },
                    new Category { CategoryId = 2, CategoryName = "Category 2" }
                };

            var colours = new List<Colour>
                {
                    new Colour { ColourId = 1, ColourName = "Red" },
                    new Colour { ColourId = 2, ColourName = "Blue" }
                };

            var customers = new List<Customer>
                {
                    new Customer { FirstName = "John", LastName = "Doe", Height = "180" },
                    new Customer { FirstName = "Jane", LastName = "Smith", Height = "170" }
                };

            Categories.AddRange(categories);
            Colours.AddRange(colours);
            Customers.AddRange(customers);

            SaveChanges();
        }




    }
}
