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
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
        }

        CL_ConexiónBD conexiónBD = new CL_ConexiónBD();

        private void button6_Click(object sender, EventArgs e)
        {
            Form Inicio = new Inicio();
            Inicio.Show();
            this.Close();
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            lblNombrePerfil.Text = InicioSesión.nombre + " " + InicioSesión.apellido;
            lblidUsuario.Text = InicioSesión.idusuario;
            lblNomPerfil.Text = InicioSesión.nombre+" "+InicioSesión.apellido;
            lblCorreoPerfil.Text = InicioSesión.correo;
            lblEquipoPerfil.Text = InicioSesión.equipo;

        }

        private void Perfil_Shown(object sender, EventArgs e)
        {
            lblNombrePerfil.Text = InicioSesión.nombre + " " + InicioSesión.apellido;
            lblidUsuario.Text = InicioSesión.idusuario;
            lblNomPerfil.Text = InicioSesión.nombre + " " + InicioSesión.apellido;
            lblCorreoPerfil.Text = InicioSesión.correo;
            lblEquipoPerfil.Text = InicioSesión.equipo;

            conexiónBD.cargarDatosEquipo(dataGridView1, "usuario", InicioSesión.equipo);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form Menu = new Menu();
            Menu.Show();
            this.Close();
        }
    }
}
