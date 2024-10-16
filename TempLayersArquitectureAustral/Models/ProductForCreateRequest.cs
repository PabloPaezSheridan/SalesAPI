using System.ComponentModel.DataAnnotations;

namespace TempLayersArquitectureAustral.Models
{
    public class ProductForCreateRequest
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public int Stock { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
