using AutoMapper;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.DominioViewModel.EnderecoViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Extensions.AutoMapper.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, EnderecoVM>();
            CreateMap<Endereco, EnderecoVMVal>();
            CreateMap<EnderecoVMVal, Endereco>();
        }
    }
}
