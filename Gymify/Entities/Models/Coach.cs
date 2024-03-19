using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Coach
    {
        public Coach()
        {
            CoachContracts = new HashSet<CoachContract>();
            Courses = new HashSet<Course>();
            EquipmentRequests = new HashSet<EquipmentRequest>();
        }

        public int UserId { get; set; }
        public string Role { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<CoachContract> CoachContracts { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<EquipmentRequest> EquipmentRequests { get; set; }
    }
}
