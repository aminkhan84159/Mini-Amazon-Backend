using System;
using System.Collections.Generic;

namespace Amazon.Api.Data.Entities;

public partial class ProductDetail
{
    public int ProductDetailId { get; set; }
    public int ProductId { get; set; }
    public string Description { get; set; } = null!;
    public int Stock { get; set; }
    public string Sku { get; set; } = null!;
    public decimal Weight { get; set; }
    public decimal? Discount { get; set; }
    public string Warranty { get; set; } = null!;
    public string? Shipping { get; set; }
    public string ReturnPolicy { get; set; } = null!;
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public virtual Product Product { get; set; } = null!;
}
