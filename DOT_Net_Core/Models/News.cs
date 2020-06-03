using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_Net_Core.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsFake { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Human Human { get; set; }

    }
}
