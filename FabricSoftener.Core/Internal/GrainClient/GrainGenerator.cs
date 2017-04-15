using System;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Interfaces.GrainClient;
using FabricSoftener.Core.Internal.AssemblyManagement;

namespace FabricSoftener.Core.Internal.GrainClient
{
    internal class GrainGenerator<TGrain> : IGrainGenerator<TGrain> where TGrain : IGrain
    {
        private IAssemblyRepository AssemblyRepository => _assemblyRepository ?? (_assemblyRepository = new AssemblyRepository());
        private IAssemblyRepository _assemblyRepository;

        public GrainGenerator(IAssemblyRepository assemblyRepository = null)
        {
            _assemblyRepository = assemblyRepository;
        }

        public TGrain Generate()
        {
            var grainType = AssemblyRepository.GetActualType<TGrain>();
            if (grainType == null)
                return default(TGrain);
            return (TGrain)Activator.CreateInstance(grainType);
        }
    }
}
