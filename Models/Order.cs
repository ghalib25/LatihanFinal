using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public string Ordercontent { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
