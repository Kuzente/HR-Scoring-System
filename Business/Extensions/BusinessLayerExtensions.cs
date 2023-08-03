using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class BusinessLayerExtensions
    {
        public static void AutoMapperExtension(this IServiceCollection services)
        {
             services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
        }
    }
}
