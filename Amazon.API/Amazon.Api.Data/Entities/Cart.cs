using System;
using System.Collections.Generic;

namespace Amazon.Api.Data.Entities;

public partial class Cart
{
    public int CartId { get; set; }
    public int UserId { get; set; }
    public bool? IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual ICollection<UserCart> UserCarts { get; set; } = new List<UserCart>();
}
