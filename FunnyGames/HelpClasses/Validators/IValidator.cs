using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.HelpClasses
{
    public interface IValidator<T>
    {
        string Error { get; set; }
        bool IsValid { get; set; }
        bool Validate(T value);
    }
}
