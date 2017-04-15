using FabricSoftener.Entities.Data;

namespace FabricSoftener.Entities.Message
{
    public interface IGrainMessage : IEntity
    {
        string RequesterSiloId { get; set; }
    }
}
