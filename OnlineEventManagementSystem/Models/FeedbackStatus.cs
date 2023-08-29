using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class FeedbackStatus
{
    public int Id { get; set; }

    public string FeedbackStatus1 { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
