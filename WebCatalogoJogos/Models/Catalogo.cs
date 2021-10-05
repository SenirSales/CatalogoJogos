using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCatalogoJogos.Models
{
    public class Catalogo
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 3)]
        [Required]
        public string Titulo { get; set; }
        public bool Ativo { get; set; }
        public string Genero { get; set; }

        //[Range(typeof(Decimal), "1", "1000")]
        //[Range(1, 1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }

        [DataType(DataType.Date)]
        public DateTime Incluido { get; set; }
        public bool Locado { get; set; }
        [DataType(DataType.Date)]
        public DateTime LocadoEm { get; set; }
    }
}
