using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace femcoservice.Models
{
    public class Producto
    {  [Key]
        public int producId { get; set; }
        [Required(ErrorMessage ="you must enter a Usted deve entrar a{0}")]
        [StringLength(50,ErrorMessage ="the field{0}can contain maximun{1}and minimum{2}characters",MinimumLength =1)]//
        [Index("Producto_Nombre_Index", IsUnique =true)]
        public string Nombre { get; set; }

        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        public decimal Price { get; set; }
    }
}