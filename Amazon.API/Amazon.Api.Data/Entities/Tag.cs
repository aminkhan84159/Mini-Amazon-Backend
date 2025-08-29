using System;
using System.Collections.Generic;

namespace Amazon.Api.Data.Entities;

public partial class Tag
{
    public int TagId { get; set; }
    public string? Tags { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
}
