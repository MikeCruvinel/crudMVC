﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace crud.DATA.Models
{
    public partial class CrudmvcContext : DbContext
    {
        public CrudmvcContext()
        {
        }

        public CrudmvcContext(DbContextOptions<CrudmvcContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=myservercrud.database.windows.net;Database=crudMVC;User Id=adazure;Password=Vitu@020700;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Funcionario_Empresa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}