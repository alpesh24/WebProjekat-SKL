using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Igrac")]
    public class Igrac
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }

        [Required]
        [Range(1980 , 2003)]
        public int Godiste { get; set; }

        public int Visina { get; set; }

        public virtual Tim Tim { get; set; }

        public int TimId { get; set; }

    }
}