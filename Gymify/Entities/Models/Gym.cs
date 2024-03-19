using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Gym
    {
        public Gym()
        {
            CoachContracts = new HashSet<CoachContract>();
            Complaints = new HashSet<Complaint>();
            Courses = new HashSet<Course>();
            Equipment = new HashSet<Equipment>();
            FrontDesks = new HashSet<FrontDesk>();
            MemberRatings = new HashSet<MemberRating>();
            Memberships = new HashSet<Membership>();
        }

        public int GymId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Capacity { get; set; }
        public int Logo { get; set; }
        public int ManagerId { get; set; }
        public int AdministratorId { get; set; }

        public virtual Administrator Administrator { get; set; } = null!;
        public virtual Photo LogoNavigation { get; set; } = null!;
        public virtual Manager Manager { get; set; } = null!;
        public virtual ICollection<CoachContract> CoachContracts { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<FrontDesk> FrontDesks { get; set; }
        public virtual ICollection<MemberRating> MemberRatings { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
