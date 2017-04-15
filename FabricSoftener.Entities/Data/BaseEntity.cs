using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FabricSoftener.Entities.Data
{
    public abstract class BaseEntity : IEntity
    {
        private string _id;

        [BsonId]
        public string Id
        {
            get
            {
                if(string.IsNullOrEmpty(_id))
                {
                    _id = Guid.NewGuid().ToString();
                }
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }
}
