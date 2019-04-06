using Dal.Models;
using FunnyGames.GameFiles;
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
    public partial class Form1 : Form
    {
        public List<Player> players = new List<Player>();
        int playersCount;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Select the number of players";
            radioButton1.Text = "1 Player";
            radioButton2.Text = "2 Players";
            radioButton1.Select();
            button1.Text = "Start";
            checkBox1.Text = "Without authorization";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (players.Count == 0)
            {
                if (radioButton1.Checked)
                    playersCount = 1;
                if (radioButton2.Checked)
                    playersCount = 2;

                if (checkBox1.Checked)
                {
                    for (int i = 1; i <= playersCount; i++)
                    {
                        players.Add(new Player() { Login = $"Player{i}", Stat = new Statistics() });
                    }
                }
                else
                {
                    for (int i = 1; i <= playersCount; i++)
                    {
                        bool tryAgain;
                        Auth auth = new Auth(i);
                        do
                        {
                            tryAgain = false;
                            auth.ShowDialog();
                            if (auth.player == null)
                            {
                                DialogResult result = MessageBox.Show("Try again?", "authorization failed", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                    tryAgain = true;
                                else
                                {
                                    players = new List<Player>();
                                    return;
                                }
                            }
                        }
                        while (tryAgain);
                        players.Add(auth.player);
                    }
                }
            }
            else
            {
                players.Reverse();
            }
            if(players.Count==1)
            {
                SelectLevelForm selectForm = new SelectLevelForm();
                selectForm.Owner = this;
                selectForm.ShowDialog();              
            }
            if(players.Count==2)
            {
                PlayerSetValuesForm form = new PlayerSetValuesForm();
                form.Owner = this;
                form.ShowDialog();
            }

        }
    }
}
