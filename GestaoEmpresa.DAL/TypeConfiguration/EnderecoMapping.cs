using GestaoEmpresa.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.DAL.TypeConfiguration
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(x => x.Id).HasName("PK_endId");
            builder.Property(x => x.Id).HasColumnName("end_int_id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Logradouro).HasColumnName("end_str_logradouro").HasMaxLength(250).IsUnicode();
            builder.Property(x => x.Bairro).HasColumnName("end_str_bairro").HasMaxLength(100).IsUnicode();
            builder.Property(x => x.Cidade).HasColumnName("end_str_cidade").HasMaxLength(100).IsUnicode();
            builder.Property(x => x.Estado).HasColumnName("end_str_estado").HasMaxLength(50).IsUnicode();
            builder.Property(x => x.Cep).HasColumnName("end_str_cep").HasMaxLength(10).IsRequired();
        }
    }
}
