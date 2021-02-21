using GestaoEmpresa.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEmpresa.DAL.TypeConfiguration
{
    public class JornadaTrabalhoMapping : IEntityTypeConfiguration<JornadaTrabalho>
    {
        public void Configure(EntityTypeBuilder<JornadaTrabalho> builder)
        {
            builder.ToTable("JornadaTrabalho");
            builder.HasKey(x => x.Id).HasName("PK_jndId");
            builder.Property(x => x.Id).HasColumnName("jnd_int_id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.DiaInicio).HasColumnName("jnd_str_diaInicio").HasConversion<string>().IsRequired();
            builder.Property(x => x.DiaFim).HasColumnName("jnd_str_diaFim").HasConversion<string>().IsRequired(false);
            builder.Property(x => x.HoraInicio).HasColumnName("jnd_time_horaInicio").IsRequired().HasColumnType("time(0)");
            builder.Property(x => x.HoraFim).HasColumnName("jnd_time_horaFim").IsRequired().HasColumnType("time(0)");
            builder.Property(x => x.IdFuncionario).HasColumnName("func_int_id").IsRequired();
        }
    }
}
