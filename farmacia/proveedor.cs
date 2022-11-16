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
    public partial class proveedor : Form
    {
        Conexion srv = new Conexion();
        public proveedor()
        {
            InitializeComponent();
            listar_lab();
        }

        private void proveedor_Load(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("select * from proveedor", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgprov.DataSource = ds.Tables[0];
        }
        private void dgprov_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            habilitar();
            DataGridViewSelectedCellCollection cell = dgprov.SelectedCells;
            DataGridViewSelectedRowCollection rows = dgprov.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcodigo.Text = Convert.ToString(dgprov[0, fila].Value);
                txtnombre.Text = Convert.ToString(dgprov[1, fila].Value);
                txtnit.Text = Convert.ToString(dgprov[2, fila].Value);
                txtdireccion.Text = Convert.ToString(dgprov[3, fila].Value);
                txttelefono.Text = Convert.ToString(dgprov[4, fila].Value);
                txtlab.Text = Convert.ToString(dgprov[5, fila].Value);
                //cbolab.Text = Convert.ToString(dgprov[6, fila].Value);


                sw = true;

            }
            limpiar_text();
            txtnombre.Enabled = true;
            txtnit.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            txtlab.Enabled = true;
        }
        public void habilitar()
        {
            limpiar_text();
            txtnombre.Enabled = true;
            txtnit.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            txtlab.Enabled = true;

        }
        public void Limpiar()
        {
            txtnombre.Clear();
            txtnit.Clear();
            txtdireccion.Clear();
            txttelefono.Clear();
            txtlab.Clear();

        }
        void limpiar_text()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtnit.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtlab.Text = "";

        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (rdbnombre.Checked)

            {
                SqlConnection con = srv.Conectar();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM proveedor WHERE nombre LIKE '" + txtbuscar.Text + "%'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgprov.DataSource = ds.Tables[0];
            }
            if (rdbcodigo.Checked)
            {
                if (txtbuscar.Text != "")
                {
                    SqlConnection con = srv.Conectar();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM proveedor WHERE cod_provee like '" + txtbuscar.Text + "%'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgprov.DataSource = ds.Tables[0];
                }
                else MessageBox.Show("Favor digite un valor");
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar_text();
            habilitar();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-3J24IC0\\SQLEX;integrated security=yes; database=bd_farmacia");
            SqlDataAdapter da = new SqlDataAdapter();


            String sql = "insert into proveedor values ('" + txtnombre.Text + "', '" + txtnit.Text +
                                                       "', '" + txtdireccion.Text + "', '" + txttelefono.Text +
                                                       "', " + txtlab.Text + ")";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se ha insertado Correctamente");
            btnbuscar_Click(sender, new EventArgs());
            con.Close();

            Limpiar();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            String sql = " UPDATE proveedor SET nombre = '" + txtnombre.Text + "', '" + txtnit.Text +
                                                           "', '" + txtdireccion.Text + "', '" + txttelefono.Text +
                                                           "', " + txtlab.Text +
                                                           "WHERE cod_provee = " + txtcodigo.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Modificacion Correcta");
            btnbuscar_Click(sender, new EventArgs());
            con.Close();

            Limpiar();
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = srv.Conectar();
            String sql = "DELETE FROM proveedor WHERE cod_provee= " + txtcodigo.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se ha eliminado Correctamente");
            btnbuscar_Click(sender, new EventArgs());
            con.Close();
        }

        private void listar_lab()
        {
            SqlConnection con = srv.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("select * from laboratorio", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //cbolab.Items.Insert(0,"Seleccione");
            foreach (DataRow reg in ds.Tables[0].Rows)
                cbolab.Items.Add(reg[1].ToString().Trim());


            //DataRow r = ds.Tables[0].Rows[0];
            //cbolab.Text = r[1].ToString();
        }
    }
}
