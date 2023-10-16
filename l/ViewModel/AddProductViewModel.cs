using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AddProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, Enter a valid Product Name")]
        [StringLength(50, ErrorMessage = "Must be more 5 letter", MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, Enter a valid Value")]
        [StringLength(50, ErrorMessage = "Must be more 5 letter", MinimumLength = 5)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please, Enter a valid Value")]
        [StringLength(50, ErrorMessage = "Must be more 5 letter", MinimumLength = 5)]
        [Column (TypeName ="Number")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please, Enter a valid Price")]
        [StringLength(50, ErrorMessage = "Must be more 5 letter", MinimumLength = 5)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please, Provide atleast one image")]
        public IFormFileCollection Images { get; set; }
        public List<string> ImagesUrl { get; set; }

        [Display(Name = "Choose Product Category")]
        public int CategoryID { get; set; }

    }
}
