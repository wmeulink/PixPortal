using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public int UserId { get; set; }
    }
}
