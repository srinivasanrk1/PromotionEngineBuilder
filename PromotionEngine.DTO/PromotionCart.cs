using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.DTO
{
    public class PromotionCart
    {
        public PromotionCart()
        {
            Products = new List<SKUItems>();
        }

        public IList<SKUItems> Products { get; set; }

        public decimal TotalValue
        {
            get { return Products.Sum(p => p.Price); }
        }
    }
}
