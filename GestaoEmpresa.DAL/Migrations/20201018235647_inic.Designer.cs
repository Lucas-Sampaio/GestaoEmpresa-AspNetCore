﻿// <auto-generated />
using System;
using GestaoEmpresa.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoEmpresa.DAL.Migrations
{
    [DbContext(typeof(GestaoContext))]
    [Migration("20201018235647_inic")]
    partial class inic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestaoEmpresa.Dominio.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("emp_int_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnName("emp_str_cnpj")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<int?>("IdEndereco")
                        .HasColumnName("end_int_id")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("emp_str_nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("PK_empId");

                    b.HasIndex("IdEndereco")
                        .IsUnique()
                        .HasFilter("[end_int_id] IS NOT NULL");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("GestaoEmpresa.Dominio.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("end_int_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnName("end_str_bairro")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("end_str_cep")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Cidade")
                        .HasColumnName("end_str_cidade")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Estado")
                        .HasColumnName("end_str_estado")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("Logradouro")
                        .HasColumnName("end_str_logradouro")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("PK_endId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("GestaoEmpresa.Dominio.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("func_int_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("func_str_cpf")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasColumnName("func_str_cargo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("IdEmpresa")
                        .HasColumnName("emp_int_id")
                        .HasColumnType("int");

                    b.Property<int?>("IdEndereco")
                        .HasColumnName("end_int_id")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnName("func_str_matricula")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("func_str_nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Pis")
                        .HasColumnName("func_str_pis")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id")
                        .HasName("PK_funcId");

                    b.HasIndex("IdEmpresa");

                    b.HasIndex("IdEndereco")
                        .IsUnique()
                        .HasFilter("[end_int_id] IS NOT NULL");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("GestaoEmpresa.Dominio.JornadaTrabalho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("jnd_int_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaFim")
                        .HasColumnName("jnd_str_diaFim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaInicio")
                        .IsRequired()
                        .HasColumnName("jnd_str_diaInicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("HoraFim")
                        .HasColumnName("jnd_time_horaFim")
                        .HasColumnType("time(0)");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnName("jnd_time_horaInicio")
                        .HasColumnType("time(0)");

                    b.Property<int>("IdFuncionario")
                        .HasColumnName("func_int_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_jndId");

                    b.HasIndex("IdFuncionario");

                    b.ToTable("JornadaTrabalho");
                });

            modelBuilder.Entity("GestaoEmpresa.Dominio.Empresa", b =>
                {
                    b.HasOne("GestaoEmpresa.Dominio.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("GestaoEmpresa.Dominio.Empresa", "IdEndereco")
                        .HasConstraintName("FK_emp_end");
                });

            modelBuilder.Entity("GestaoEmpresa.Dominio.Funcionario", b =>
                {
                    b.HasOne("GestaoEmpresa.Dominio.Empresa", null)
                        .WithMany("Funcionarios")
                        .HasForeignKey("IdEmpresa")
                        .HasConstraintName("FK_emp_func")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoEmpresa.Dominio.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("GestaoEmpresa.Dominio.Funcionario", "IdEndereco")
                        .HasConstraintName("FK_func_end");
                });

            modelBuilder.Entity("GestaoEmpresa.Dominio.JornadaTrabalho", b =>
                {
                    b.HasOne("GestaoEmpresa.Dominio.Funcionario", null)
                        .WithMany("Jornadas")
                        .HasForeignKey("IdFuncionario")
                        .HasConstraintName("FK_func_jnd")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
