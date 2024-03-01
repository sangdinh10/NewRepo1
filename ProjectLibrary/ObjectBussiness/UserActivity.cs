using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class UserActivity
{
    public int ActivityId { get; set; }

    public int? UserId { get; set; }

    public string? Action { get; set; }

    public string? Details { get; set; }

    public DateTime? LogDate { get; set; }

    public virtual User? User { get; set; }
}
