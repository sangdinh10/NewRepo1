using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class UserDTO
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string EmailConfirmationToken { get; set; } = null!;

    public int RoleId { get; set; }

    public string Status { get; set; } = null!;

    public int UserType { get; set; }
}
