﻿using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApi.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }

        public int ClientId{ get; set; }

        public virtual Client Client { get; set; }

        public int ProductId{ get; set; }

        public virtual Product Product { get; set; }
    }
}
