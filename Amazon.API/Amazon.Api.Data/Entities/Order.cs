using System;
using System.Collections.Generic;

namespace Amazon.Api.Data.Entities;

public partial class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public virtual Product Product { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
