using Dal.Helpers;
using FunnyGames.HelpClasses.EventArgsClasses;
using Game2.GameFiles;
using Game2.HelpClasses;
using Game2.HelpClasses.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyGames.GameFiles.ValueSetters
{
    public  class BaseStartValSetter
    {
        public event EventHandler<InfoEventArgs> Error;
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public int Value { get; private set; }
        public int MaxAttemptCount { get; private set; }
        public bool IsReady { get; protected set; }

        public BaseStartValSetter()
        {
            IsReady = false;
        }  

        protected bool SetStartValues(int min, int max, int number)
        {
            IsReady = (Validate(max, new MinValueValidator(min)) &&
                Validate(number, new MinMaxValueValidator(min, max)));

            if (IsReady)
            {
                MinValue = min;
                MaxValue = max;
                Value = number;
                MaxAttemptCount = CalculateAttemptCount();
            }
            return IsReady;
        }

        protected bool Validate(int value, IValidator<int> validaror)
        {
            if (!validaror.Validate(value))
                Error?.Invoke(this, new InfoEventArgs(validaror.Error));
            return validaror.IsValid;
        }

        private int CalculateAttemptCount()
        {
            var length = MaxValue - MinValue + 1;
            var sum = 2;
            var power = 1;
            while (sum < length)
            {
                sum *= 2;
                power++;
            }
            return power;
        }
    }
}
