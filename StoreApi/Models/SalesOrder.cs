using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApi.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }

        public int ClientId{ get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        public int ProductId{ get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
