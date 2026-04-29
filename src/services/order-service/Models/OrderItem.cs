using System;
using System.Collections.Generic;

namespace OrderService.Models;

public partial class OrderItem
{
    public Guid Id { get; set; }

    public Guid CustomerOrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual CustomerOrder CustomerOrder { get; set; } = null!;
}
