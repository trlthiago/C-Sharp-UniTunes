using System;
using System.Collections.Generic;
using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Domain.Model
{
    public abstract class Media : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> Author { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public Category Category { get; set; }

        protected Media()
        {
            //EF
            Author = new List<User>();
        }
    }

    public abstract class Audible : Media
    {
        public TimeSpan Duration { get; set; }
    }

    public class Music : Audible
    {
    }

    public class PodCast : Audible
    {
        public string UrlFeed { get; set; }
    }

    public class Video : Audible
    {
        public int Quality { get; set; }
    }

    public class Book : Media
    {
        public int Pages { get; set; }
    }
}
