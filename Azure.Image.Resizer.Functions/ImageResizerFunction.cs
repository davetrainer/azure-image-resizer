using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Azure.Image.Resizer.Functions
{
    public class ImageResizerFunction
    {
        private readonly IImageResizerManager _resizerManager;

        public ImageResizerFunction(IImageResizerManager resizerManager)
        {
            _resizerManager = resizerManager;
        }

        [FunctionName("ImageResizerFunction")]
        public void Run([BlobTrigger("images/{name}", Connection = "")]Stream myBlob,
            [Blob("images-sm/{name}", FileAccess.Write)] Stream imageSmall, string name, ILogger log)
        {
            _resizerManager.ResizeImage(myBlob, imageSmall);
        }
    }
}
