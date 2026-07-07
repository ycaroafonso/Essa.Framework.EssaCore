using System;

namespace Essa.Framework.Util.Extensions;

public static class DateTimeOffsetExtension
{
    public static int ToAnoMes(this DateTimeOffset data)
    {
        return data.Year * 100 + data.Month;
    }
}
