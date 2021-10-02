using Infra.DataAccess.Specifics.DBs.EF.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WalletApi.Middleware.HandlerException;
using WalletApi.Middleware.Mapper;
using WalletApi.Middleware.ServicesCollection;

namespace WalletApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Configuration["JWT:Issuer"],
                     ValidAudience = Configuration["JWT:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(Configuration["JWT:ClaveSecreta"])
                     )
                 };
             });


            services.AddControllers();
            services.AddDbContext<WalletContext>(w=> { w.UseSqlServer(Configuration.GetConnectionString("WalletDB"), b => b.MigrationsAssembly("WalletApi")); });
            services.AddDataProtection();
            DependencyInjection.AddServices(services);
            services.AddSingleton(MapperConfigurationProfiles.GetProfileConfig().CreateMapper());
            



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.ConfigureCustomExceptionMiddleware(); 


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
