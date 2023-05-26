namespace Essa.Framework.Util.Extensions
{
    using System;


    public static class ByteArrayExtensions
    {
        public static string ToBase64(this byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        //public static Stream ToStream(this byte[] file)
        //{
        //    MemoryStream theMemStream = new MemoryStream();

        //    theMemStream.Write(file, 0, file.Length);

        //    return theMemStream;
        //}
    }
}
