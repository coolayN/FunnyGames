using FunnyGames.HelpClasses.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyGames.GameFiles.ValueSetters
{
    class PlayerValSetter:BaseStartValSetter
    {
        StringIsNumberValidator validator = new StringIsNumberValidator();

        public bool TryToSetValues(string min, string max, string value)
        {
            bool isCorrect = (validator.Validate(min) && validator.Validate(max) && validator.Validate(value));
            if (isCorrect)
                isCorrect = SetStartValues(int.Parse(min), int.Parse(max), int.Parse(value));
            return isCorrect;
        }
    }
}
