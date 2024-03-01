using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class OrderHistoryDTO
{
    public int OrderHistoryId { get; set; }

    public int? OrderId { get; set; }

    public int? UserId { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime? UpdateDate { get; set; }


}
