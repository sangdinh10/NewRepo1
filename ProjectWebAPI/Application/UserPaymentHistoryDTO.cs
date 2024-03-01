using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ObjectBussiness;

public partial class UserPaymentHistoryDTO
{
  
    public int PaymentHistoryId { get; set; }

    public int? UserId { get; set; }

    public string? TransactionRef { get; set; }


}
