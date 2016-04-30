using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Domain.Model
{
    public class Purchase : Entity
    {
        public User Buyer { get; private set; }
        public Media Media { get; private set; }
    }
}
