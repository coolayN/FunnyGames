using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.HelpClasses.Validator
{

        public class MinMaxValueValidator : IValidator<int>
        {
            private int _minValue;
            private int _maxValue;
            public string Error { get; set; }
            public bool IsValid { get; set; }

            public MinMaxValueValidator(int minValue, int maxValue)
            {
                _minValue = minValue;
                _maxValue = maxValue;
            }

            public bool Validate(int value)
            {
                IsValid = true;
                if (value < _minValue)
                {
                    Error = ($"Number must be more than {_minValue}");
                    IsValid = false;
                }
                if (value > _maxValue)
                {
                    Error = ($"Number must be less than {_maxValue}");
                    IsValid = false;
                }

                return IsValid;
            }
        }
}
