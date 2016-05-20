using System;
using System.ComponentModel.DataAnnotations;

namespace UniTunesApi.Models
{
    public class MediaModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int UserId { get; set; }

        //Optionals
        public TimeSpan Duration { get; set; }
        public string UrlFeed { get; set; }
        public int Quality { get; set; }
        public int Pages { get; set; }

    }
}