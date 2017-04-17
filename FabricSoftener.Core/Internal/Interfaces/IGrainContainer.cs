using FabricSoftener.Entities.Message;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IGrainContainer
    {
        bool IsBusy { get; }
        void ProcessMessage(GrainMessageRequestEntity message);
    }
}
