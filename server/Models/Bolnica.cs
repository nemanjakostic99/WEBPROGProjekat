using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("Bolnice")]
    public class Bolnica
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Ime")]
        public string Ime { get; set; }
        
        public virtual List<Sprat> spratovi { get; set; }

    }

}