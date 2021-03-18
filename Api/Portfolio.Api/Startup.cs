using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Portfolio.Core.AutoMapper;
using Portfolio.Core.Interfaces;
using Portfolio.Core.Interfaces.Common;
using Portfolio.Core.Services;
using Portfolio.Core.Services.Common;
using Portfolio.Database;
using Portfolio.Helpers;

namespace Portfolio
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
            services.AddControllers();

            var config = Configuration["ConnectionString:DefaultConnection"];
            services.AddDbContext<PortfolioContext>(options =>
            {
                options.UseSqlServer(config);
            });

            services.AddAutoMapper(typeof(PortfolioMappings));

            services.AddScoped<ISkillGroupService, SkillGroupService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IAboutMeService, AboutMeService>();
            services.AddScoped(typeof(IBaseRepository<,,,>), typeof(BaseRepository<,,,>));
            services.AddScoped(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddSingleton<IUploadImageHelper, UploadImageHelper>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API WSVAP (WebSmartView)", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
                } );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
