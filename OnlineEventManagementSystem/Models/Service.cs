using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class Service
{
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public string ServiceDescription { get; set; } = null!;

    public int? CategoriesId { get; set; }

    public virtual ICollection<BuisnessService> BuisnessServices { get; set; } = new List<BuisnessService>();

    public virtual Category? Categories { get; set; }
}
