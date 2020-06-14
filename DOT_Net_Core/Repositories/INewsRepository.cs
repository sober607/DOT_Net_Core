using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_Net_Core.Models;

namespace Infestation.Repositories
{
    public interface INewsRepository
    {
        List<News> GetAllNews();

        List<News> GetNews(int newsId);

        List<News> GetAuthorNews(int authorId);

        void Create(News news);
    }
}
