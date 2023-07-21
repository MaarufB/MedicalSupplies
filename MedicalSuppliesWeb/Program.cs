using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserRolesNew.Data;
using UserRolesNew.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI;
using UserRolesData.Context;
using UserRolesNew.Services.Repositories;
using UserRolesNew.Services.Contracts;

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




            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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


            //the following is the newly added code to redirect to login page on start. All other methods did not get this result


            //app.MapWhen(context => !context.Request.Path.StartsWithSegments("/Identity", StringComparison.OrdinalIgnoreCase) &&
            //                        !context.Request.Path.StartsWithSegments("/Home/Login", StringComparison.OrdinalIgnoreCase) &&
            //                        !context.Request.Path.StartsWithSegments("/Account/Login", StringComparison.OrdinalIgnoreCase),
            //     appBuilder =>
            //     {
            //         appBuilder.Use(async (context, next) =>
            //         {
            //             context.Response.Redirect("/Identity/Account/Login");
            //             await next.Invoke();
            //         });
            //     });


            //end




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