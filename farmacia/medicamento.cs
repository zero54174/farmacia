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
    public partial class medicamento : Form
    {
        Conexion srv = new Conexion();
        public medicamento()
        {
            InitializeComponent();
        }

        private void medicamento_Load(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("select * from medicamento", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgmedicamento.DataSource = ds.Tables[0];
        }

        private void dgmedicamento_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            habilitar();
            DataGridViewSelectedCellCollection cell = dgmedicamento.SelectedCells;
            DataGridViewSelectedRowCollection rows = dgmedicamento.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcodigo.Text = Convert.ToString(dgmedicamento[0, fila].Value);
                txtNombre.Text = Convert.ToString(dgmedicamento[1, fila].Value);
                txtPrecio.Text = Convert.ToString(dgmedicamento[2, fila].Value);
                txtStock.Text = Convert.ToString(dgmedicamento[3, fila].Value);
                txtCategoria.Text = Convert.ToString(dgmedicamento[4, fila].Value);
                
                

                sw = true;

            }

        }

        public void habilitar()
        {
            limpiar_text();
            txtNombre.Enabled = true;
            txtCategoria.Enabled = true;
            txtStock.Enabled = true;
            txtPrecio.Enabled = true;

        }
        public void Limpiar()
        {
            txtNombre.Clear();
            txtCategoria.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            
        }
        void limpiar_text()
        {
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtStock.Text = "";
            txtPrecio.Text = "";

        }

        private void btbuscar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM medicamento WHERE nombre LIKE '" + txtbuscar.Text + "%'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgmedicamento.DataSource = ds.Tables[0];

        }
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM medicamento WHERE nombre LIKE '" + txtbuscar.Text + "%'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgmedicamento.DataSource = ds.Tables[0];

        }

        private void btmodificar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            String sql = " UPDATE medicamento SET nombre = '" + txtNombre.Text + "', precio ='" + txtPrecio.Text + "', stock = '" + txtStock.Text + "', cod_cat =" + txtCategoria.Text +
                                                     "WHERE cod_med = " + txtcodigo.Text;


            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Modificacion Correcta");
            btbuscar_Click(sender, new EventArgs());
            con.Close();

            Limpiar();

        }

        private void btnuevo_Click(object sender, EventArgs e)
        {
            limpiar_text();
            habilitar();
        }

        private void btguardar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            SqlDataAdapter da = new SqlDataAdapter();


            String sql = "insert into medicamento values ('" + txtNombre.Text + "'," + txtPrecio.Text + "," + txtStock.Text + "," + txtCategoria.Text + ")";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se ha insertado Correctamente");
            btbuscar_Click(sender, new EventArgs());
            con.Close();

            Limpiar();
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            String sql = "DELETE FROM medicamento WHERE cod_med = " + txtcodigo.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se ha eliminado Correctamente");
            btbuscar_Click(sender, new EventArgs());
            con.Close();
        }
    }
}
