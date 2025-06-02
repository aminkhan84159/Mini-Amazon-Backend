namespace Amazon.Api.Entities.Dtos
{
    public class ImageDto
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public int ImageTypeId { get; set; }
        public string? Images { get; set; }
        public string? ImageName { get; set; }
        public string? ImageType { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
