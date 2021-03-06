﻿using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sistema> Sistema { set; get; }
        public DbSet<UsuarioSistema> UsuarioSistema { set; get; }
        public DbSet<Perfil> Perfil { set; get; }
        public DbSet<Grupo> Grupo{ set; get; }
        public DbSet<Pessoa> Pessoa { set; get; }
        public DbSet<Regra> Regra { set; get; }
        public DbSet<Versao> Versao { set; get; }
        public DbSet<Funcionalidade> Funcionalidade { set; get; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }


        public string ObterStringConexao()
        {
            return "Data Source=LEGION5R7;Initial Catalog=AP2;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            
        }


    }

    public class Funcionalidades
    {
    }
}
