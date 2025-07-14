using System.ComponentModel.DataAnnotations;

namespace EgyptWalks.Models.DTo
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage ="Code Has To be Minimum of 3 Characters")]
        [MaxLength(3 , ErrorMessage = "Code Has To be Minimum of 3 Characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="Name has to be a Maximum of 100 Characters")]

        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
