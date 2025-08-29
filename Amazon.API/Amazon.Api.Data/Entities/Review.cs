using System;
using System.Collections.Generic;

namespace Amazon.Api.Data.Entities;

public partial class Review
{
    public int ReviewId { get; set; }
    public int ProductId { get; set; }
    public string ReviewerName { get; set; } = null!;
    public string ReviewerEmail { get; set; } = null!;
    public string? Comment { get; set; }
    public decimal Rating { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public virtual Product Product { get; set; } = null!;
}
