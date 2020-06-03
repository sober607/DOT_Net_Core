using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_Net_Core.Models;

namespace Infestation.Repositories
{
    public interface INewsRepository
    {
        IEnumerable<News> GetAllNews();
    }
}
