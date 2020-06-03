using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_Net_Core.Models
{
    public static class NewsBase
    {
        public static List<News> News = new List<News>
        {
            new News { Id = 0, Title = "Humanity finally colonized the Mercury!!", Text = "", AuthorId = 3, IsFake = true},
            new News { Id = 1, Title = "Increase your lifespan by 10 years, every morning you need...", Text = "", AuthorId = 4, IsFake = true},
            new News { Id = 2, Title = "Scientists estimed the time of the vaccine invension: it is a summer of 2021", Text = "", AuthorId = 5, IsFake = false},
            new News { Id = 3, Title = "Ukraine reduces the cost of its obligations!", Text = "", AuthorId = 6, IsFake = false},
            new News { Id = 4, Title = "A species were discovered in Africa: it is blue legless cat", Text = "", AuthorId = 7, IsFake = true}
        };
    }
}
