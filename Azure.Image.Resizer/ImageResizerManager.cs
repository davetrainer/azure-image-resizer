using ImageMagick;

namespace Azure.Image.Resizer
{
    public class ImageResizerManager : IImageResizerManager
    {
        public ImageResizerManager() { }

        public void ResizeImage(Stream inputStream, Stream outputStream)
        {
            using MagickImage? image = new(inputStream);
            image.Resize(100, 100);
            image.Write(outputStream);
        }
    }
}