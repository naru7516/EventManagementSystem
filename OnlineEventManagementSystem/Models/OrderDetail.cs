using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? BuisnessServiceId { get; set; }

    public double Price { get; set; }

    public virtual BuisnessService? BuisnessService { get; set; }

    public virtual Order? Order { get; set; }
}
