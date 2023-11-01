using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApi.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
