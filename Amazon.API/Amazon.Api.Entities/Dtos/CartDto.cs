namespace Amazon.Api.Entities.Dtos
{
    public class CartDto
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
