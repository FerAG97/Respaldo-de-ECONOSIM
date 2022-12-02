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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Econosim
{
    public partial class Decisiones_Produccion_de_Marca_ : Form
    {
        /* prueba 1 */
        public Decisiones_Produccion_de_Marca_()
        {
            InitializeComponent();

        }
        

        CL_ConexiónBD con = new CL_ConexiónBD();

        private void button3_Click(object sender, EventArgs e)
        {
            Decisiones_compensacion_ decisiones_compensacion_ = new Decisiones_compensacion_();
            decisiones_compensacion_.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form Decisiones = new Decisiones();
            Decisiones.Show();
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
            Decisiones_Distribucion_y_almacenamiento_ decisiones_Distribucion_Y_Almacenamiento_ = new Decisiones_Distribucion_y_almacenamiento_();
            decisiones_Distribucion_Y_Almacenamiento_.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Decisiones_Finanzas_y_flujo_de_caja_ decisiones_Finanzas_Y_Flujo_de_caja_ = new Decisiones_Finanzas_y_flujo_de_caja_();
            decisiones_Finanzas_Y_Flujo_de_caja_.Show();
            this.Hide();
        }

        private void btn_generar1_Click(object sender, EventArgs e)
        {
            /* codificacion */
            try
            {
                if (this.txt_cantidad.Text == String.Empty || txt_marca.Text == String.Empty || txt_total.Text == String.Empty)
                {
                    MessageBox.Show("LLENE TODOS LOS CAMPOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true "))
                    {
                        SqlCommand cmd = new SqlCommand("Insert Into produccion_marca (descripcion_produccion_de_marca, cantidad_produccion_de_marca, valor_produccion) values ('" + txt_marca.Text + "','" + Convert.ToInt32(txt_cantidad.Text) + "','" + Convert.ToInt32 (txt_total.Text) + "')", con);

                        con.Open();

                        cmd.ExecuteNonQuery();

                        cmd.CommandType = CommandType.Text;

                        MessageBox.Show("Registro Insertado");

                        txt_cantidad.Clear();
                        txt_marca.Clear();
                        txt_total.Clear();
                    }
                }
/* */

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void Decisiones_Produccion_de_Marca__Load(object sender, EventArgs e)
        {
            con.abrir();
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            produccion_de_marca__imprimir_ produccion_De_Marca__ = new produccion_de_marca__imprimir_();
            produccion_De_Marca__.Show();
            this.Hide();
        }

        private void txt_marca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
