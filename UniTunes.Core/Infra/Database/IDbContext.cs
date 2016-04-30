using System;
using System.Data.Entity;
using System.Linq;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Infra.Database
{
    public interface IDbContext : IDisposable, IORM
    {
        DbSet<User> Users { get; set; }        
        DbSet<Category> Categories { get; set; }
        DbSet<Wallet> Wallets { get; set; }
        DbSet<BookMarkList> BookMarkLists { get; set; }
        DbSet<Media> Medias { get; set; }
        DbSet<Album> Albums { get; set; }
    }

    public interface IORM
    {
        int SaveChanges();

        System.Threading.Tasks.Task<int> SaveChangesAsync();

        void Add<T>(T entity) where T : Entity;

        IQueryable<T> Get<T>() where T : Entity;
    }
}
