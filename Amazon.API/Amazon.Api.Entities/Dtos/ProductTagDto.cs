namespace Amazon.Api.Entities.Dtos
{
    public class ProductTagDto
    {
        public int ProductTagId { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public bool IsActive { get; set; }

        public List<TagDto> Tag { get; set; } = null!;
    }
}
