using Dal.Helpers;
using Dal.Models;
using Dal.Repository;
using FunnyGames.GameFiles.ValueSetters;
using FunnyGames.HelpClasses.EventArgsClasses;
using Game2.HelpClasses;
using Game2.HelpClasses.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.GameFiles
{
    class GuessNumber
    {
        public event EventHandler<InfoEventArgs> Info;
        public event EventHandler<InfoEventArgs> GameFinished;

        public BaseStartValSetter ValSetter { get; set; }
        public int CurrentAttempt { get; private set; }
        public Player Player { get; set; }
        public readonly string Name;

        public GuessNumber(Player player, BaseStartValSetter setter)
        {
            Player = player;
            ValSetter = setter;
            CurrentAttempt = 1;
            Name = "Guess The Number";
        }

        public bool PlayerMove(int pl2Value)
        {
            if (ValSetter.IsReady)
            {
                if (CurrentAttempt >= ValSetter.MaxAttemptCount)
                {
                    EndGame(false);
                    return false;
                }

                if (pl2Value == ValSetter.Value)
                {
                    EndGame(true);
                    return false;
                }

                if(pl2Value > ValSetter.Value)
                {
                    Info?.Invoke(this, new InfoEventArgs($"{pl2Value} >  than the number"));
                    CurrentAttempt++;
                }
                if (pl2Value < ValSetter.Value)
                {
                    Info?.Invoke(this, new InfoEventArgs($"{pl2Value} <  than the number"));
                    CurrentAttempt++;
                }
            }
            return true;
        }

        public void EndGame(bool IsWin)
        {
            if (IsWin)
            {
                GameFinished?.Invoke(this, new InfoEventArgs($"{Player.Login} you are win! Number was {ValSetter.Value}. You spend {CurrentAttempt} attemts from { ValSetter.MaxAttemptCount}"));
                Player.Stat.WinGames++;
            }
            else
            {
                GameFinished?.Invoke(this, new InfoEventArgs($"{Player.Login} you are lose! Number was {ValSetter.Value}. You spend all your attempts"));
                Player.Stat.LoseGames++;
            }
            using (PlayerContext context = new PlayerContext())
            {
                context.Save(Player);
            }
        }
    }
}
