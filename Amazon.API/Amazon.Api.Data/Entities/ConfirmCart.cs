namespace Amazon.Api.Data.Entities
{
    public class ConfirmCart
    {
        public int ConfirmCartId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
