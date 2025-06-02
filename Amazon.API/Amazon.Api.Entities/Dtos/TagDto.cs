namespace Amazon.Api.Entities.Dtos
{
    public class TagDto
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }
        public string? Tags { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
