namespace FabricSoftener.Entities.Data
{
    public class SiloClusterEntity : BaseEntity
    {
        private GrainEntity[] _grains;
        public string ClusterName { get; set; }
        public bool MarkToUnregister { get; set; }
        public string HostName { get; set; }
        public int HostPort { get; set; }
        public string HostEndPoint => $"{HostName}:{HostPort}";
        public GrainEntity[] Grains
        {
            get
            {
                return _grains ?? (_grains = new GrainEntity[] { });
            }
            set
            {
                _grains = value;
            }
        }
    }
}
