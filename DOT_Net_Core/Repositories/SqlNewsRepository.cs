using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_Net_Core.Models;

namespace Infestation.Repositories
{
    public class SqlNewsRepository : INewsRepository
    {
        private DOT_Net_CoreContext _context { get; set; }

        public SqlNewsRepository (DOT_Net_CoreContext context)

        {
            _context = context;
        }

        public List<News> GetAllNews()
        {
            return _context.News.ToList();
        }

        public List<News> GetNews(int newsId)
        {
            return (new List<News> { _context.News.FirstOrDefault(news => news.Id == newsId) });
        }

        public List<News> GetAuthorNews(int authorId)
        {
            List<News> authorNews = _context.News.Where(news => news.AuthorId == authorId).ToList();

            return authorNews;
        }

        public void Create(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }
    }
}
