
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Common
{
    public class AutoMapperImplementation : IMapping
    {
        private readonly IMapper _mapper;
        public AutoMapperImplementation()
        {
            _mapper = AutomapperSingleton.GetMapper();
        }

        public TDestination Map<TDestination, TSource>(TSource source)
            where TDestination : class
            where TSource : class
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
