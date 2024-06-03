using System.ComponentModel.DataAnnotations.Schema;

namespace Multishop.Images.Dtos
{
    public class ResultImageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? SignedUrl { get; set; }
        public string? SavedFileName { get; set; }

    }
}
