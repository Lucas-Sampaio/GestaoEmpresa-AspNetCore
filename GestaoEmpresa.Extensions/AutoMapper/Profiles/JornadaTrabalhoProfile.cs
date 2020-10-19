using AutoMapper;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.Dominio.Enums;
using GestaoEmpresa.DominioViewModel.JornadaTrabalhoViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Extensions.AutoMapper.Profiles
{
    public class JornadaTrabalhoProfile : Profile
    {
        public JornadaTrabalhoProfile()
        {
            CreateMap<JornadaTrabalho, JornadaVM>().ForMember(dest => dest.PeriodoDia, opt =>
            {
                opt.MapFrom(src => src.DiaFim.HasValue ? $"De {src.DiaInicio.ToString()} a {src.DiaFim.ToString()}" : src.DiaInicio.ToString());
            }).ForMember(dest => dest.PeriodoHora, opt => { opt.MapFrom(src => $"De {src.HoraInicio.ToString(@"hh\:mm\:ss")} as {src.HoraFim.ToString(@"hh\:mm\:ss")}"); });
            CreateMap<JornadaTrabalho, JornadaVMVal>().ForMember(dest => dest.DiaInicio, opt => opt.MapFrom(src => (int)src.DiaInicio))
                                                          .ForMember(dest => dest.DiaFim, opt => opt.MapFrom(src => src.DiaFim.HasValue ? (int)src.DiaFim : (int?)null));
            CreateMap<JornadaVMVal, JornadaTrabalho>()
                                                          .ForMember(dest => dest.DiaInicio, opt => opt.MapFrom(src => Enum.Parse<EDiaSemana>(src.DiaInicio.ToString())))
                                                          .ForMember(dest => dest.DiaFim, opt => opt.MapFrom
                                                          (src => src.DiaFim.HasValue ? Enum.Parse<EDiaSemana>(src.DiaFim.ToString()) : (EDiaSemana?)null));
        }
    }
}
