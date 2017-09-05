using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tearc.Utils.Common
{
    public static class ImageHelper
    {
    }

    public class Image
    {
        public const string DEFAULT_IMAGE_CONTENTTYPE = "image/png";

        [JsonIgnore]
        public readonly string DEFAULT_IMAGE_NAME = string.Format("{0}.png", Guid.NewGuid().ToString());
        public Image()
        {
            this.ImageName = DEFAULT_IMAGE_NAME;
            this.ContentType = DEFAULT_IMAGE_CONTENTTYPE;
        }
        public Image(long byteLength)
        {
            this.Content = new byte[byteLength];
            this.ImageName = DEFAULT_IMAGE_NAME;
            this.ContentType = DEFAULT_IMAGE_CONTENTTYPE;
        }
        public Image(long byteLength, string contentType)
        {
            this.Content = new byte[byteLength];
            this.ContentType = contentType;
            this.ImageName = DEFAULT_IMAGE_NAME;
        }
        public Image(long byteLength, string imageName, string contentType)
        {
            this.Content = new byte[byteLength];
            this.ImageName = imageName;
            this.ContentType = contentType;
        }
        public string ImageName { get; set; }

        [JsonIgnore]
        public string ContentType { get; set; }
        [JsonIgnore]
        public byte[] Content { get; set; }
    }
}
