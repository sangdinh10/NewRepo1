using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class DiscountCouponDTO
{
    public int CouponId { get; set; }

    public string? CouponCode { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public DateOnly? ExpiryDate { get; set; }

  
}
