using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Photo
    {
        public Photo()
        {
            Gyms = new HashSet<Gym>();
            Users = new HashSet<User>();
        }

        public int PhotoId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<Gym> Gyms { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
