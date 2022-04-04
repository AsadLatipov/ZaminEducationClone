using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ZaminEducationClone.Data.Contexts;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Data.Repositories;
using ZaminEducationClone.Service.Helpers;
using ZaminEducationClone.Service.Interfaces;
using ZaminEducationClone.Service.Mappers;
using ZaminEducationClone.Service.Services;

namespace ZaminEducationClone.Api
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
            //Add DbContext
            services.AddDbContext<ZaminEducationContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ZaminDataBase"));
            });

            // Mapping
            services.AddAutoMapper(typeof(MappingProfile));
            
            // Accessor
            services.AddHttpContextAccessor();

            // My services
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILessonService, LessonService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            
            // For Serialize
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            
            // Defaults
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZaminEducationClone.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZaminEducationClone.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            if (app.ApplicationServices.GetService<IHttpContextAccessor>() != null)
            {
                AccesToContext.Accessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            }

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
