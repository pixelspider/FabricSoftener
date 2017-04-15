using FabricSoftener.Entities.Data;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Entities.Message
{
    public class GrainMessageResponseEntity<TGrain> : BaseEntity, IGrainMessage where TGrain : IGrain
    {
        public string RequesterSiloId { get; set; }
        public object Result { get; set; }
    }
}
