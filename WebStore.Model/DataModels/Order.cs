using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmmount { get; }
        public long TrackingNumber { get; set; }

        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public IList<OrderProduct>? OrderProducts { get; set; }
    }
}