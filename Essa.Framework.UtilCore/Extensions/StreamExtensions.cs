using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Essa.Framework.Util.Extensions;

public static class StreamExtensions
{
    public static Stream ResizeImage(
      this Stream inputStream,
      int width,
      int height,
      ImageFormat? imageFormat = null)
    {
        if (inputStream == null)
            throw new ArgumentNullException(nameof(inputStream));

        if (!inputStream.CanRead)
            throw new InvalidOperationException("Stream não pode ser lido.");

        imageFormat ??= ImageFormat.Jpeg;

        inputStream.Position = 0;

        using var originalImage = Image.FromStream(inputStream);

        var ratioX = (double)width / originalImage.Width;
        var ratioY = (double)height / originalImage.Height;
        var ratio = Math.Min(ratioX, ratioY);

        var newWidth = (int)(originalImage.Width * ratio);
        var newHeight = (int)(originalImage.Height * ratio);

        var destRect = new Rectangle(0, 0, newWidth, newHeight);
        var destImage = new Bitmap(newWidth, newHeight);

        destImage.SetResolution(
            originalImage.HorizontalResolution,
            originalImage.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using var wrapMode = new ImageAttributes();
            wrapMode.SetWrapMode(WrapMode.TileFlipXY);

            graphics.DrawImage(
                originalImage,
                destRect,
                0,
                0,
                originalImage.Width,
                originalImage.Height,
                GraphicsUnit.Pixel,
                wrapMode);
        }

        var outputStream = new MemoryStream();
        destImage.Save(outputStream, imageFormat);
        outputStream.Position = 0;

        return outputStream;
    }
}