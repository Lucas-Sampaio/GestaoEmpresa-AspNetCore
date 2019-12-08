using AutoMapper;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.DominioViewModel.FuncionarioViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Extensions.AutoMapper.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Funcionario, FuncionarioVM>().ForMember(dest => dest.Cep, opt => { opt.MapFrom(src => src.Endereco.Cep); });
            CreateMap<Funcionario, FuncionarioVMVal>();
            CreateMap<FuncionarioVMVal, Funcionario>();
        }
    }
}
