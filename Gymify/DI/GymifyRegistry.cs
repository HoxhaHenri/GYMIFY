using Domain.DI;
using Lamar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    public class GymifyRegistry : ServiceRegistry
    {
        public GymifyRegistry() 
        {
            IncludeRegistry<DomainRegistry>();
        }
    }
}
