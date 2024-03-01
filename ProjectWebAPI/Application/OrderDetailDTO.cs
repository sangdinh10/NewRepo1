using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class OrderDetailDTO
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? BookId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Subtotal { get; set; }

  
}
