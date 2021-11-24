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
            //TODO adicionar as referências de services com as refer^^encias de interfaces
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
