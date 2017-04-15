using FabricSoftener.Entities.Data;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Entities.Message
{
    public class GrainMessageRequestEntity<TGrain> : BaseEntity, IGrainMessage where TGrain : IGrain
    {
        public string RequesterSiloId { get; set; }
        public string MethodName { get; set; }
        public object[] Arguments { get; set; }
    }
}
