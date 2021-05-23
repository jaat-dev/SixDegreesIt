using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SixDegreesIt.Business.Helpers;
using SixDegreesIt.Business.Usuario;
using SixDegreesIt.DataAccess.Data;
using SixDegreesIt.DataAccess.Helpers;
using SixDegreesIt.DataAccess.Usuarios;

namespace SixDegreesIt.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(cfg => cfg.AddPolicy("AllowWebApp",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
            });

            services.AddTransient<SeedDb>();
            services.AddScoped<IModelHelper, ModelHelper>();
            services.AddScoped<IUsuario, Usuario>();
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<IUsuarioDAO, UsuarioDAO>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SixDegreesIt.Services", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SixDegreesIt.Services v1"));
            }
            app.UseCors("AllowWebApp");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
