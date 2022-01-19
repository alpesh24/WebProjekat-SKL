using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Tim")]
    public class Tim
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Ime { get; set; }

        public string Skor { get; set; }

        public int LigaID {get; set; }

        [JsonIgnore]
        public virtual List<Igrac> Igraci {get; set; }
        
        [JsonIgnore]
        public virtual  List<Utakmica> Utakmice {get; set; }

        [NotMapped]
        public virtual Liga Liga {get ; set;}
        
    }
}