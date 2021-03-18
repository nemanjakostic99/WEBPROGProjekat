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

        [Column("BrojSpratova")]
        public int BrojSpratova { get; set; }

        [Column("BrojSoba")]
        public int BrojSoba { get; set; }

        [Column("BrojKrevetaPoSobi")]
        public int BrojKrevetaPoSobi { get; set; }

        public virtual List<Soba> Spratovi { get; set; }

    }

}