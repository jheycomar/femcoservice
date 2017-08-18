using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace femcoservice.Models
{
    [NotMapped]
    public class ProductoView
    {
        
        public int producId { get; set; }

        public string Image { get; set; }

        [Display(Name = "Image")]
        public HttpPostedFileBase ImagenFile { get; set; }

        [Required(ErrorMessage = "you must enter a Usted deve entrar a{0}")]
        [StringLength(50, ErrorMessage = "the field{0}can contain maximun{1}and minimum{2}characters", MinimumLength = 1)]//
        public string Nombre { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "you must enter a {0}")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        [Display(Name = "Ultima Compra")]
        public DateTime? UltimaCompra { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }

       
    }
}