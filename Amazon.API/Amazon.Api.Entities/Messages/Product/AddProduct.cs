using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Api.Entities.Messages.Product
{
    public class AddProductRequest : RequestBase
    {
        public string Title { get; set; } = null!;
        public string? Brand { get; set; }
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? Rating { get; set; }

        [FromForm]
        [NotMapped]
        public IFormFileCollection? Files { get; set; }
    }

    public class AddProductResponse : ResponseBase
    {
        public int ProductId { get; set; }
    }
}
