using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Serializers;

namespace ALPOGalleryTool
{
    public class AttachmentPoco
    {
        public byte[] Data { get; set; }
        public string FileName { get; set; }
    }
}
