using AutoMapper;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.DominioViewModel.EmpresaViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Extensions.AutoMapper.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<Empresa, EmpresaVM>().ForMember(dest => dest.Cep, opt => { opt.MapFrom(src => src.Endereco.Cep); });
            CreateMap<Empresa, EmpresaVMVal>();
            CreateMap<EmpresaVMVal, Empresa>();
        }
    }
}
