using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class UserType
{
    public int Id { get; set; }

    public string UserType1 { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
