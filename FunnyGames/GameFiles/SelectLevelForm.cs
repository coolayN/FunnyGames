using FunnyGames.GameFiles.ValueSetters;
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
    public partial class SelectLevelForm : Form
    {
        Level _level;

        public SelectLevelForm()
        {
            InitializeComponent();
            radioButton1.Text = Level.Easy.ToString();
            radioButton2.Text = Level.Middle.ToString();
            radioButton3.Text = Level.Hard.ToString();
            button1.Text = "Select";
            radioButton1.Select();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                _level = Level.Easy;
            if (radioButton2.Checked)
                _level = Level.Middle;
            if (radioButton3.Checked)
                _level = Level.Hard;

            GameForm gameForm = new GameForm((this.Owner as Form1).players, new AutoValSetter(_level));            
            gameForm.ShowDialog();
        }

        private void SelectLevelForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"{(this.Owner as Form1).players.First().Login}, select difficulty level:";
        }
    }
}
