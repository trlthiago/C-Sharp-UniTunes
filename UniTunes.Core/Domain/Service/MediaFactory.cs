using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra.Database;

namespace UniTunes.Core.Domain.Service
{
    public class MediaFactory
    {
        public Media GetInstance(IDbContext ctx
                                , string name
                                , string description
                                , int authorId
                                , string imagepath
                                , decimal price
                                , bool isAvailable
                                , int categoryId
                                , TimeSpan? duration = null
                                , string urlFeed = ""
                                , int quality = 0
                                , int pages = 0)
        {
            Media media = null;
            if (duration.HasValue && string.IsNullOrWhiteSpace(urlFeed))
            {
                media = new Music { Duration = duration.Value };
            }
            else if (duration.HasValue && !string.IsNullOrWhiteSpace(urlFeed))
            {
                media = new PodCast { Duration = duration.Value, UrlFeed = urlFeed };
            }
            else if (pages != 0)
            {
                media = new Book { Pages = pages };
            }
            else if (quality != 0)
            {
                media = new Video { Quality = quality };
            }
            else
            {
                throw new Exception("Invalid media type.");
            }

            media.Name = name;
            media.Description = description;
            media.ImagePath = imagepath;
            media.Price = price;
            media.IsAvailable = isAvailable;
            media.Category = ctx.Categories.Find(categoryId);
            media.Author.Add(ctx.Users.Find(authorId));

            return media;
        }
    }
}
