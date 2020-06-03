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

        public IEnumerable<News> GetAllNews()
        {
            return _context.News.ToList();
        }
    }
}
