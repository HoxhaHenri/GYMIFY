using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class User
    {
        public User()
        {
            Administrators = new HashSet<Administrator>();
            Coaches = new HashSet<Coach>();
            Complaints = new HashSet<Complaint>();
            FrontDesks = new HashSet<FrontDesk>();
            Managers = new HashSet<Manager>();
            Members = new HashSet<Member>();
            MessageReceivers = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
        }

        public int UserId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int ProfilePicture { get; set; }

        public virtual Photo ProfilePictureNavigation { get; set; } = null!;
        public virtual ICollection<Administrator> Administrators { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual ICollection<FrontDesk> FrontDesks { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Message> MessageReceivers { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
    }
}
