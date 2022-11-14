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
    public partial class Cliente : Form
    {
        private SqlCommand command;

        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-3J24IC0\\SQLEX;integrated security=yes; database=bd_farmacia");
            SqlDataAdapter da = new SqlDataAdapter("select*from cliente", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgcliente.DataSource = ds.Tables[0];
        }

        private void dgcliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            habilitar();
            DataGridViewSelectedCellCollection cell = dgcliente.SelectedCells;
            DataGridViewSelectedRowCollection rows = dgcliente.SelectedRows;
            IEnumerator iter = cell.GetEnumerator(); bool sw = false;
            while (iter.MoveNext() && !sw)
            {
                DataGridViewTextBoxCell dgvtxt = (DataGridViewTextBoxCell)iter.Current;
                int columna = dgvtxt.ColumnIndex;
                int fila = dgvtxt.RowIndex;
                txtcodigo.Text = Convert.ToString(dgcliente[0, fila].Value);
                txtnombre.Text = Convert.ToString(dgcliente[1, fila].Value);
                txtpaterno.Text = Convert.ToString(dgcliente[2, fila].Value);
                txtmaterno.Text = Convert.ToString(dgcliente[3, fila].Value);
                txttelefono.Text = Convert.ToString(dgcliente[4, fila].Value);
                txtdireccion.Text = Convert.ToString(dgcliente[5, fila].Value);
                txtcorreo.Text = Convert.ToString(dgcliente[6, fila].Value);
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
            txtcorreo.Enabled = true;
        }
        public void Limpiar()
        {
            txtdireccion.Clear();
            txtpaterno.Clear();
            txtmaterno.Clear();
            txtcorreo.Clear();
            txttelefono.Clear();
            txtnombre.Clear();
        }
        void limpiar_text()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtpaterno.Text = "";
            txtmaterno.Text = "";
            txttelefono.Text = "";
            txtdireccion.Text = "";
            txtcorreo.Text = "";
        }

        private void btbuscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)

            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-3J24IC0\\SQLEX;integrated security=yes; database=bd_farmacia");
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM cliente WHERE nombre LIKE '" + txtbuscar.Text + "%'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgcliente.DataSource = ds.Tables[0];
            }
            if (radioButton2.Checked)
            {
                if (txtbuscar.Text!="") {
                    SqlConnection con = new SqlConnection("data source=DESKTOP-3J24IC0\\SQLEX;integrated security=yes; database=bd_farmacia");
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM cliente WHERE cod_clt like '" + txtbuscar.Text + "%'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgcliente.DataSource = ds.Tables[0];
                }
                else MessageBox.Show("Favor digite un valor");
            }

        }

        private void btmodificar_Click(object sender, EventArgs e)
        { 
            SqlConnection con = new SqlConnection("data source=DESKTOP-3J24IC0\\SQLEX;integrated security=yes; database=bd_farmacia");
            SqlDataAdapter da = new SqlDataAdapter();

            
            String sql = "UPDATE cliente SET nombre = '" + txtnombre.Text + "', paterno = '" + txtpaterno.Text +
                                                    "', materno = '" + txtmaterno.Text + "', direccion = '" + txtdireccion.Text +
                                                    "', telefono = '" + txttelefono.Text + "', correo = '" + txtcorreo.Text
                                                    + "' WHERE cod_clt =  " + txtcodigo.Text;
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
    }
}
