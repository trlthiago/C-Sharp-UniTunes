using System.Collections.Generic;
using System.Linq;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra.Database;

namespace UniTunes.Core.Application
{
    public class CategoryAppService
    {
        private IDbContext _ctx;

        public CategoryAppService(IDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Category> Get()
        {
            return _ctx.Categories.Where(x => !x.Deleted).ToList();
        }

        public void Create(string name)
        {
            _ctx.Categories.Add(new Category(name));
            _ctx.SaveChanges();
        }

        public void Remove(int id)
        {
            var category = _ctx.Categories.Find(id);
            category.Deleted = true;
            _ctx.SaveChanges();
        }
    }
}
