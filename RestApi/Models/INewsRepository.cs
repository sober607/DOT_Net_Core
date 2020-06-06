using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Models;

namespace RestApi.Models
{
    public interface INewsRepository
    {
        IEnumerable<News> GetAllNews();

        void CreateNews(News news);

        void DeleteNews(int id);

        void ChangeNews(News news);

        void ChangePartialNews(int id, News news);
    }
}
