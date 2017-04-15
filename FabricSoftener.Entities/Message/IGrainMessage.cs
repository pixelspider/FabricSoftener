using FabricSoftener.Entities.Data;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Entities.Message
{
    public interface IGrainMessage: IEntity
    {
        string RequesterSiloId { get; set; }
    }
}
