using System.Collections.Generic;
using System.Linq;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra.Database;

namespace UniTunes.Core.Application
{
    public class AlbumAppService
    {
        private IDbContext _ctx;
        public AlbumAppService(IDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Album> GetAllAlbums()
        {
            return _ctx.Albums.Where(x => !x.Deleted).OrderByDescending(x => x.CreationDate).ToList();
        }

        public List<Album> GetNewstAlbums()
        {
            throw new System.NotImplementedException();
        }

        public List<Album> GetRecentAlbums()
        {
            throw new System.NotImplementedException();
        }
    }
}
