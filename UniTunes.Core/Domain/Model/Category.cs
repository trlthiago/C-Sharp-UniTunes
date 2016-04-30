using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Domain.Model
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        protected Category()
        {

        }

        public Category(string name)
        {
            Name = name;
        }
    }
}
