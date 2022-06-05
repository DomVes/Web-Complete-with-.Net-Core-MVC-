using GlampingITM.Data.Entities;

namespace GlampingITM.Models
{
    public class HomeViewModel
    {
        public ICollection<Product> Products { get; set; }

        public float Quantity { get; set; }
    }

}
