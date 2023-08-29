using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string CategoryDescription { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
