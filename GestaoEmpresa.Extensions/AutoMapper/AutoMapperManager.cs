using AutoMapper;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.Dominio.Enums;
using GestaoEmpresa.DominioViewModel.EmpresaViewModel;
using GestaoEmpresa.DominioViewModel.EnderecoViewModel;
using GestaoEmpresa.DominioViewModel.FuncionarioViewModel;
using GestaoEmpresa.DominioViewModel.JornadaTrabalhoViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Extensions.AutoMapper
{
    public class AutoMapperManager
    {
        // retorna apenas uma instancia da classe
        private static readonly Lazy<AutoMapperManager> _instance =
            new Lazy<AutoMapperManager>(() =>
            {
                return new AutoMapperManager();
            });
        public static AutoMapperManager Instance
        {
            get => _instance.Value;
        }
        private MapperConfiguration _config;
        public IMapper Mapper
        {
            get => _config.CreateMapper();
        }
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
        private AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {
                #region Empresa
                cfg.CreateMap<Empresa, EmpresaVM>().ForMember(dest => dest.Cep, opt => { opt.MapFrom(src => src.Endereco.Cep); });
                //.ForMember(dest => dest.Funcionarios, opt => { opt.MapFrom(src => src.Funcionarios);});
                cfg.CreateMap<Empresa, EmpresaVMVal>();
                cfg.CreateMap<EmpresaVMVal, Empresa>();
                #endregion
                #region Funcionario
                cfg.CreateMap<Funcionario, FuncionarioVM>().ForMember(dest => dest.Cep, opt => { opt.MapFrom(src => src.Endereco.Cep); });
                cfg.CreateMap<Funcionario, FuncionarioVMVal>();
                cfg.CreateMap<FuncionarioVMVal, Funcionario>();
                #endregion
                #region Endereco
                cfg.CreateMap<Endereco, EnderecoVM>();
                cfg.CreateMap<Endereco, EnderecoVMVal>();
                cfg.CreateMap<EnderecoVMVal, Endereco>();
                #endregion
                #region JornadaTrabalho
                cfg.CreateMap<JornadaTrabalho, JornadaVM>().ForMember(dest => dest.PeriodoDia, opt =>
                {
                    opt.MapFrom(src => src.DiaFim.HasValue ? $"De {src.DiaInicio.ToString()} a {src.DiaFim.ToString()}" : src.DiaInicio.ToString());
                }).ForMember(dest => dest.PeriodoHora, opt => { opt.MapFrom(src => $"De {src.HoraInicio.ToString(@"hh\:mm\:ss")} as {src.HoraFim.ToString(@"hh\:mm\:ss")}"); });
                cfg.CreateMap<JornadaTrabalho, JornadaVMVal>().ForMember(dest => dest.DiaInicio, opt => opt.MapFrom(src => (int)src.DiaInicio))
                                                              .ForMember(dest => dest.DiaFim, opt => opt.MapFrom(src => src.DiaFim.HasValue ? (int)src.DiaFim : (int?)null));
                cfg.CreateMap<JornadaVMVal, JornadaTrabalho>()
                                                              .ForMember(dest => dest.DiaInicio, opt => opt.MapFrom(src => Enum.Parse<EDiaSemana>(src.DiaInicio.ToString())))
                                                              .ForMember(dest => dest.DiaFim, opt => opt.MapFrom
                                                              (src => src.DiaFim.HasValue ? Enum.Parse<EDiaSemana>(src.DiaFim.ToString()) : (EDiaSemana?)null));

                #endregion
            });
        }
    }
}
