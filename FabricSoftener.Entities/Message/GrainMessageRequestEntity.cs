using System;
using FabricSoftener.Entities.Data;
using FabricSoftener.Interfaces.GrainClient;
using FabricSoftener.Entities.Configuration;

namespace FabricSoftener.Entities.Message
{
    [Serializable]
    public class GrainMessageRequestEntity : BaseEntity, IGrainMessage
    {
        private string _requesterSiloId;
        public string RequesterSiloId
        {
            get
            {
                if (_requesterSiloId == null)
                    _requesterSiloId = DataConfig.SiloID;
                return _requesterSiloId;
            }
            set
            {
                _requesterSiloId = value;
            }
        }
        public string DestinationSiloId { get; set; }
        public string DestinationSiloEndpoint { get; set; }
        public bool IsSameSilo => RequesterSiloId == DestinationSiloId;
        public bool DoesGrainExist { get; set; }
        public string ResponseTaskCompletionSourceId { get; set; }
        public Type GrainType { get; set; }
        public string MethodName { get; set; }
        public object[] Arguments { get; set; }
    }
}
