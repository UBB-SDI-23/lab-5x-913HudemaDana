using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelsValidation
{
    public class ValidUser
    {
        private readonly User _user;
        public ValidUser(User user)
        {
            _user = user;
        }
        public bool IsPasswordValid()
        {
            if (string.IsNullOrWhiteSpace(_user.Password) || _user.Password.Length < 8)
            {
                return false;
            }

            var hasUpperCase = false;
            var hasLowerCase = false;
            var hasNumber = false;
            var hasSymbol = false;

            foreach (var c in _user.Password)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                if (char.IsLower(c)) hasLowerCase = true;
                if (char.IsDigit(c)) hasNumber = true;
                if (!char.IsLetterOrDigit(c)) hasSymbol = true;
            }

            return hasUpperCase && hasLowerCase && hasNumber && hasSymbol;
        }
    }
}
