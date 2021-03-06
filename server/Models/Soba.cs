using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace server.Models
{
    [Table("Sobe")]
    public class Soba
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        
        public virtual List<Krevet> Kreveti { get; set; }
        
        [JsonIgnore]
        public Sprat sprat { get; set; }
    }
}