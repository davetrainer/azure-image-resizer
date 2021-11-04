using Azure.Image.Resizer.Functions;
using Azure.Image.Resizer.Tests.Properties;
using ImageMagick;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.IO;
using Xunit;

namespace Azure.Image.Resizer.Tests.Integration
{
    public class ImageResizerFunctionIntegrationTests
    {
        private readonly ILogger _logger = Substitute.For<ILogger>();

        [Fact]
        public void RunFunctionWithTestImage()
        {

            MemoryStream? imageStream = new(Resources.TestImage);
            MemoryStream? outStream = new();

            var function = new ImageResizerFunction(new ImageResizerManager());
            function.Run(imageStream, outStream, "test", _logger);

            outStream.Position = 0;
            MagickImage? outputImage = new(outStream);

            Assert.Equal(100, outputImage.Width);
        }
    }
}