using System;
using System.Collections.Generic;

namespace Amazon.Api.Data.Entities;

public partial class Product
{
    public int ProductId { get; set; }
    public string Title { get; set; } = null!;
    public string? Brand { get; set; }
    public string Category { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal? Rating { get; set; }
    public bool? IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ProductDetail? ProductDetail { get; set; }
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public virtual ICollection<UserCart> UserCarts { get; set; } = new List<UserCart>();
}
