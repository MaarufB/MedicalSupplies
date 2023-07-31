using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MedicalSuppliesWeb.Data;
using MedicalSuppliesWeb.Models;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;
using MedicalSuppliesServices.Services.Repositories;
using AutoMapper;
using MedicalSuppliesMapper;

namespace UserRolesNew
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));


            builder.Services.AddDbContext<MSDBContext>(options =>
                options.UseSqlServer(connectionString));


            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();



            builder.Services.AddScoped(p =>
            {
                var configuration = new MapperConfiguration(conf => {
                    conf.AddProfile(new MappingProfiles());
                });

                return configuration.CreateMapper();
            });









            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //  .AddEntityFrameworkStores<ApplicationDbContext>()
            //  .AddSignInManager<SignInManager<ApplicationUser>>();

            //builder.Services.AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //   .AddEntityFrameworkStores<ApplicationDbContext>();

            //builder.Services.AddDefaultIdentity<ApplicationUser>()
            //.AddRoles<IdentityRole>()
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders()
            //.AddSignInManager<SignInManager<ApplicationUser>>();



            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddDefaultUI()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager<SignInManager<ApplicationUser>>();

            builder.Services.AddScoped<SignInManager<ApplicationUser>>();

            builder.Services.AddScoped<IProductRepo, Productrepo>();
            builder.Services.AddScoped<ICustomerInvoiceRepo, CustomerInvoiceRepo>();
            builder.Services.AddScoped<ICustomerOrderRepo, CustomerOrderRepo>();
            builder.Services.AddScoped<ISupplierInvoiceRepo, SupplierInvoiceRepo>();
            builder.Services.AddScoped<ISupplierOrderRepo, SupplierOrderRepo>();
            builder.Services.AddScoped<IInventoryRepo, InventoryRepo>();
            builder.Services.AddScoped<IFacilityRepo, FacilityRepo>();
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<ISupplierRepo, SupplierRepo>();
            builder.Services.AddScoped<IManufacturerRepo, ManufacturerRepo>();
            builder.Services.AddScoped<IColourRepo, ColourRepo>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<ILocationRepo, LocationRepo>();




            //configuration for automapper

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(Program).Assembly);
            });

            var mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);




            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            //builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();


            var app = builder.Build();

            //app.Services.AddTransient<IEmailSender, SmtpEmailSender>();




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


        




            app.MapRazorPages();
            app.MapControllers();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "identity",
                    areaName: "Identity",
                    pattern: "{area=Identity}/{controller=Account}/{action=Login}/{id?}");

                endpoints.MapRazorPages();
            });










            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();


                    await ContextSeed.SeedRolesAsync(userManager, roleManager);
                    await ContextSeed.SeedAdminAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            await app.RunAsync();
        }
    }
}