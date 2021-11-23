using LetsLike_ProjetoFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.Configurations
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            //TODO setando o Id como chave primaria
            builder.HasKey(x => x.Id);

            //TODO criando a FK vinculando o objeto virtual que foi criado na tabela de usuario
            builder.HasOne(fk => fk.UsuarioCadastro)
                .WithMany(fk => fk.Projeto)
                .HasForeignKey(fk => fk.IdUsuarioCadastro)
                // TODO força criar o nome com base no que vc esta passando
                .HasConstraintName("FK_PROJETO_USUARIO_ID");
        }

    }
}
