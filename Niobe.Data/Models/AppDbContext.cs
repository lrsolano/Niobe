using Microsoft.EntityFrameworkCore;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niobe.Data
{
    public class AppDbContext : DbContext
    {
        const string connectionString = "Database=projetoNiobe;Data Source=192.168.18.100;User Id=root;Password=1234";

        public AppDbContext() : base() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Armazem>()
                .HasOne(armazem => armazem.Filial)
                .WithMany(filial => filial.Armazens)
                .HasForeignKey(armazem => armazem.IdFilial);
            builder.Entity<Rua>()
                .HasOne(rua => rua.Armazem)
                .WithMany(armazem => armazem.Ruas)
                .HasForeignKey(rua => rua.IdArmazem);
            builder.Entity<Coluna>()
                .HasOne(coluna => coluna.Rua)
                .WithMany(rua => rua.Colunas)
                .HasForeignKey(coluna => coluna.IdRua);
            builder.Entity<Nivel>()
               .HasOne(nivel => nivel.Coluna)
               .WithMany(coluna => coluna.Niveis)
               .HasForeignKey(nivel => nivel.IdColuna);
            builder.Entity<Bloco>()
               .HasOne(bloco => bloco.Nivel)
               .WithMany(nivel => nivel.Blocos)
               .HasForeignKey(bloco => bloco.IdNivel);
            builder.Entity<Contrato>()
                .HasOne(contrato => contrato.Filial)
                .WithMany(filial => filial.Contratos)
                .HasForeignKey(contrato => contrato.IdFilial);
            builder.Entity<Contrato>()
                .HasOne(contrato => contrato.Cliente)
                .WithMany(cliete => cliete.Contratos)
                .HasForeignKey(cotrato => cotrato.IdCliente);
            builder.Entity<Contrato>()
                .HasOne(contrato => contrato.Armazem)
                .WithMany(armazem => armazem.Contratos)
                .HasForeignKey(contrato => contrato.IdArmazem);
            builder.Entity<Contrato>()
                .HasOne(contrato => contrato.Endereco)
                .WithOne(endereco => endereco.Contrato)
                .HasForeignKey<Endereco>(endereco => endereco.IdContrato)
                .IsRequired();
            builder.Entity<Cliente>()
                .HasOne(cliente => cliente.Endereco)
                .WithOne(endereco => endereco.Cliente)
                .HasForeignKey<Endereco>(endereco => endereco.IdCliente)
                .IsRequired();

        }

        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Armazem> Armazems { get; set; }
        public DbSet<Rua> Ruas { get; set; }
        public DbSet<Coluna> Colunas { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<GeradorEnderecos> GeradorEndereços { get; set; }
    }
}
