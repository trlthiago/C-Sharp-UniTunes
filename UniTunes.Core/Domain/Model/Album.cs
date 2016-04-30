using System.Collections.Generic;
using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Domain.Model
{
    public class Album : Entity
    {
        public string Name { get; private set; }
        public List<Media> Medias { get; private set; }
    }
}
