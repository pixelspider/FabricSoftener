using System;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Entities.Message;
using System.Threading.Tasks;
using System.Collections.Generic;
using FabricSoftener.Core.Internal.GrainClient;
using FabricSoftener.Entities.Configuration;

namespace FabricSoftener.Core.Internal.Message
{
    internal class MessageTransmit : IMessageTransmit
    {
        private static Dictionary<string, TaskCompletionSource<object>> TaskCompletionSources => _taskCompletionSources ?? (_taskCompletionSources = new Dictionary<string, TaskCompletionSource<object>>());
        private static Dictionary<string, TaskCompletionSource<object>> _taskCompletionSources;

        public TaskCompletionSource<object> TransmitRequestFromProxyAsync(GrainMessageRequestEntity message)
        {
            var taskCompletionSourceId = Guid.NewGuid().ToString();
            var taskCompletionSource = new TaskCompletionSource<object>();
            TaskCompletionSources.Add(taskCompletionSourceId, taskCompletionSource);
            message.ResponseTaskCompletionSourceId = taskCompletionSourceId;

            //  find location of grain and set on request message   [  message.DestinationSiloId / message.DoesGrainExist / message.DestinationSiloEndpoint  ]

            TransmitRequestAsync(message);

            return taskCompletionSource;
        }

        public void TransmitRequestAsync(GrainMessageRequestEntity message)
        {
            if(message.DestinationSiloId == DataConfig.SiloID)
            {
                if(!message.DoesGrainExist)
                {
                    IGrainContainer container = (IGrainContainer)Activator.CreateInstance(typeof(GrainContainer<>).MakeGenericType(message.GrainType));
                    container.ProcessMessage(message);
                }
                else
                {
                    //  find local grain
                }
            }
            else
            {
                // Transmit request Message across server then call TransmitRequestAsync   [  GrainRequestSocketController  ]
            }
        }

        public void TransmitResponseAsync(GrainMessageResponseEntity message)
        {
            if(TaskCompletionSources.ContainsKey(message.ResponseTaskCompletionSourceId))
            {
                TransmitResponseToProxyAsync(message);
            }
            else
            {
                // Transmit response Message across server then call TransmitResponseCurrentSiloAsync   [  GrainResponseSocketController  ]
            }
        }

        public void TransmitResponseToProxyAsync(GrainMessageResponseEntity message)
        {
            TaskCompletionSources[message.ResponseTaskCompletionSourceId].SetResult(message.Result);
        }
    }
}
