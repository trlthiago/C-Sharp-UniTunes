using System.Data.Entity;
using System.Linq;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Infra.Database
{
    public class DataContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<BookMarkList> BookMarkLists { get; set; }
        public DbSet<Album> Albums { get; set; }

        public void Add<T>(T entity) where T : Entity
        {
            Entry(entity).State = (entity.Id == 0) ? EntityState.Added : EntityState.Modified;
        }

        public IQueryable<T> Get<T>() where T : Entity
        {
            return Set<T>();
        }
    }
}
