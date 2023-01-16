using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels
{
    public class CustomerAddress : Address
    {
        public virtual Customer Customer { get; set; } = default!;
        [ForeignKey("CustomerAdresses")]
        public int CustomerId { get; set; }
    }
}