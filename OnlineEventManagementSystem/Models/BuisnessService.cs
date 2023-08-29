using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class BuisnessService
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public int? BusinessId { get; set; }

    public int? ServicesId { get; set; }

    public virtual Business? Business { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Service? Services { get; set; }
}
