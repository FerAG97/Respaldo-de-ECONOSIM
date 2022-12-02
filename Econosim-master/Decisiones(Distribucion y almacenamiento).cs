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
    public partial class Decisiones_Distribucion_y_almacenamiento_ : Form
    {
        public Decisiones_Distribucion_y_almacenamiento_()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Decisiones_Produccion_de_Marca_ decisiones_Produccion_De_Marca_ = new Decisiones_Produccion_de_Marca_();
            decisiones_Produccion_De_Marca_.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Decisiones_compensacion_ decisiones_compensacion_ = new Decisiones_compensacion_();
            decisiones_compensacion_.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Decisiones__Instalaciones_de_produccion_ decisiones__Instalaciones_De_Produccion = new Decisiones__Instalaciones_de_produccion_();
            decisiones__Instalaciones_De_Produccion.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Decisiones_Finanzas_y_flujo_de_caja_ decisiones_Finanzas_Y_Flujo_de_caja_ = new Decisiones_Finanzas_y_flujo_de_caja_();
            decisiones_Finanzas_Y_Flujo_de_caja_.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Decisiones_Finanzas_y_flujo_de_caja_ decisiones_Finanzas_Y_Flujo_de_caja_ = new Decisiones_Finanzas_y_flujo_de_caja_();
            decisiones_Finanzas_Y_Flujo_de_caja_.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* codificacion */

            try
            {
                if(this.txt_almacenamiento.Text == String.Empty || txt_localizacion.Text == String.Empty)
                {
                    MessageBox.Show("LLENE TODOS LOS CAMPOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true "))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO distribucion_y_almacenamiento (descripcion_de_almacenamiento, localizacion) values ('" + txt_almacenamiento.Text + "','" + txt_localizacion.Text + "')", con);

                        con.Open();

                        cmd.ExecuteNonQuery();

                        cmd.CommandType = CommandType.Text;

                        MessageBox.Show("Registro Insertado");

                        txt_almacenamiento.Clear();
                        txt_localizacion.Clear();
                    }
                        
                        
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            Distribucion_y_almacenamiento__imprimir_ distribucion_Y_Almacenamiento__Imprimir = new Distribucion_y_almacenamiento__imprimir_();
            distribucion_Y_Almacenamiento__Imprimir.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form Decisiones = new Decisiones();
            Decisiones.Show();
            this.Hide();
        }

        private void Decisiones_Distribucion_y_almacenamiento__Load(object sender, EventArgs e)
        {

        }

        private void txt_almacenamiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_localizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
