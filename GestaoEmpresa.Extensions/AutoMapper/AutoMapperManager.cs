using AutoMapper;
using GestaoEmpresa.Extensions.AutoMapper.Profiles;
using System;

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
                cfg.AddProfile<EmpresaProfile>();
                cfg.AddProfile<FuncionarioProfile>();
                cfg.AddProfile<EnderecoProfile>();
                cfg.AddProfile<JornadaTrabalhoProfile>();
            });
        }
    }
}
