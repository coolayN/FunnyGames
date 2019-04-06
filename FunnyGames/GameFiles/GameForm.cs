using Dal.Models;
using Dal.Repository;
using FunnyGames.GameFiles.ValueSetters;
using FunnyGames.HelpClasses;
using FunnyGames.HelpClasses.EventArgsClasses;
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
using Dal.Helpers;

namespace FunnyGames
{
    public partial class GameForm : Form
    {
        GuessNumber _game;
        BaseStartValSetter _setter;
        Player player;

        public GameForm(IEnumerable<Player> players, BaseStartValSetter setter)
        {
            InitializeComponent();
            _setter = setter;
            player = players.Last();
            _game = new GuessNumber(player, setter);
            textBox1.KeyPress += TextboxValidators.IntFilter;
            _game.Info += ShowInfo;
            _game.GameFinished += ShowInfo;
            button1.Text = "Try";
            label1.Text = $"{_game.Player.Login} plays.The number is in the range of {_game.ValSetter.MinValue} to {_game.ValSetter.MaxValue}";
            label2.Text = $"Attempt {_game.CurrentAttempt} from {_game.ValSetter.MaxAttemptCount}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
               bool isFinished =  _game.PlayerMove(int.Parse(textBox1.Text));
                //if(!isFinished)
                //    this.Close();
                label2.Text = $"Attempt {_game.CurrentAttempt} from {_game.ValSetter.MaxAttemptCount}";
                textBox1.Text = String.Empty;
            }
        }


        private void ShowInfo(object sender, InfoEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void FinishGame(object sender, InfoEventArgs e)
        {
            MessageBox.Show(e.Message);
            this.Close();            
        }
    }
}
