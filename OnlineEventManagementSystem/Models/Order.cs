using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public DateOnly BookingDate { get; set; }

    public sbyte PaymentStatus { get; set; }

    public string PaymentMode { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public double TotalPrice { get; set; }

    public int TransactionId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
