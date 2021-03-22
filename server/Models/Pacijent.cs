using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace server.Models
{
    [Table("Pacijenti")]
    public class Pacijent
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Ime")]
        [MaxLength(25)]
        public String Ime { get; set; }

        [Column("Prezime")]
        [MaxLength(25)]
        public String Prezime { get; set; }

        [Column("Dijeta")]
        [MaxLength(255)]
        public String Dijeta { get; set; }
        
        [Column("Dijagnoza")]
        [MaxLength(255)]
        public String Dijagnoza { get; set; }

        [Column("BrojSprata")]
        public int BrojSprata { get; set; }

        [Column("BrojSobe")]
        public int BrojSobe { get; set; }

        [Column("BrojKreveta")]
        public int BrojKreveta { get; set; }  
    }
}