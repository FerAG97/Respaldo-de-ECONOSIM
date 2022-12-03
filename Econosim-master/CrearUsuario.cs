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
    public partial class CrearUsuario : Form
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }
        SqlCommand command;
        CL_ConexiónBD conexiónBD = new CL_ConexiónBD();

        private void CrearUsuario_Load(object sender, EventArgs e)
        {
            conexiónBD.abrir();
        }

     

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT nombre_de_usuario, emali from usuario WHERE nombre_de_usuario= '" + txtNuevoUser.Text + "' OR emali= '" + txtNuevoCorreo.Text + "'", conexiónBD.sc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("NOMBRE DE USUARIO O CORREO YA EXISTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (this.txtNuevoNombre.Text == String.Empty || txtNuevoApellido.Text == String.Empty || txtNuevoCorreo.Text == String.Empty || txtNuevoUser.Text == String.Empty || txtNuevaContra.Text == String.Empty || txtConfirmacion.Text == String.Empty || txtNumEquipo.Text == String.Empty ||cmbTipoUsuario.Text==String.Empty)
                    {
                        MessageBox.Show("LLENE TODOS LOS CAMPOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtNuevaContra.Text.Trim() == txtConfirmacion.Text.Trim() && txtNuevaContra.TextLength > 8 && txtNuevaContra.TextLength < 15 && txtNuevoNombre.TextLength > 2 && txtNuevoNombre.TextLength < 35 && txtNuevoUser.TextLength > 5 && txtNuevoUser.TextLength < 15)
                        {
                            command = new SqlCommand("INSERT INTO usuario (nombre, apellido, nombre_de_usuario, contrasena, emali, numero_de_grupo, tipo_de_Usuario)" + "VALUES('" + txtNuevoNombre.Text + "','" + txtNuevoApellido.Text + "','" + txtNuevoUser.Text + "','" + txtNuevaContra.Text + "','" + txtNuevoCorreo.Text + "','" + txtNumEquipo.Text + "','"+cmbTipoUsuario.Text+"')", conexiónBD.sc);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Registro Insertado");

                            txtNuevoNombre.Clear();
                            txtNuevoApellido.Clear();
                            txtNuevoCorreo.Clear();
                            txtNuevoUser.Clear();
                            txtNuevaContra.Clear();
                            txtConfirmacion.Clear();
                            txtNumEquipo.Clear();
                            txtConfirmacion.Clear();
                            txtNuevoNombre.Focus();
                        }
                        else
                        {
                            if (txtNuevaContra.Text.Trim() != txtConfirmacion.Text.Trim()) 
                            {
                                MessageBox.Show("LAS CONTRASEÑAS NO COINCIDEN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNuevaContra.Clear();
                                txtConfirmacion.Clear();
                                
                            }
                            else if (txtNuevaContra.TextLength < 8 || txtNuevaContra.TextLength>15)
                            {
                                MessageBox.Show("LA LONGITUD DE CONTRASEÑA DEBE SER MAYOR A 8 Y MENOR A 15 CARACTERES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNuevaContra.Clear();
                                txtConfirmacion.Clear();


                            }
                            else if(txtNuevoNombre.TextLength < 2 && txtNuevoNombre.TextLength > 35)
                            {
                                MessageBox.Show("LA LONGITUD DE NOMBRES DEBE SER MAYOR A 2 Y MENOR A 35 CARACTERES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNuevoNombre.Clear();

                            }
                            else if(txtNuevoUser.TextLength < 5 && txtNuevoUser.TextLength > 15) 
                            {
                                MessageBox.Show("LA LONGITUD DE USUARIO DEBE SER MAYOR A 2 Y MENOR A 15 CARACTERES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNuevoUser.Clear();
                            }
                        }



                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNuevoNombre.Clear();
            txtNuevoApellido.Clear();
            txtNuevoCorreo.Clear();
            txtNuevoUser.Clear();
            txtNuevaContra.Clear();
            txtNumEquipo.Clear();
            txtNuevoNombre.Focus();
        }


        private void txtNuevoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNuevoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNuevoCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 58 && e.KeyChar <= 63) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se acepta @, ., letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtNuevoUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras minusculas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNuevaContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtConfirmacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNumEquipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNuevaContra_TextChanged(object sender, EventArgs e)
        {
            txtNuevaContra.MaxLength = 15;
        }

        private void txtConfirmacion_TextChanged(object sender, EventArgs e)
        {
            txtNuevaContra.MaxLength = 15;
        }

        private void txtNuevoNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
