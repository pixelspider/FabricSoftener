using System;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Interfaces.GrainClient;
using System.Collections.Generic;
using System.Linq;

namespace FabricSoftener.Core.Internal.AssemblyManagement
{
    internal class AssemblyRepository : IAssemblyRepository
    {
        private static IEnumerable<Type> _grainAssemblyCollection;

        public Type GetActualType<TGrain>() where TGrain : IGrain
        {
            if(typeof(TGrain).IsInterface)
            {
                return GrainAssemblyCollection.FirstOrDefault(x => x.GetInterface(typeof(TGrain).Name) != null);
            }
            return typeof(TGrain);
        }

        private IEnumerable<Type> GrainAssemblyCollection
        {
            get
            {
                if(_grainAssemblyCollection == null)
                {
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    var nonDynamicTypes = assemblies.Where(x => !x.IsDynamic);
                    var types = nonDynamicTypes.SelectMany(x => x.ExportedTypes);
                    _grainAssemblyCollection = types.Where(x => x.GetInterface("IGrain") != null);
                }
                return _grainAssemblyCollection;
            }
        }
    }
}
