using Dal.Helpers;
using FunnyGames.GameFiles.ValueSetters;
using FunnyGames.HelpClasses;
using FunnyGames.HelpClasses.EventArgsClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyGames.GameFiles
{
    public partial class PlayerSetValuesForm : Form
    {
        PlayerValSetter _playerValSetter;

        public PlayerSetValuesForm()
        {
            InitializeComponent();
            label5.Text = $"{(this.Owner as Form1).players.First().Login}, please, set start values:";
            label1.Text = "Enter min value";
            label2.Text = "Enter max value";
            label3.Text = "Enter the value";
            textBox1.KeyPress += TextboxValidators.IntFilter;
            textBox2.KeyPress += TextboxValidators.IntFilter;
            textBox3.KeyPress += TextboxValidators.IntFilter;
            button1.Text = "Enter";
            _playerValSetter = new PlayerValSetter();
            _playerValSetter.Error += WriteErrors;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) ||
                String.IsNullOrWhiteSpace(textBox2.Text) ||
                String.IsNullOrWhiteSpace(textBox3.Text))
                MessageBox.Show("Please, enter all data");
            else
            {
                _playerValSetter.TryToSetValues(textBox1.Text, textBox2.Text, textBox3.Text);
                if (_playerValSetter.IsReady)
                {
                    GameForm gameForm = new GameForm((this.Owner as Form1).players, _playerValSetter);
                    gameForm.ShowDialog();
                    this.Close();
                }
            }
        }

        public void WriteErrors(object sender, InfoEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text))
                textBox4.Text = e.Message;
            else
                textBox4.Text += "\r" + "\n" + e.Message;
        }
    }
}
