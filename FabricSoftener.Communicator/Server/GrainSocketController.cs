using System;
using FabricSoftener.Communicator.Internal.Server;

namespace FabricSoftener.Communicator.Server
{
    public class GrainSocketController : BaseSocketController
    {
        public override void Request(byte[] messageData)
        {
            //throw new NotImplementedException();
            //System.Threading.Thread.Sleep(60);
            if(messageData.Length > 30)
                base.Response(messageData);
        }
    }
}
