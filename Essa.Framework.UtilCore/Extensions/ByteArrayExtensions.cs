namespace Essa.Framework.UtilCore.Extensions
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;


    public static class ByteArrayExtensions
    {
        public static T ToObject<T>(this byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
    }
}
