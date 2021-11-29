using System.ComponentModel;

namespace Opdracht.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; } 
        public string Sku { get; set; } 

        [DisplayName("Artikel Naam")]
        public string ProductName { get; set; }

        [DisplayName("Prijs")]
        public decimal Price { get; set; }
    }
}
