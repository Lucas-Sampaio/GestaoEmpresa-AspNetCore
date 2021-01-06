﻿using GestaoEmpresa.DAL.Extensions;
using GestaoEmpresa.DAL.Repositorio.RepositorioComum;
using GestaoEmpresa.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEmpresa.DAL.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepository
    {
        private readonly GestaoContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public FuncionarioRepositorio(GestaoContext context) 
        {
            _context = context;
        }


        public void Adicionar(Funcionario entidade)
        {
            _context.Funcionarios.Add(entidade);
        }

        public void AdicionarJornada(JornadaTrabalho jornada)
        {
            _context.Jornadas.Add(jornada);
        }

        public void Atualizar(Funcionario entidade)
        {
            _context.Funcionarios.Update(entidade);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Empresa> ObterPorId(int id, params string[] props)
        {
            return await _context.Empresas.DynamicInclude(props).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Funcionario>> ObterTodos(params string[] props)
        {
            return await _context.Funcionarios.DynamicInclude(props).ToListAsync();
        }

        public void Remover(int id)
        {
            var entity = _context.Funcionarios.Find(id);
            _context.Funcionarios.Remove(entity);
        }

        public void RemoverJornada(int IdJornada)
        {
            var entity = _context.Jornadas.Find(IdJornada);
            _context.Jornadas.Remove(entity);
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            throw new System.NotImplementedException();
        }
    }
}