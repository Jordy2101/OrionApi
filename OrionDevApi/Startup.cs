using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ORIONDEV.DATA.Base.Interface;
using ORIONDEV.DATA.DBContexts;
using ORIONDEV.DATA.Repository;
using ORIONDEV.ENTITY.Models;
using ORIONDEV.SERVICES.Base.Interface;
using ORIONDEV.SERVICES.Interface;
using ORIONDEV.SERVICES.Services;

namespace OrionDevApi
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
            var connectionString = Configuration["connectionString"];
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrionDev Api", Version = "v1" });
            });

            services.AddDbContext<OrionDevDataContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //Base Repository
            services.AddScoped<IBaseRepository<Company>, CompanyRepository>();
            services.AddScoped<IBaseRepository<Client>, ClientRepositoy>();
            services.AddScoped<IBaseRepository<ClientAdress>, ClientAdressRepository>();

            //Base Services
            services.AddScoped<IServicesBase<Company>, CompanyServices>();
            services.AddScoped<IServicesBase<Client>, ClientServices>();
            services.AddScoped<IServicesBase<ClientAdress>, ClientAdressServices>();

            //Custom Interface
            services.AddScoped<ICompanyServices, CompanyServices>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IClientAdressServices, ClientAdressServices>();

            var mapper = Infraestructure.Mapping.MapperedEntities.GetMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
