using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? BusinessServiceId { get; set; }

    public int? FeedbackStatusId { get; set; }

    public string? Comment { get; set; }

    public string? BusinessReply { get; set; }

    public virtual BuisnessService? BusinessService { get; set; }

    public virtual Client? Client { get; set; }

    public virtual FeedbackStatus? FeedbackStatus { get; set; }
}
