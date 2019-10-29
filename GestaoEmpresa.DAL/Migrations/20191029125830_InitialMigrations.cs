using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoEmpresa.DAL.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    end_int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    end_str_cep = table.Column<string>(maxLength: 10, nullable: false),
                    end_str_logradouro = table.Column<string>(maxLength: 250, nullable: true),
                    end_str_bairro = table.Column<string>(maxLength: 100, nullable: true),
                    end_str_cidade = table.Column<string>(maxLength: 100, nullable: true),
                    end_str_estado = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endId", x => x.end_int_id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    emp_int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    emp_str_nome = table.Column<string>(maxLength: 100, nullable: false),
                    emp_str_cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    end_int_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empId", x => x.emp_int_id);
                    table.ForeignKey(
                        name: "FK_emp_end",
                        column: x => x.end_int_id,
                        principalTable: "Endereco",
                        principalColumn: "end_int_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    func_int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    emp_int_id = table.Column<int>(nullable: false),
                    end_int_id = table.Column<int>(nullable: true),
                    func_str_pis = table.Column<string>(maxLength: 20, nullable: true),
                    func_str_matricula = table.Column<string>(maxLength: 20, nullable: false),
                    func_str_cargo = table.Column<string>(maxLength: 50, nullable: false),
                    func_str_nome = table.Column<string>(maxLength: 100, nullable: false),
                    func_str_cpf = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcId", x => x.func_int_id);
                    table.ForeignKey(
                        name: "FK_emp_func",
                        column: x => x.emp_int_id,
                        principalTable: "Empresa",
                        principalColumn: "emp_int_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_func_end",
                        column: x => x.end_int_id,
                        principalTable: "Endereco",
                        principalColumn: "end_int_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JornadaTrabalho",
                columns: table => new
                {
                    jnd_int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    func_int_id = table.Column<int>(nullable: false),
                    jnd_str_diaInicio = table.Column<string>(nullable: false),
                    jnd_str_diaFim = table.Column<string>(nullable: true),
                    jnd_time_horaInicio = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    jnd_time_horaFim = table.Column<TimeSpan>(type: "time(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jndId", x => x.jnd_int_id);
                    table.ForeignKey(
                        name: "FK_func_jnd",
                        column: x => x.func_int_id,
                        principalTable: "Funcionario",
                        principalColumn: "func_int_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_end_int_id",
                table: "Empresa",
                column: "end_int_id",
                unique: true,
                filter: "[end_int_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_emp_int_id",
                table: "Funcionario",
                column: "emp_int_id");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_end_int_id",
                table: "Funcionario",
                column: "end_int_id",
                unique: true,
                filter: "[end_int_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JornadaTrabalho_func_int_id",
                table: "JornadaTrabalho",
                column: "func_int_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JornadaTrabalho");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
