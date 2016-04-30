using System;

namespace UniTunes.Core.Domain.Shared
{
    public abstract class Entity
    {
        public Entity()
        {
            CreationDate = DateTime.Now;
        }

        public int Id { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public bool Deleted { get; set; }


    }
    //public abstract class SoftDeleteEntity : Entity
    //{
    //    public bool Deleted { get; set; }
    //}
}
