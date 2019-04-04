using Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class PlayerContext:DbContext
    {
        public PlayerContext() : base("PlayersConnection")
        {
            Database.SetInitializer(new PlayersInitializer());
        }

       public DbSet<Player> Players { get; set; }
       public DbSet<Statistics> Statistics { get; set; }
    }
}
