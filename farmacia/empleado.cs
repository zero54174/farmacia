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
    public partial class empleado : Form
    {
        Conexion srv = new Conexion();

        public empleado()
        {
            InitializeComponent();
        }

        private void empleado_Load(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("select * from empleado", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgempleado.DataSource = ds.Tables[0];
        }

        private void dgempleado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            habilitar();
            DataGridViewSelectedCellCollection cell = dgempleado.SelectedCells;
            DataGridViewSelectedRowCollection rows = dgempleado.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcodigo.Text = Convert.ToString(dgempleado[0, fila].Value);
                txtnombre.Text = Convert.ToString(dgempleado[1, fila].Value);
                txtpaterno.Text = Convert.ToString(dgempleado[2, fila].Value);
                txtmaterno.Text = Convert.ToString(dgempleado[3, fila].Value);
                txtdireccion.Text = Convert.ToString(dgempleado[4, fila].Value);
                txttelefono.Text = Convert.ToString(dgempleado[5, fila].Value);


                sw = true;

            }

        }

        public void habilitar()
        {
            limpiar_text();
            txtnombre.Enabled = true;
            txtpaterno.Enabled = true;
            txtmaterno.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;

        }
        public void Limpiar()
        {
            txtnombre.Clear();
            txtpaterno.Clear();
            txtmaterno.Clear();
            txtdireccion.Clear();
            txttelefono.Clear();

        }
        void limpiar_text()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtpaterno.Text = "";
            txtmaterno.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btbuscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)

            {
                SqlConnection con = srv.Conectar();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM empleado WHERE nombre LIKE '" + txtbuscar.Text + "%'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgempleado.DataSource = ds.Tables[0];
            }
            if (radioButton2.Checked)
            {
                if (txtbuscar.Text != "")
                {
                    SqlConnection con = srv.Conectar();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM empleado WHERE ci like '" + txtbuscar.Text + "%'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgempleado.DataSource = ds.Tables[0];
                }
                else MessageBox.Show("Favor digite un valor");
            }
        }

        private void btnuevo_Click(object sender, EventArgs e)
        {
            limpiar_text();
            habilitar();
        }

        private void btguardar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            String sql = "insert into empleado values ('" + txtnombre.Text + "', '" + txtpaterno.Text +
                                                       "', '" + txtmaterno.Text + "', '" + txtdireccion.Text +
                                                       "', " + txttelefono.Text +")";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se ha insertado Correctamente");
            btbuscar_Click(sender, new EventArgs());
            con.Close();

            Limpiar();
        }

        private void btmodificar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            String sql = " UPDATE empleado SET nombre = '"+ txtnombre.Text + "', '" + txtpaterno.Text +
                                                           "', '" + txtmaterno.Text + "', '" + txtdireccion.Text +
                                                           "', " + txttelefono.Text +
                                                           "WHERE ci = " + txtcodigo.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Modificacion Correcta");
            btbuscar_Click(sender, new EventArgs());
            con.Close();

            Limpiar();
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            String sql = "DELETE FROM empleado WHERE ci= " + txtcodigo.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se ha eliminado Correctamente");
            btbuscar_Click(sender, new EventArgs());
            con.Close();
        }
    }
}
