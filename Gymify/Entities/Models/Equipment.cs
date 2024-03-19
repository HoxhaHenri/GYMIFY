using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentRequests = new HashSet<EquipmentRequest>();
            Exercises = new HashSet<Exercise>();
        }

        public int EquipmentId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Availability { get; set; } = null!;
        public int EquipmentCount { get; set; }
        public int GymId { get; set; }

        public virtual Gym Gym { get; set; } = null!;
        public virtual ICollection<EquipmentRequest> EquipmentRequests { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
