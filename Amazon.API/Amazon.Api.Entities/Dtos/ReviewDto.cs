namespace Amazon.Api.Entities.Dtos
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public string ReviewerName { get; set; } = null!;
        public string ReviewerEmail { get; set; } = null!;
        public string? Comment { get; set; }
        public decimal Rating { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
