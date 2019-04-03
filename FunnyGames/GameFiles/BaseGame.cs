using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.GameFiles
{
    abstract class BaseGame
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public string Name { get; private set; }

        public BaseGame(string name)
        {
            Name = name;
        }       
        public abstract void FirstPlayerMove();
        public abstract void SecondPlayerMove();
        public abstract void EndGame();
    }
}
