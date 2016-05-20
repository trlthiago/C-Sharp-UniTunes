using System.Collections.Generic;
using System.Web.Http;
using UniTunes.Core.Application;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra.Database;
using UniTunesApi.Models;

namespace UniTunesApi.Controllers
{
    public class MediasController : ApiController
    {
        private MediaAppService _app;

        public MediasController()
        {
            var ctx = new DataContext();
            _app = new MediaAppService(ctx);
        }

        // GET: /Medias
        public IEnumerable<Media> Get()
        {
            return _app.GetAll();
        }

        // GET: /Medias/5
        public Media Get(int id)
        {
            return _app.Get(id);
        }

        // POST: /Medias
        public void Post(MediaModel model)
        {
            _app.Create(model.Name, model.Description, model.UserId, model.ImagePath, model.Price, model.CategoryId, model.Duration, model.UrlFeed, model.Quality, model.Pages);
        }

        // PUT: /Medias/5
        public void Put(int id, MediaModel model)
        {
            _app.Editar(id, model.Name, model.Description, model.Price);
        }

        // DELETE: /Medias/5
        public void Delete(int id)
        {
            _app.Remover(id);
        }
    }
}
