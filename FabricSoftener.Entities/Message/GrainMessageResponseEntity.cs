using FabricSoftener.Entities.Data;
using FabricSoftener.Interfaces.GrainClient;
using System;

namespace FabricSoftener.Entities.Message
{
    [Serializable]
    public class GrainMessageResponseEntity<TGrain> : BaseEntity, IGrainMessage where TGrain : IGrain
    {
        public string RequesterSiloId { get; set; }
        public string ResponseTaskCompletionSourceId { get; set; }
        public Type GrainType { get; set; }
        public object Result { get; set; }
    }
}
