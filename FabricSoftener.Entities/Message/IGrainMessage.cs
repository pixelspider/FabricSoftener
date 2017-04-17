using FabricSoftener.Entities.Data;
using System;

namespace FabricSoftener.Entities.Message
{
    public interface IGrainMessage: IEntity
    {
        string RequesterSiloId { get; set; }
        string ResponseTaskCompletionSourceId { get; set; }
        Type GrainType { get; set; }
    }
}
