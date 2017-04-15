using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FabricSoftener.Communicator.Internal.Extensions
{
    public static class SerialiserDeserialiserExtensions
    {
        public static byte[] Serialiser(this object _object)
        {
            byte[] bytes;
            using (var _MemoryStream = new MemoryStream())
            {
                IFormatter _BinaryFormatter = new BinaryFormatter();
                _BinaryFormatter.Serialize(_MemoryStream, _object);
                bytes = _MemoryStream.ToArray();
            }
            return bytes;
        }

        public static T Deserialiser<T>(this byte[] _byteArray)
        {
            T ReturnValue;
            using (var _MemoryStream = new MemoryStream(_byteArray))
            {
                IFormatter _BinaryFormatter = new BinaryFormatter();
                ReturnValue = (T)_BinaryFormatter.Deserialize(_MemoryStream);
            }
            return ReturnValue;
        }

    }
}
