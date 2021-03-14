using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("Kreveti")]
    public class Krevet
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Pacijent")]
        public virtual Pacijent pacijent { get; set; }
        [Column("Zauzet")]
        public bool zauzet { get; set; }

    }

}