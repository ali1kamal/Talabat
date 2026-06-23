using Talabat.DAL.Entities;

namespace Talabat.API.DTOs
{
    public class ProductToDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; } 
        public int ProductTypeId { get; set; } 
        public string ProductBrand { get; set; } 
        public int ProductBrandId { get; set; } 
    }
}
