using Dal.Models;
using Game2.GameFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyGames
{
    public partial class GameForm : Form
    {
        GuessNumber game;

        public GameForm(IEnumerable<Player> players)
        {
            InitializeComponent();
            game = new GuessNumber(players);
        }
    }
}
