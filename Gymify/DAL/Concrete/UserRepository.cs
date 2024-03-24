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
    }
}
