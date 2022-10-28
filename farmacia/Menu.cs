﻿using System;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                //this.BackgroundImage = new Bitmap("farmacia.Properties.Resources.acceso;");
                this.BackgroundImage = Properties.Resources._4510_jpg_wh860;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            catch
            {
                this.BackgroundImage = null;
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
}
