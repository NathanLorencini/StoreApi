using StoreApi.Enums;

namespace StoreApi.Data.Dtos
{
    public class CreateProductDto 
    {
        public string Name { get; set; }

        public CategoryProduct Category { get; set; }

        public int Quantity { get; set; }

    }
}
