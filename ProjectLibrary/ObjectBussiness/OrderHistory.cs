using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class OrderHistory
{
    public int OrderHistoryId { get; set; }

    public int? OrderId { get; set; }

    public int? UserId { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User? User { get; set; }
}
