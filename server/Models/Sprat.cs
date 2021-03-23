using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace server.Models
{
    [Table("Spratovi")]
    public class Sprat
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        public virtual List<Soba> sobe { get; set; }

        [JsonIgnore]
        public virtual Bolnica bolnica { get; set; }

    }

}