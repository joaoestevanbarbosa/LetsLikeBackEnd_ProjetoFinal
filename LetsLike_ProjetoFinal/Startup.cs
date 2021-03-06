using LetsLike_ProjetoFinal.Configurations;
using LetsLike_ProjetoFinal.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace LetsLike_ProjetoFinal
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
            // TODO - Setar o nosso contexto quando a aplica??o for ao ar 
            services.AddDbContext<LetsLikeContest>(
              options => options.
              UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //TODO adicionar o contexto ao escopo inicial
            services.AddDbContext<LetsLikeContest>();

            //TODO indicando acessos ao HTTP Context para trabalhar com os retornos http
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LetsLike_ProjetoFinal", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            });

            //TODO adicionando a Invers?o de controle criada na Classe Factory
            RegisterServicesPrivate(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LetsLike_ProjetoFinal v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // TODO m?todo criado para instanciar a factory
        private void RegisterServicesPrivate(IServiceCollection services)
        {
            Factory.RegisterServices(services);
        }
    }
}
