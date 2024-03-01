using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class Shipping
{
    public int ShippingId { get; set; }

    public int? OrderId { get; set; }

    public DateTime? ShipDate { get; set; }

    public string? ShippingStatus { get; set; }

    public string? TrackingNumber { get; set; }

    public virtual Order? Order { get; set; }
}
