using BeautySalon.Auth.BLL;
using BeautySalon.Auth.Context;
using BeautySalon.Auth.Securities;
using BeautySalon.Context;
using BeautySalon.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BsContext>(options => options.UseNpgsql());
            builder.Services.AddDbContext<AuthContext>(options => options.UseNpgsql());
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddScoped<IAboutUsInfo, AboutUsInfo>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IEncryptService, EncryptService>();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var jwt = builder.Configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>()
                ?? throw new Exception("JwtConfiguration not found");

            builder.Services.AddSingleton(provider => jwt);

            builder.Services.AddAuthorization();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                       .AddJwtBearer(options =>
                       {
                           options.TokenValidationParameters = new()
                           {
                               ValidateIssuer = true,
                               ValidateAudience = true,
                               ValidateLifetime = true,
                               ValidateIssuerSigningKey = true,
                               ValidIssuer = jwt.Issuer,
                               ValidAudience = jwt.Audience,
                               IssuerSigningKey = jwt.GetSigningKey()
                           };
                       });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
