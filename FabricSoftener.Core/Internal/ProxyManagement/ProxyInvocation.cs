using DynamicProxy;
using FabricSoftener.Communicator.Client;
using FabricSoftener.Communicator.Internal.Server;
using FabricSoftener.Communicator.Server;
using FabricSoftener.Core.Internal.AssemblyManagement;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Core.Internal.Message;
using FabricSoftener.Entities.Message;
using FabricSoftener.Interfaces.GrainClient;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace FabricSoftener.Core.Internal.ProxyManagement
{
    internal class ProxyInvocation : IProxyInvocation
    {
        private TaskCompletionSource<object> _taskCompletionSource;
        public async Task<object> Invocate<TGrain>(Invocation args) where TGrain : IGrain
        {

            var server = new SocketServer("ws://localhost:1234");
            server.AddSocketService("/grain", new GrainSocketController());
            server.Start();


            var client = new SocketClient();
            var d = await client.SendMessageAsync<string, string>("ws://localhost:1234/grain", "Hello");









            _taskCompletionSource = new TaskCompletionSource<object>();

            var message = new GrainMessageRequestEntity<TGrain>
            {
                MethodName = args.Method.Name,
                Arguments = args.Arguments
            };

            var messageTransmit = new MessageTransmit<TGrain>();
            messageTransmit.TransmitRequest(message);

            Test<TGrain>(args);

            return await _taskCompletionSource.Task;

            //return await TransmitMessage(message);
        }

        private void MessageReponseEvent(object response)
        {
            _taskCompletionSource.SetResult(response);
        }

        private async void Test<TGrain>(Invocation args) where TGrain : IGrain
        {
            var assemblyRepository = new AssemblyRepository();
            var grainType = assemblyRepository.GetActualType<TGrain>();
            if (grainType == null)
                MessageReponseEvent(null);
            var grain = (IGrain)Activator.CreateInstance(grainType);
            //var f = await(dynamic)grain.GetType().GetTypeInfo().GetDeclaredMethod(args.Method.Name).Invoke(grain, args.Arguments);
            MessageReponseEvent(grain.GetType().GetTypeInfo().GetDeclaredMethod(args.Method.Name).Invoke(grain, args.Arguments));
        }
    }
}
