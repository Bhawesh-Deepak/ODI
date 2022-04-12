using Microsoft.Extensions.DependencyInjection;
using ODI.Implementation.GenericImplementation;
using ODI.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODI.API.Helpers
{
    public static class ServiceExtensions
    {
        public static void AddService(this IServiceCollection service)
        {
            service.AddTransient(typeof(IGenericRepository<,>), typeof(Implementation<,>));
            service.AddScoped(typeof(IDapperRepository<>), typeof(DapperImplementation<>));
        }
    }
}
