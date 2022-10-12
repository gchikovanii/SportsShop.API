using SportsShop.Domain.Constants;
using SportsShop.Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Domain.Entities.ProductAggregate
{
    public class Product : Entity
    {
        public string ProductName { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public Types Types { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}
