using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class ShippingDTO
{
    public int ShippingId { get; set; }

    public int? OrderId { get; set; }

    public DateTime? ShipDate { get; set; }

    public string? ShippingStatus { get; set; }

    public string? TrackingNumber { get; set; }


}
