namespace Amazon.Api.Data.Entities
{
    public class ProductTag
    {
        public int ProductTagId { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public bool IsActive { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Tag Tag { get; set; } = null!;
    }
}
