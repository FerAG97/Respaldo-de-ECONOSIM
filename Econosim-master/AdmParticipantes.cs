using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econosim
{
    public partial class AdmParticipantes : Form
    {
        public AdmParticipantes()
        {
            InitializeComponent();
        }
        CL_ConexiónBD conexion = new CL_ConexiónBD();
        SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ");
        SqlCommand cmd;
        public int i;

        public void llenar_tabla()
        {
            string query = "select * from usuario";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvparticipantesAdm.DataSource = dt;
        }

        private void AdmParticipantes_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            conexion.cargarDatos(dgvparticipantesAdm, "usuario");
        }

        private void dgvparticipantesAdm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = Convert.ToInt32(dgvparticipantesAdm.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtnombreAdm.Text = dgvparticipantesAdm.SelectedCells[1].Value.ToString();
            txtapellidoAdm.Text = dgvparticipantesAdm.SelectedCells[2].Value.ToString();
            txtusuarioAdm.Text = dgvparticipantesAdm.SelectedCells[3].Value.ToString();
            txtcontraAdm.Text = dgvparticipantesAdm.SelectedCells[4].Value.ToString();
            txtemailAdm.Text = dgvparticipantesAdm.SelectedCells[5].Value.ToString();
            txtgrupoAdm.Text = dgvparticipantesAdm.SelectedCells[6].Value.ToString();
            cmbTipodeUsu.Text = dgvparticipantesAdm.SelectedCells[7].Value.ToString();

        }

 

        private void label10_Click(object sender, EventArgs e)
        {
            Form menu = new Econosim.Menu();
            menu.Show();
            this.Hide();
        }

        private void circlebutton4_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "delete from usuario where nombre='" + txtnombreAdm.Text + "'";
            SqlCommand comando = new SqlCommand(query, con);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro Eliminado");
            llenar_tabla();
            con.Close();
        }

        private void circlebutton1_Click(object sender, EventArgs e)
        {
            txtnombreAdm.Clear();
            txtapellidoAdm.Clear();
            txtemailAdm.Clear();
            txtusuarioAdm.Clear();
            txtcontraAdm.Clear();
            txtgrupoAdm.Clear();
        }

        private void circlebutton3_Click(object sender, EventArgs e)
        {
            con.Open();

            if (txtnombreAdm.Text == String.Empty || txtapellidoAdm.Text == String.Empty || txtusuarioAdm.Text == String.Empty || txtemailAdm.Text == String.Empty || cmbTipodeUsu.Text == String.Empty)
            {
                MessageBox.Show("LLENE TODOS LOS CAMPOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "insert into usuario values('" + txtnombreAdm.Text + "','" + txtapellidoAdm.Text + "','" + txtusuarioAdm.Text + "'," + txtcontraAdm.Text + ",'" + txtemailAdm.Text + "','" + txtgrupoAdm.Text + "', '" + cmbTipodeUsu.Text + "')";
                SqlCommand comando = new SqlCommand(query, con);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Añadido");
                llenar_tabla();
                con.Close();
            }

        }

        private void circlebutton2_Click(object sender, EventArgs e)
        {
            /*con.Open();
           string query = "update usuario set nombre_de_usuario='" + txtusuarioAdm.Text + "', contrasena='" + txtcontraAdm.Text + "', emali='" + txtemailAdm.Text + "', numero_de_grupo='" + txtgrupoAdm.Text + "', apellido='" + txtapellidoAdm.Text + "', nombre='" + txtnombreAdm.Text + "'";
           SqlCommand comando = new SqlCommand(query, con);
           int cant;
           cant = comando.ExecuteNonQuery();
           if (cant > 0)
           {
               MessageBox.Show("Registro Modificado");
           }
           llenar_tabla();
           con.Close();*/
            try
            {
                if (txtnombreAdm.Text == String.Empty || txtapellidoAdm.Text == String.Empty || txtusuarioAdm.Text == String.Empty || txtemailAdm.Text == String.Empty || cmbTipodeUsu.Text == String.Empty)
                {
                    MessageBox.Show("Llene todos los campos");
                }
                else if (i != -1)
                {
                    String cod = dgvparticipantesAdm.CurrentRow.Cells[0].Value.ToString();
                    cmd = new SqlCommand("UPDATE usuario SET nombre_de_usuario=@usuario, contrasena=@contrasena, emali=@correo, numero_de_grupo=@grupo, apellido=@apellido, nombre=@Nombre, tipo_de_Usuario=@tipousu WHERE usuario_ID = @cod", conexion.sc);
                    cmd.Parameters.AddWithValue("@cod", i);
                    cmd.Parameters.AddWithValue("@usuario", txtusuarioAdm.Text);
                    cmd.Parameters.AddWithValue("@contrasena", txtcontraAdm.Text);
                    cmd.Parameters.AddWithValue("@correo", txtemailAdm.Text);
                    cmd.Parameters.AddWithValue("@grupo", txtgrupoAdm.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtapellidoAdm.Text);
                    cmd.Parameters.AddWithValue("@nombre", txtnombreAdm.Text);
                    cmd.Parameters.AddWithValue("@tipousu", cmbTipodeUsu.Text);

                    cmd.ExecuteNonQuery();
                    conexion.cargarDatos(dgvparticipantesAdm, "usuario");

                    MessageBox.Show("Registro Modificado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL MODIFICAR " + ex.Message);
            }
        }

        private void txtnombreAdm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtapellidoAdm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtusuarioAdm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras minusculas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcontraAdm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtemailAdm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 58 && e.KeyChar <= 63) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se acepta @, ., letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtgrupoAdm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 58 && e.KeyChar <= 63) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se acepta @, ., letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
