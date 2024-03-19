using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Member
    {
        public Member()
        {
            MemberRatings = new HashSet<MemberRating>();
            MembershipMembers = new HashSet<MembershipMember>();
            Courses = new HashSet<Course>();
        }

        public int UserId { get; set; }
        public string Role { get; set; } = null!;
        public int Points { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<MemberRating> MemberRatings { get; set; }
        public virtual ICollection<MembershipMember> MembershipMembers { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
