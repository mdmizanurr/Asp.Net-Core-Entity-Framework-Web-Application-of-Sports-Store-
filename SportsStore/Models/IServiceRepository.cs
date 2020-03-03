using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IServiceRepository
    {

        IQueryable<Service> Services { get; }
        //void SaveService(Service service);
    }
}
