using System;
using System.IO;
using System.Text;

namespace Essa.Framework.Util.Util;

public static class UtilStream
{

    public static string ToString(Stream stream)
    {
        if (stream == null)
            throw new ArgumentNullException(nameof(stream));

        if (stream.CanSeek)
            stream.Position = 0;

        using var reader = new StreamReader(stream, Encoding.UTF8, true, leaveOpen: true);
        return reader.ReadToEnd();
    }

}
