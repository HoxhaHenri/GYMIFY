using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            Gyms = new HashSet<Gym>();
        }

        public int UserId { get; set; }
        public string Role { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Gym> Gyms { get; set; }
    }
}
