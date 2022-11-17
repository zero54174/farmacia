using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmacia
{
    public partial class laboratorio : Form
    {
        Conexion srv = new Conexion();
        SqlCommand command = new SqlCommand();

        public laboratorio()
        {
            InitializeComponent();
        }

        private void laboratorio_Load(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("select * from laboratorio", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dglab.DataSource = ds.Tables[0];
        }

        private void dglab_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            habilitar();
            DataGridViewSelectedCellCollection cell = dglab.SelectedCells;
            DataGridViewSelectedRowCollection rows = dglab.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcodigo.Text = Convert.ToString(dglab[0, fila].Value);
                txtNombre.Text = Convert.ToString(dglab[1, fila].Value);
                txtDireccion.Text = Convert.ToString(dglab[2, fila].Value);
                txtTelefono.Text = Convert.ToString(dglab[3, fila].Value);
                txtEmail.Text = Convert.ToString(dglab[4, fila].Value);
                txtWeb.Text = Convert.ToString(dglab[5, fila].Value);
                sw = true;

            }

        }

        public void habilitar()
        {
            limpiar_text();
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            txtWeb.Enabled = true;
        }
        public void Limpiar()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtWeb.Clear();

        }
        void limpiar_text()
        {
            txtcodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtWeb.Text = "";

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_text();
            habilitar();
        }
        private void btbuscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)

            {
                SqlConnection con = srv.Conectar();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM laboratorio WHERE nombre LIKE '" + txtbuscar.Text + "%'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dglab.DataSource = ds.Tables[0];
            }
            if (radioButton2.Checked)
            {
                if (txtbuscar.Text != "")
                {
                    SqlConnection con = srv.Conectar();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM laboratorio WHERE cod_lab like '" + txtbuscar.Text + "%'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dglab.DataSource = ds.Tables[0];
                }
                else MessageBox.Show("Favor digite un valor");
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            SqlDataAdapter da = new SqlDataAdapter();


            String sql = "insert into laboratorio values ('" + txtNombre.Text + "','" + txtDireccion.Text + "'," + txtTelefono.Text + ",'" + txtEmail.Text + "','" + txtWeb.Text +  "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se ha insertado Correctamente");
            btbuscar_Click(sender, new EventArgs());
            con.Close();

            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            SqlConnection con = srv.Conectar();
            //String sql = " UPDATE laboratorio SET nombre = '" + txtNombre.Text + "',direccion ='" + txtDireccion.Text + "', telefono = " + txtTelefono.Text +
            //                                               ", email ='" + txtEmail.Text + "', web = '" + txtWeb.Text +
            //                                               "' WHERE cod_lab = " + txtcodigo.Text + "'";
            String sql = " UPDATE laboratorio SET 	nombre = '" +txtNombre.Text + "', direccion ='" + txtDireccion.Text + "',telefono = '" + txtTelefono.Text +
                                                           "',email = '" + txtEmail.Text + "',web = '" + txtWeb.Text + "' WHERE cod_lab = " + txtcodigo.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Modificacion Correcta");
            btbuscar_Click(sender, new EventArgs());
            con.Close();

            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            String sql = "DELETE FROM laboratorio WHERE cod_lab= " + txtcodigo.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se ha eliminado Correctamente");
            btbuscar_Click(sender, new EventArgs());
            con.Close();
        }
    }
}
