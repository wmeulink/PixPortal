using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
