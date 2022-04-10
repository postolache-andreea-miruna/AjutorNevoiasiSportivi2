using AjutorNevoiasiSportivi2.Services.CompetitieServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs6.Services
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICompetitieService, CompetitieService>();
        }
    }
}

