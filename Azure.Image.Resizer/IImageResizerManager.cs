namespace Azure.Image.Resizer
{
    public interface IImageResizerManager
    {
        public void ResizeImage(Stream inputStream, Stream outputStream);
    }
}
