using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Econosim
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

        }

        CL_ConexiónBD conexion = new CL_ConexiónBD();
        SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ");

        public void logear(string usuarioy, string contrasena)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT nombre, tipo_de_Usuario FROM usuario WHERE nombre_de_usuario = @usuario AND contrasena = @password", con);
                cmd.Parameters.AddWithValue("usuario", usuarioy);
                cmd.Parameters.AddWithValue("password", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {

                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Usuario")
                    {
                        Menu ventana = new Menu(dt.Rows[0][0].ToString());
                        ventana.Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        Administrador admin = new Administrador(dt.Rows[0][0].ToString());
                        admin.Show();

                    }
                }
                else
                {
                    MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTA");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void controlBotones()
        {
            if (txtUsuario.Text.Trim() != string.Empty && txtUsuario.Text.All(Char.IsLetter))
            {
                btnLogin.Enabled = true;
                errorProvider1.SetError(txtUsuario, "");
            }
            else if(txtUsuario.Text==string.Empty)
            {
                if (!(txtUsuario.Text.All(Char.IsLetter)))
                {
                    errorProvider1.SetError(txtUsuario, "El usuario sólo debe contener letras");

                }
                else
                {
                    errorProvider1.SetError(txtUsuario, "Debe introducir su usuario");
                }

                btnLogin.Enabled = false;
               

            }

            if (txtContrasena.Text.Trim() != string.Empty)
            {
                errorProvider1.SetError(txtContrasena, "");
            }
            else if (txtContrasena.Text == string.Empty)
            {

                errorProvider1.SetError(txtContrasena, "Debe introducir su contraseña");
                
                btnLogin.Enabled = false;
                

            }


        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            conexion.abrir();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            controlBotones();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

           //logear(this.txtUsuario.Text, this.txtContrasena.Text);

            SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ");
            String query = "SELECT * FROM usuario WHERE nombre_de_usuario='" + txtUsuario.Text + "'AND contrasena='" + txtContrasena.Text+ "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

           // SqlDataReader sdr = cmd.ExecuteReader();

            if (dt.Rows.Count == 1)
            {
                //dt.Load(sdr);
                DataRow usuario = dt.Rows[0];

                this.Hide();
               Menu ventanaLogin = new Menu();
               ventanaLogin.ShowDialog();
            
                InicioSesión.idusuario = usuario["usuario_ID"].ToString();
                InicioSesión.nombre = usuario["nombre"].ToString();
                InicioSesión.apellido = usuario["apellido"].ToString();
                InicioSesión.correo = usuario["emali"].ToString();
                InicioSesión.equipo = usuario["numero_de_grupo"].ToString();
                InicioSesión.tipo = usuario["tipo_de_Usuario"].ToString();

            }
            else
            {
                MessageBox.Show("NOMBRE O CONTRASEÑA INVALIDOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      

        }

        private void linklblReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ReinicioContrasena reinicio = new ReinicioContrasena())
                reinicio.ShowDialog();
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            txtContrasena.MaxLength = 10;
            controlBotones();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearUsuario crear = new CrearUsuario();
            crear.Show();
            this.Hide();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras minusculas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }
    }
}
