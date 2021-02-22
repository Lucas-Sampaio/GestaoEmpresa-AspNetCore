using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoEmpresa.DAL.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    emp_int_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_str_nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    emp_str_cnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    emp_str_cep = table.Column<string>(type: "varchar(100)", nullable: true),
                    emp_str_logradouro = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    emp_str_bairro = table.Column<string>(type: "varchar(100)", nullable: true),
                    emp_str_cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    emp_str_estado = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empId", x => x.emp_int_id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    func_int_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_int_id = table.Column<int>(type: "int", nullable: false),
                    func_str_pis = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    func_str_matricula = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    func_str_cargo = table.Column<string>(type: "varchar(100)", nullable: false),
                    func_str_nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    func_str_cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    func_str_cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    func_str_logradouro = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    func_str_bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    func_str_cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    func_str_estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "JornadaTrabalho",
                columns: table => new
                {
                    jnd_int_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    func_int_id = table.Column<int>(type: "int", nullable: false),
                    jnd_str_diaInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jnd_str_diaFim = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "IX_Funcionario_emp_int_id",
                table: "Funcionario",
                column: "emp_int_id");

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
        }
    }
}
