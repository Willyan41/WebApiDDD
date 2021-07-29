using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;

namespace WebApi.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("BS_001_Usuario");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Nome)
                .HasConversion(p => p.ToString(), p => p)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Email)
                .HasConversion(p => p.ToString(), p => p)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Senha)
                .HasConversion(p => p.ToString(), p => p)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("varchar(100)");

        }


    }
}
