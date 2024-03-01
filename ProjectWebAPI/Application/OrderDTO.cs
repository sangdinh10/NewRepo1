using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class OrderDTO
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? CouponId { get; set; }

 
}
