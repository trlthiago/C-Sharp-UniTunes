using System;
using System.Collections.Generic;
using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Domain.Model
{
    public abstract class Media : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<User> Author { get; private set; }
        public string ImagePath { get; private set; }
        public decimal Price { get; private set; }
        public bool IsAvailable { get; private set; }
        public Category Category { get; private set; }
    }

    public abstract class Audible : Media
    {
        public TimeSpan Duration { get; private set; }
    }

    public class Music : Audible
    {
    }

    public class PodCast : Audible
    {
        public string UrlFeed { get; private set; }
    }

    public class Video : Audible
    {
        public int Quality { get; private set; }
    }

    public class Book : Media
    {
        public int Pages { get; private set; }
    }
}
