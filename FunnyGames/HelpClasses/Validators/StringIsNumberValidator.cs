using Game2.HelpClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyGames.HelpClasses.Validators
{
    class StringIsNumberValidator:IValidator<string>
    {
        private int _value;
        public string Error { get; set; }
        public bool IsValid { get; set; }

        public bool Validate(string value)
        {
            IsValid = true;
            if (!(int.TryParse(value, out _value)&& !String.IsNullOrWhiteSpace(value)))
            {
                Error = ($"{_value} is not a number");
                IsValid = false;
            }
            return IsValid;
        }
    }
}
