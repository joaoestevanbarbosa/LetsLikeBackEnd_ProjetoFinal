using LetsLike_ProjetoFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        //TODO método criado pela interface IEntityTypeConfiguration
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //TODO setando o Id como chave primaria
            builder.HasKey(x => x.Id);
        }
    }
}
