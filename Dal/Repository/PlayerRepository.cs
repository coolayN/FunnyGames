using Dal.Helpers;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class PlayerRepository :RepsitoryBase<Player>
    {
        public event EventHandler<InfoEventArgs> Error;

        public PlayerRepository():base(new PlayerContext())
        {

        }

        public  Player PlayerAutorization(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
            {
                Error?.Invoke(this, new InfoEventArgs("Incorrect input data"));
                return null;
            }

            Player player = null;
            player = _dbSet.SingleOrDefault(p => p.Login == login);
            if (player is null)
            {
                Error?.Invoke(this, new InfoEventArgs("Player with this login is not registered"));
                return null;
            }

            string passwordInput = PasswordGenerator.GetPasswordHash(password, player.Salt);
            if (player.Password != passwordInput)
            {
                Error?.Invoke(this, new InfoEventArgs("The Password is incorrect"));
                return null;
            }
            return player;
        }

        public  Player RegisterNewPlayer(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
            {
                Error?.Invoke(this, new InfoEventArgs("Incorrect input data"));
                return null;
            }

            Player newPlayer = null;
            newPlayer = _dbSet.SingleOrDefault(p => p.Login == login);
            if (newPlayer != null)
            {
                Error?.Invoke(this, new InfoEventArgs("Player with this login is already registered"));
                return null;
            }
            string salt = PasswordGenerator.GenerateSalt();
            string passwordHash = PasswordGenerator.GetPasswordHash(password, salt);
            newPlayer = new Player { Login = login, Password = passwordHash, Salt = salt, Stat = new Statistics() };
            _dbSet.Add(newPlayer);
            context.SaveChanges();
            return newPlayer;
        }
    }
}
