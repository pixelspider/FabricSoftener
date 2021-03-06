﻿using FabricSoftener.Entities.Data;
using FabricSoftener.Interfaces.GrainClient;
using System;

namespace FabricSoftener.Entities.Message
{
    [Serializable]
    public class GrainMessageResponseEntity: BaseEntity, IGrainMessage
    {
        public string RequesterSiloId { get; set; }
        public string ResponseTaskCompletionSourceId { get; set; }
        public Type GrainType { get; set; }
        public object Result { get; set; }
    }
}
