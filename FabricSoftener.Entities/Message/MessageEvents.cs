namespace FabricSoftener.Entities.Message
{
    public class MessageEvents
    {
        public delegate void MessageEventHandler(IGrainMessage message);
        public delegate void MessageCompleteEventHandler();
    }
}
