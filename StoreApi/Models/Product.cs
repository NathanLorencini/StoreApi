using StoreApi.Data;
using StoreApi.Enums;

namespace StoreApi.Models
{
    public class Product
    {
        private StoreContext _context;


        public int Id { get; set; }
        
        public string Name { get; set; }

        public CategoryProduct Category { get; set; }
        
        public int Quantity{ get; set; }


    }
}
