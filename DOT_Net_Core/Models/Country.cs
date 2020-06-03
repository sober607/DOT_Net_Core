using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_Net_Core.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int SickCount { get; set; }
        public int DeadCount { get; set; }
        public int RecoveredCount { get; set; }
        public bool Vaccine { get; set; }

        public int? WorldPartId { get; set; }
        [ForeignKey("WorldPartId")]
        public virtual WorldPart WorldPart { get; set; }

        public virtual List<Human> Humans { get; set; }

    }
}
