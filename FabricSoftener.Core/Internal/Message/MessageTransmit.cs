using System;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Entities.Message;
using FabricSoftener.Interfaces.GrainClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using FabricSoftener.Entities.Configuration;

namespace FabricSoftener.Core.Internal.Message
{
    internal class MessageTransmit : IMessageTransmit
    {
        private static Dictionary<string, TaskCompletionSource<object>> TaskCompletionSources => _taskCompletionSources ?? (_taskCompletionSources = new Dictionary<string, TaskCompletionSource<object>>());
        private static Dictionary<string, TaskCompletionSource<object>> _taskCompletionSources;

        public TaskCompletionSource<object> TransmitRequestAsync<TGrain>(GrainMessageRequestEntity<TGrain> message) where TGrain : IGrain
        {
            TaskCompletionSource<object> taskCompletionSource = null;
            if (message.RequesterSiloId == DataConfig.SiloID)
            {
                var taskCompletionSourceId = Guid.NewGuid().ToString();
                taskCompletionSource = new TaskCompletionSource<object>();
                TaskCompletionSources.Add(taskCompletionSourceId, taskCompletionSource);
                message.ResponseTaskCompletionSourceId = taskCompletionSourceId;
            }

            // Transmit request Message local or across server

            return taskCompletionSource;
        }

        public void TransmitResponseAsync<TGrain>(GrainMessageResponseEntity<TGrain> message) where TGrain : IGrain
        {
            if(TaskCompletionSources.ContainsKey(message.ResponseTaskCompletionSourceId))
            {
                TaskCompletionSources[message.ResponseTaskCompletionSourceId].SetResult(message);
            }
            else
            {
                // Transmit response Message across server then recall TransmitResponseAsync
            }
        }
    }
}
