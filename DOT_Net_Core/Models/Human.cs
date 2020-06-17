using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_Net_Core.Models
{
    public class Human
    {
        public int Id { get; set; }
     
        [Required]

        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z *$]", ErrorMessage = "name must containe only letters")]
        public string LastName { get; set; }
        [Required]
        [Range(1, 250, ErrorMessage ="Invalid age")]
        public int Age { get; set; }
        [Required]
        public bool IsSick { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage ="Country Id is not in available range")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual List<News> News { get; set; }


    }


}
