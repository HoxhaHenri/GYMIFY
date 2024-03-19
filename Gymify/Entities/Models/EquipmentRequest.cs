using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class EquipmentRequest
    {
        public int EquipmentId { get; set; }
        public int CoachId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime TimeCreated { get; set; }
        public string Type { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual Coach Coach { get; set; } = null!;
        public virtual Equipment Equipment { get; set; } = null!;
    }
}
