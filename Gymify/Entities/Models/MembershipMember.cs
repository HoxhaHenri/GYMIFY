using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class MembershipMember
    {
        public int UserId { get; set; }
        public int MembershipId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Member User { get; set; } = null!;
    }
}
