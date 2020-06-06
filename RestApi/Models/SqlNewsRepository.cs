using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Models;


namespace RestApi.Models
{
    public class SqlNewsRepository : INewsRepository
    {
        public List<News> News = new List<News>
        {
            new News { Id = 0, Title = "Humanity finally colonized the Mercury!!", Text = "", AuthorName = "Jeremy Clarkson", IsFake = true},
            new News { Id = 1, Title = "Increase your lifespan by 10 years, every morning you need...", Text = "", AuthorName = "Svetlana Sokolova", IsFake = true},
            new News { Id = 2, Title = "Scientists estimed the time of the vaccine invension: it is a summer of 2021", Text = "", AuthorName = "John Jones", IsFake = false},
            new News { Id = 3, Title = "Ukraine reduces the cost of its obligations!", Text = "", AuthorName = "Cerol Denvers", IsFake = false},
            new News { Id = 4, Title = "A species were discovered in Africa: it is blue legless cat", Text = "", AuthorName = "Jimmy Felon", IsFake = true}

        };



        public IEnumerable<News> GetAllNews()
        {
            return News;

             
        }

        public void CreateNews(News news)
        {
            News.Add(news);
        }

        public void DeleteNews(int id)
        {
            News.Remove(News.SingleOrDefault(t => t.Id == id));
        }

        public void ChangeNews(News news)
        {
            int changedNews = News.IndexOf(News.SingleOrDefault(t => t.Id == news.Id));
            News[changedNews].Id = news.Id;
            News[changedNews].Title = news.Title;
            News[changedNews].Text = news.Text;
            News[changedNews].AuthorName = news.AuthorName;
            News[changedNews].IsFake = news.IsFake;

        }

        public void ChangePartialNews(int id, News news)
        {
            int changedNewsIndex = News.IndexOf(News.SingleOrDefault(t => t.Id == id));
            if(news.Title!=null)
            News[changedNewsIndex].Title = news.Title; 
            if (news.Text != null)
            News[changedNewsIndex].Text = news.Text;
            if (news.AuthorName != null)
                News[changedNewsIndex].AuthorName = news.AuthorName;
            if (news.IsFake != null)
                News[changedNewsIndex].IsFake = news.IsFake;




        }
    }
}
