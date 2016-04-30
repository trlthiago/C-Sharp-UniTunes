using System;
using System.Linq;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra.Database;

namespace UniTunes.Core.Application
{
    public class UserAppService
    {
        private IDbContext _ctx;
        public UserAppService(IDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(string name, string email, string password)
        {
            

            //_ctx.Users.Add(new User
            //{
            //    Email = email,
            //    Name = name,
            //    Password = password, //TODO: MAKE A HASH
            //    Status = UserStatus.Active
            //});
 
            //TODO: USAR CTOR e setar o status dentro.

            _ctx.SaveChanges();
        }

        public User GetUserByCredentials(string email, string password)
        {
            var securePassword = password; //TODO: MAKE A HASH

            var user = _ctx.Users.FirstOrDefault(x => x.Email == email && password == securePassword);

            if (user == null)
                throw new Exception("User not found");
            else if (user.Status == UserStatus.Deactivated)
                throw new Exception("User disabled");

            return user;
        }
    }
}
