using System;
using System.Collections.Generic;

namespace Amazon.Api.Data.Entities;

public partial class Image
{
    public int ImageId { get; set; }
    public int ProductId { get; set; }
    public int ImageTypeId { get; set; }
    public byte[]? Images { get; set; }
    public string? ImageName { get; set; }
    public string? ImageType { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public virtual ImageType ImageTypes { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}
