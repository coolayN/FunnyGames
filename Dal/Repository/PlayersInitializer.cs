using Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    class PlayersInitializer: CreateDatabaseIfNotExists<PlayerContext>
    {
        protected override void Seed(PlayerContext context)
        {
            string salt = PasswordGenerator.GenerateSalt();
            string password = PasswordGenerator.GetPasswordHash("qwerty", salt);

            Player player1 = new Player() { Login = "Player1", Password = password, Salt = salt };
            Statistics player1Statistics = new Statistics { Id = player1.Id, WinGames = 0, LoseGames = 0 };
            context.Players.Add(player1);
            context.Statistics.Add(player1Statistics);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
