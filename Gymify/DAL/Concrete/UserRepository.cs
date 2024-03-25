using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(GymifyContext dbContext) : base(dbContext)
        {

        }
        public override User GetById(Guid id)
        {
            var user = context.Where(x => x.GuidIdentifier == id).FirstOrDefault();
            return user;
        }
        public override void Remove(User entity)
        {
            context.Attach(entity);
            entity.Status = "Deleted";
        }
        public User GetUserByUsername(string username)
        {
            return context.Where(x => x.Username.Equals(username)).FirstOrDefault();
        }
        public string GetPassword(Guid id)
        {
            return context.Find(id).Password;
        }
    }
}
