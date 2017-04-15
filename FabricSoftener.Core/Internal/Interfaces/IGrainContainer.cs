using FabricSoftener.Entities.Message;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IGrainContainer<TGrain> where TGrain : IGrain
    {
        bool IsBusy { get; }
        void ProcessMessage(GrainMessageRequestEntity<TGrain> message);
    }
}
