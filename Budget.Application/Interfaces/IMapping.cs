using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Common
{
    public interface IMapping        
    {
        TDestination Map<TDestination, TSource>(TSource source) 
            where TDestination : class 
            where TSource : class;       
    }
}
