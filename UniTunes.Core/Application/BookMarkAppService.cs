using System.Collections.Generic;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra.Database;
using System.Linq;

namespace UniTunes.Core.Application
{
    public class BookMarkAppService
    {
        private IDbContext _ctx;
        public BookMarkAppService(IDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<BookMarkList> Get(int userId)
        {
            return _ctx.BookMarkLists.Where(x => !x.Deleted).ToList();
        }

        public void Create(int userId, string name)
        {
            var user = _ctx.Users.Find(userId);
            _ctx.BookMarkLists.Add(new BookMarkList(name, user));
            _ctx.SaveChanges();
        }

        public void Remove(int bookMarkListId)
        {
            var bookMarkList = _ctx.BookMarkLists.Find(bookMarkListId);
            foreach (var item in bookMarkList.Items)
            {
                item.Deleted = true;
            }
            bookMarkList.Deleted = true;
            _ctx.SaveChanges();
        }

        public void Edit(int bookMarkListId, string newName)
        {
            throw new System.NotImplementedException();
        }

        public void AddItem(int bookMarkListId, int mediaId)
        {
            var b = _ctx.BookMarkLists.Find(bookMarkListId);
            var i = _ctx.Medias.Find(mediaId);
            b.Items.Add(i);
            _ctx.SaveChanges();
        }

        public void RemoveItem(int bookMarkListId, int mediaId)
        {
            throw new System.NotImplementedException();
        }
    }
}
