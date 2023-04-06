
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.UserDtos
{
    public class UserForUpdatePasswordDto
    {
        [Required]
        public string? CurrentPassword { get; set; }

        [Required]
        public string? NewPassword { get; set; }
    }
}
