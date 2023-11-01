using StoreApi.Models;

namespace StoreApi.Data.Dtos
{
    public class ReadStockDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public ReadProdcutDto ReadProdcutDto { get; set; }
    }
}
