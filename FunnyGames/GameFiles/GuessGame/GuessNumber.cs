using Dal.Models;
using Game2.HelpClasses;
using Game2.HelpClasses.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.GameFiles
{
    class GuessNumber : BaseGame
    {
        private int MinValue { get; set; }
        private int MaxValue { get; set; }
        private int Value { get; set; }
        private int MaxAttemptCount { get; set; }
        private int CurrentAttemptCount { get; set; }
        bool IsWin { get; set; }

        public GuessNumber(IEnumerable<Player> players):base("GuessNumber")
        {
            if (players.Count() < 1 || players.Count() > 2)
                throw new ArgumentException();

            if (players.Count() == 2)
            {
                Player1 = players.First();
                Player2 = players.Last();
            }
            else
            {
                Player1 = players.First();
                Player2 = new Player();///!!!!!!!!!!!!!
            }
        }

        public override void FirstPlayerMove(string min, string max, string number)
        {
            MinValue = IntReader(min);

            MaxValue = IntReader(max, new MinValueValidator(MinValue));

            Console.WriteLine("Enter the value:");
            Value = IntReader(number, new MinMaxValueValidator(MinValue, MaxValue));
            MaxAttemptCount = CalculateAttemptCount();
        }      

        public override void SecondPlayerMove()
        {
            Console.Clear();

            int pl2Value;
            IsWin = false;
            CurrentAttemptCount = 0;
            do
            {
                Console.Write($"Attempt: {++CurrentAttemptCount}/{MaxAttemptCount}. Min: {MinValue}. Max: {MaxValue}. Set your guess: ");
                pl2Value = IntReader(new MinMaxValueValidator(MinValue, MaxValue));
                if (pl2Value > Value)
                {
                    Console.WriteLine($"{pl2Value} > player1Number");
                }
                if (pl2Value < Value)
                {
                    Console.WriteLine($"{pl2Value} < player1Number");
                }
                if (pl2Value == Value)
                {
                    IsWin = true;
                }
            } while (!IsWin && CurrentAttemptCount < MaxAttemptCount);
        }

        public override void EndGame()
        {
            if (IsWin)
            {
                Console.WriteLine($"{Player2.Login} you are win! Number was {Value}. You spend {CurrentAttemptCount} from {MaxAttemptCount}");
                Player2.Stat.WinGames++;
            }
            else
            {
                Console.WriteLine($"{Player2.Login} you are lose! Number was {Value}. You spend all your attemp");
                Player2.Stat.LoseGames++;
            }
        }

        private int IntReader(string num, IValidator<int> validaror = null)
        {
            int value;

             if(!int.TryParse(num, out value))
                throw new Exception("It's not a number!");

             if (validaror != null && !validaror.Validate(value))
                throw new Exception(validaror.Error);       

            return value;
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
