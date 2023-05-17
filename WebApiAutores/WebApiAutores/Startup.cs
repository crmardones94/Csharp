using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using WebApiAutores.Controllers;
using WebApiAutores.Middlwares;
using WebApiAutores.Servicios;

namespace WebApiAutores
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

            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddDbContext<AplicationDBcontext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            //services.AddTransient<IServicio, ServicioA>(); //cuando una clase necesite un servicio pasarle el servicio que se seleccion en este caso servicioA
            //services.AddTransient<ServicioA>(); //ambas maneras funcionan

            services.AddTransient<IServicio, ServicioA>();

            services.AddTransient<ServicioTransient>();
            services.AddScoped<ServicioScoped>();
            services.AddSingleton<ServicioSingleton>();

            //addtransient cuando se necesite resolver dara una nueva instancia del serviicoA, bueno para simples funciones (una accion como validacion de mayusuculas ya que no usa estados)
            //addScope solo cambia el tiempo de vida del serivico ya que aumenta, 
            //addsingleton siempre la misma intancia, sirve con la data en memoria

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIautores", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseMiddleware<loguearRespuestaHTTPMiddleware>();

            app.Map("/ruta1", app => //ruta a la cual se va a hacer la peticion
            {
                //interceptando cualquier http
                app.Run(async contexto =>
                {
                    await contexto.Response.WriteAsync("Estoy Intersectando tu wea");
                });
            });

            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

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
