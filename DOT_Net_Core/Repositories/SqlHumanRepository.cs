using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_Net_Core.Models;
using DOT_Net_Core.Repository;

namespace DOT_Net_Core.Repository
{
    public class SqlHumanRepository : IHumanActions
    {
        private DOT_Net_CoreContext _context { get; set; }
        
        public IEnumerable<Human> GetAllHumans()
        {
            return _context.Humans;
        }
    }
}
