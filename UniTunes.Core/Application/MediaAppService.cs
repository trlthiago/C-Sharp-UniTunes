using System;
using System.Linq;
using System.Collections.Generic;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Domain.Service;
using UniTunes.Core.Infra.Database;

namespace UniTunes.Core.Application
{
    public class MediaAppService
    {
        private IDbContext _ctx;
        private MediaFactory _factory;
        public MediaAppService(IDbContext ctx)
        {
            _ctx = ctx;
            _factory = new MediaFactory();

        }

        public Media Get(int id)
        {
            return _ctx.Medias.Find(id);
        }

        public void Create(string name
                         , string description
                         , int authorId
                         , string imagepath
                         , decimal price
                         , int categoryId
                         , TimeSpan? duration = null
                         , string urlFeed = ""
                         , int quality = 0
                         , int pages = 0
                         , bool isAvailable = true)
        {
            var media = _factory.GetInstance(_ctx, name, description, authorId, imagepath, price, isAvailable, categoryId, duration, urlFeed, quality, pages);
            _ctx.Medias.Add(media);
            _ctx.SaveChanges();
        }

        public IEnumerable<Media> GetAll()
        {
            return _ctx.Medias.Where(x => !x.Deleted).ToList();
        }

        public void Remover(int mediaId)
        {
            var media =_ctx.Medias.Find(mediaId);
            _ctx.Medias.Remove(media);
            _ctx.SaveChanges();
        }

        public void Editar(int mediaId, string name, string description, decimal price)
        {
            var media = _ctx.Medias.Find(mediaId);

            media.Name = name;
            media.Price = price;
            media.Description = description;

            _ctx.SaveChanges();
        }

        public void Buy(int userId, int mediaId)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetPurchaseByDate(DateTime datetime)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetPurchaseByRange(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalRevanue()
        {
            throw new NotImplementedException();
        }
    }
}
