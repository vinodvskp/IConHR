using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class ResetPasswordModel
    {
        public string Password { get; set; }
        public string PasswordToken { get; set; }
        public bool CanResetPassword { get; set; }
        public string Email { get; set; }
    }
}
