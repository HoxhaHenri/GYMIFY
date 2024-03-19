using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Video
    {
        public int VideoId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
