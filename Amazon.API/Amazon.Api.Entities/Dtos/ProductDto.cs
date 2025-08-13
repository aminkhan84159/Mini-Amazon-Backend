namespace Amazon.Api.Entities.Dtos
{
    public class ProductDto
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

        public ProductDetailDto ProductDetails { get; set; } = null!;
        public List<ReviewDto> Reviews { get; set; }
        public List<TagDto> Tags { get; set; }
        public List<ImageDto> Images { get; set; }
    }
}
