using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace server.Models
{
    [Table("Kreveti")]
    public class Krevet
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        
        [Column("Pacijent")]
        public Pacijent pacijent { get; set; }

        [Column("Zauzet")]
        public bool zauzet { get; set; }

        [JsonIgnore]
        public Soba soba { get; set; }
    }

}