using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Azure.Image.Resizer.Functions
{
    public class ImageResizer
    {
        private readonly IImageResizerManager _resizerManager;

        public ImageResizer(IImageResizerManager resizerManager)
        {
            _resizerManager = resizerManager;
        }

        [FunctionName("ImageResizer")]
        public void Run([BlobTrigger("images/{name}", Connection = "")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
