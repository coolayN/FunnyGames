using Dal.Models;
using Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Helpers
{
    public static class PlayerContextExtentions
    {
        public static Player PlayerAutorization(this PlayerContext context, string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
                throw new ArgumentException("Incorrect input data");

            Player player = null;
             
                player = context.Players.SingleOrDefault(p => p.Login == login);
                if (player is null)
                    throw new Exception("Player with this login is not registered");

                string passwordInput = PasswordGenerator.GetPasswordHash(password, player.Salt);
                if(player.Password!=passwordInput)
                    throw new Exception("The Password is incorrect");

            return player;
        }

        public static Player RegisterNewPlayer(this PlayerContext context, string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
                throw new ArgumentException("Incorrect input data");

            Player newPlayer = null;        
            newPlayer = context.Players.SingleOrDefault(p => p.Login == login);
                if (newPlayer != null)
                throw new Exception("Player with this login is already registered");           

            string salt = PasswordGenerator.GenerateSalt();
            string passwordHash = PasswordGenerator.GetPasswordHash(password, salt);
            newPlayer = new Player { Login = login, Password = passwordHash, Salt = salt };
            Statistics newPlayerStatistics = new Statistics { Id = newPlayer.Id, LoseGames = 0, WinGames = 0};
            context.Players.Add(newPlayer);
            context.Statistics.Add(newPlayerStatistics);            
            context.SaveChanges();
            return newPlayer;
        }

        public static void Save(this PlayerContext context, params Player[] players)
        {
            foreach (var player in players)
            {
                var pl = context.Players.Find(player.Id);
                var stat = pl.Stat;
                stat.LoseGames = player.Stat.LoseGames;
                stat.WinGames = player.Stat.WinGames;
                context.Entry(stat).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }            
        }

    }
}
