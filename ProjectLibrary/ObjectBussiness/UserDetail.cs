﻿using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class UserDetail
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public bool? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Avatar { get; set; }

    public virtual User? User { get; set; }
}
