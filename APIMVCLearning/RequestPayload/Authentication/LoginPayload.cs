using System.ComponentModel.DataAnnotations;

namespace APIMVCLearning.RequestPayload.Authentication
{
    public class LoginPayload
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}