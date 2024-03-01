using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class NotificationDTO
{
    public int NotificationId { get; set; }

    public int? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? SentDate { get; set; }

    public int? UserId { get; set; }

  
}
