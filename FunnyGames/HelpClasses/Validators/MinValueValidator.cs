using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.HelpClasses.Validator
{
    public class MinValueValidator : IValidator<int>
    {
        private int _minValue;
        public string Error { get; set; }
        public bool IsValid { get; set; }

        public MinValueValidator(int minValue)
        {
            _minValue = minValue;
        }

        public bool Validate(int value)
        {
            IsValid = true;
            if (value < _minValue)
            {
                Error = ($"-{value}- Number must be more than {_minValue}");
                IsValid = false;
            }

            return IsValid;
        }
    }
}
