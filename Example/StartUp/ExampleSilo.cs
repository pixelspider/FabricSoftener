using Example.Grains.Interfaces;
using FabricSoftener.Interfaces.GrainClient;
using FabricSoftener.Interfaces.Silo;
using System;

namespace Example.StartUp
{
    public class ExampleSilo : ISilo
    {
        private readonly IGrainFactory _grainFactory;
        public ExampleSilo(IGrainFactory grainFactory)
        {
            _grainFactory = grainFactory;
        }

        public async void Start()
        {
            var myGrain = _grainFactory.GetGrain<IMyGrain>();
            var sum = await myGrain.CalculateSumAsync(2, 4);
        }
        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
