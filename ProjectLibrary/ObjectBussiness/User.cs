using System;
using System.Collections.Generic;

namespace ProjectLibrary.ObjectBussiness;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool EmailConfirmed { get; set; }

    public string? EmailConfirmationToken { get; set; }

    public int? RoleId { get; set; }

    public string? Status { get; set; }

    public int UserType { get; set; }

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();

    public virtual UserDetail UserNavigation { get; set; } = null!;

    public virtual ICollection<UserPaymentHistory> UserPaymentHistories { get; set; } = new List<UserPaymentHistory>();

    public virtual ICollection<UserRegHistory> UserRegHistories { get; set; } = new List<UserRegHistory>();
}
