using System;
using System.Collections.Generic;
using System.Linq;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra;
using UniTunes.Core.Infra.Database;

namespace UniTunes.Core.Application
{
    public class UserAppService
    {
        private IDbContext _ctx;
        private ICrypto _cryto;
        public UserAppService(IDbContext ctx)
        {
            _ctx = ctx;
            _cryto = new UnisinosCrypt();
        }

        public void Create(string name, string email, string password)
        {
            _ctx.Users.Add(new User(name, email, _cryto.Encrypt(password)));
            _ctx.SaveChanges();
        }

        public User GetById(int id)
        {
            return _ctx.Users.Find(id);
        }

        public User GetUserByCredentials(string email, string password)
        {
            var securePassword = _cryto.Encrypt(password);

            var user = _ctx.Users.FirstOrDefault(x => x.Email == email && password == securePassword);

            if (user == null)
                throw new Exception("User not found");
            else if (user.Status == UserStatus.Deactivated)
                throw new Exception("User disabled");

            return user;
        }

        public void Edit(int id, string name, string email)
        {
            var user = _ctx.Users.Find(id);
            user.Name = name;
            user.Email = email;
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _ctx.Users.Find(id);
            user.Deactivate();
            _ctx.SaveChanges();
        }

        public List<Media> GetMedias(int userId)
        {
            return _ctx.Users.Find(userId)?.Purchases.Select(x => x.Media).ToList() ?? new List<Media>();
        }
    }
}
