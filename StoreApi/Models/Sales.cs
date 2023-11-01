namespace StoreApi.Models
{
    public class Sales
    {
        public int Id { get; set; }

        public virtual SalesOrder SalesOrder { get; set; }
        
    }
}
