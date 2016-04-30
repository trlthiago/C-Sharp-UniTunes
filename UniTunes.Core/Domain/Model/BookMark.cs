using System.Collections.Generic;
using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Domain.Model
{
    public class BookMarkList : Entity
    {
        public string Name { get; private set; }
        public User Owner { get; private set; }
        public List<Media> Items { get; private set; }

        protected BookMarkList()
        {

        }

        public BookMarkList(string name, User user)
        {
            Name = name;
            Owner = user;

            if (Items == null)
                Items = new List<Media>();
        }
    }
}
