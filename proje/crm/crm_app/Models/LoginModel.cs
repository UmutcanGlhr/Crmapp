using System.ComponentModel.DataAnnotations;

namespace crm_app.Models
{
    public class LoginModel
    {
        private string? _returnUrl;
        [Required(ErrorMessage = "email is reuqired")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "password is reuqired")]
        public string? Password { get; set; }

        public string ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                {
                    return "/";
                }
                else
                {
                    return _returnUrl;
                }
            }set{
                _returnUrl = value;
            }
        }
    }
}