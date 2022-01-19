using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Utakmica")]
    public class Utakmica
    {
        [Key]
        public int ID { get; set; }

        
        public virtual Tim Tim1 { get; set; }

        
        public virtual Tim Tim2 { get; set; }

        public int Rezultat1 { get; set; }

        public int Rezultat2 {get; set; }

       
    }
}