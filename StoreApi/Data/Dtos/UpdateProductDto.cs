using StoreApi.Enums;

namespace StoreApi.Data.Dtos
{
    public class UpdateProductDto
    {
        public string Name { get; set; }

        public CategoryProduct Category { get; set; }
    }
}
