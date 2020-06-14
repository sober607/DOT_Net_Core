using DOT_Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.ViewModels
{
    public class HumanAuthorsViewModel
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NewsCount { get; set; }
    }
}
