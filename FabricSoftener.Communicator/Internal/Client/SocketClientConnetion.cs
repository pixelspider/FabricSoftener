using System.Threading.Tasks;
using FabricSoftener.Communicator.Internal.Interfaces;
using WebSocketSharp;

namespace FabricSoftener.Communicator.Internal.Client
{
    internal class SocketClientConnetion : ISocketClientConnetion
    {
        private WebSocket _webSocketClient;
        private TaskCompletionSource<byte[]> _taskCompletionSource;
        private delegate void AsyncMethodCaller(byte[] messageData);

        public SocketClientConnetion(WebSocket webSocketClient)
        {
            _webSocketClient = webSocketClient;
            _webSocketClient.Connect();
            _webSocketClient.OnMessage += MessageRecieved;
            _webSocketClient.OnError += ErrorRecieved;
        }
 
        public Task<byte[]> SendMessageAsync(byte[] messageData)
        {
            _taskCompletionSource = new TaskCompletionSource<byte[]>();
            var caller = new AsyncMethodCaller(WebSocketClientSendAsync);
            caller.BeginInvoke(messageData, null, null);
            return _taskCompletionSource.Task;
        }

        private void WebSocketClientSendAsync(byte[] messageData)
        {
            _webSocketClient.SendAsync(messageData, OnCompletion);
        }

        private void OnCompletion(bool obj)
        {

        }
        private void MessageRecieved(object sender, MessageEventArgs args)
        {
            _taskCompletionSource.SetResult(args.RawData);
            _webSocketClient.Close();
        }
        private void ErrorRecieved(object sender, ErrorEventArgs args)
        {

        }
    }
}
