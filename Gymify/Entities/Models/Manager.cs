using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Manager
    {
        public int UserId { get; set; }
        public string Role { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual Gym Gym { get; set; } = null!;
    }
}
