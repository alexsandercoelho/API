﻿using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        private IConfiguration _configuration { get; set; }
        public ContextBase(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration; 
        }

        public DbSet<Perfil> Perfil { set; get; }
        public DbSet<RegrasDistribuicao> RegrasDistribuicao { set; get; }
        public DbSet<GrupoDistribuicao> GrupoDistribuicao { set; get; }
        public DbSet<Funcionalidade> Funcionalidade { set; get; }
        public DbSet<Pessoa> Pessoa { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }
    }
}
