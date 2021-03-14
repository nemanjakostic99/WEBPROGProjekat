using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("Sobe")]
    public class Soba
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("BrojKreveta")]
        public int BrojKreveta { get; set; }
        
        public virtual List<Krevet> Kreveti { get; set; }

    }

}