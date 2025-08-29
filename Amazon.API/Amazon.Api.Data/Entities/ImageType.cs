namespace Amazon.Api.Data.Entities
{
    public class ImageType
    {
        public int ImageTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
