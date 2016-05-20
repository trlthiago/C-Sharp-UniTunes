using System.Collections.Generic;
using System.Web.Http;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra.Database;
using UniTunesApi.Models;

namespace UniTunesApi.Controllers
{
    public class UsersController : ApiController
    {
        UniTunes.Core.Application.UserAppService _app;

        public UsersController()
        {
            var ctx = new DataContext();
            _app = new UniTunes.Core.Application.UserAppService(ctx);
        }

        // GET /Users/5
        public IHttpActionResult Get(int id)
        {
            var user = _app.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(new UserModel
            {
                Name = user.Name,
                Email = user.Email,
                IsAdministrator = user.IsAdministrator,
                Status = user.Status
            });
        }

        public void Post(UserModel model)
        {
            _app.Create(model.Name, model.Email, model.Password);
        }

        // PUT /Users/5
        public void Put(int id, UserModel model)
        {
            _app.Edit(id, model.Name, model.Email);
        }

        // DELETE /Users/5
        public void Delete(int id)
        {
            _app.Delete(id);
        }

        [HttpGet]
        // GET /Users/1/Medias
        public IEnumerable<Media> Medias(int id)
        {
            return _app.GetMedias(id);
        }
    }
}