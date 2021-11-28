using LetsLike_ProjetoFinal.Configurations;
using LetsLike_ProjetoFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.Data
{
    public class LetsLikeContest : DbContext
    {
        //TODO instancia das models
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<UsuarioLikeProjeto> UsuariosLikeProjetos { get; set; }

        public LetsLikeContest(DbContextOptions<LetsLikeContest> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = @"Server=LAPTOP-NO06IHL0\\SQLEXPRESS;Database=letsLike;Trusted_connection=True;";

                optionsBuilder.UseSqlServer(connection);
            }
        }
        //TODO método que modela as configurations que criamos na pasta configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO ApplyConfiguration aplica as configurações de entidade que criamos
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProjetoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioLikeProjetoConfiguration());
        }
    }
}
