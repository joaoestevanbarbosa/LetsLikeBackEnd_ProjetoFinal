using LetsLike_ProjetoFinal.Interfaces;
using LetsLike_ProjetoFinal.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.Configurations
{
    public class Factory
    {
        public static void RegisterServices (IServiceCollection services)
        {
            // Adicionando Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IUsuarioLikeProjetoService, UsuarioLikeProjetoService>();
        }
    }
}
