using StoreApi.Enums;

namespace StoreApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public CategoryProduct Category { get; set; }
        
        public int Quantity{ get; set; }

        public virtual Stock Stock { get; set; }
        
    }
}
