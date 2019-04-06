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
using Dal.Models;
using Dal.Repository;


namespace FunnyGames
{
    public partial class Auth : Form
    {
       
        public Player player { get; set; } = null;
        PlayerContext context;
        int number;
        public Auth(int plNumb)
        {
            InitializeComponent();
            number = plNumb;
 
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            context = new PlayerContext();
            label1.Text = $"Authorization/Registration Player{number}";
            label2.Text = "Login";
            label3.Text = "Password";
            button1.Text = "Authorization";
            button2.Text = "Registration";
            button1.Enabled = button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    player = context.PlayerAutorization(login_TB.Text, password_TB.Text);
                    MessageBox.Show($"Hello,{player.Login}!", "User is authorized", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }
                finally
                {
                    this.Close();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                try
                {
                    player = context.RegisterNewPlayer(login_TB.Text, password_TB.Text);
                    MessageBox.Show($"Hello,{player.Login}!", "User is registered and authorized",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {                  
                   this.Close();
                }
        }

        private void login_TB_TextChanged(object sender, EventArgs e)
        {
           if(String.IsNullOrWhiteSpace(login_TB.Text) || String.IsNullOrWhiteSpace(password_TB.Text))
                 button1.Enabled = button2.Enabled = false;
            else
             button1.Enabled = button2.Enabled = true;
        }

        private void Auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            label2.Text = label3.Text = String.Empty;
            //context.Dispose();
        }
    }
}
