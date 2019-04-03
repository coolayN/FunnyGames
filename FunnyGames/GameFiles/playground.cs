using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Helpers;
using Dal.Models;
using Dal.Repository;

namespace Game2.GameFiles
{
    class Playground
    {
        Player Player1 { get;  set; }
        Player Player2 { get;  set; }
        PlayerContext context = new PlayerContext();
        BaseGame _game;


        public void Start()
        {

            //Console.WriteLine("Player1 authorization:");
            //Player1 = context.GetPlayer();

            //Console.WriteLine("Player2 authorization:");
            //Player2 = context.GetPlayer();

            Player1 = context.Players.Find(1);
            Player2 = context.Players.Find(2);

            if (Player1 != null && Player2 != null)
                _game = new GuessNumber(Player1, Player2);

            _game.FirstPlayerMove();
            _game.SecondPlayerMove();
            _game.EndGame();
            context.Save(Player1, Player2);   
        }

    }
}
