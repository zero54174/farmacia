using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmacia
{
    public partial class Login : Form

    {
        int a = 0;
        public Login()
        {
            InitializeComponent();
            
        }

        private void btn_cls_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("los campos estan vacios");
            }
            else
            {
                if (txtuser.Text == "dylan" && txtpass.Text == "1234")
                {  
                    MessageBox.Show("los datos estan correctos");
                    this.Hide();
                    Menu mf = new Menu();
                    mf.Show();
                }
                else
                {
                    MessageBox.Show("datos incorectos intente nuevamnete");
                    a = a + 1;
                    if (a == 3)
                    {
                        MessageBox.Show("ERROR SE HAN AGOTADO SUS INTENTOS EL PROGRAMA SE CERRARA");
                        a = 0;
                        Application.Exit();
                        
                    }
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("los campos estan vacios");
            }
            else
            {
                if (txtuser.Text == "dylan" && txtpass.Text == "1234")
                {
                    MessageBox.Show("los datos estan correctos");
                    this.Hide();
                    Menu mf = new Menu();
                    mf.Show();
                }
                else
                {
                    MessageBox.Show("datos incorectos intente nuevamnete");
                    a = a + 1;
                    if (a == 3)
                    {
                        MessageBox.Show("ERROR SE HAN AGOTADO SUS INTENTOS EL PROGRAMA SE CERRARA");
                        a = 0;
                        Application.Exit();

                    }
                }

            }
        }
    }
}
