namespace Amazon.Api.Entities.Dtos
{
    public class ConfirmCartDto
    {
        public int ConfirmCartId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
