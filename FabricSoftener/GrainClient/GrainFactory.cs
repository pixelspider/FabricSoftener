using FabricSoftener.Core.Factory;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.GrainClient
{
    public class GrainFactory : IGrainFactory
    {
        private static IGrainFactoryController _grainFactoryController;

        public TGrain GetGrain<TGrain>() where TGrain : IGrain
        {
            return GrainFactoryController.GetGrain<TGrain>();
        }

        private static IGrainFactoryController GrainFactoryController => _grainFactoryController ?? (_grainFactoryController = CoreFactory.CreateGrainFactoryController());
    }
}
