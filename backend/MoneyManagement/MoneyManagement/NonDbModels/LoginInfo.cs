using System.ComponentModel.DataAnnotations;

namespace MoneyMgmt.Web.NonDbModels
{
    public class LoginInfo
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
