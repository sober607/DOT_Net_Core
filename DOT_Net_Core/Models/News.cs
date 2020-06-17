using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_Net_Core.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Title is not set")]
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsFake { get; set; }
        [Required (ErrorMessage ="Author ID is not entered")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Human Human { get; set; }

    }
}
