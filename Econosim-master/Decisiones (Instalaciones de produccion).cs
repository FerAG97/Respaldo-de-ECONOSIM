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
    public partial class Decisiones__Instalaciones_de_produccion_ : Form
    {
        

        SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ");
        public Decisiones__Instalaciones_de_produccion_()
        {
            
            InitializeComponent();
            cargar_produccion_marca();
            cargar_distribucion_y_almacenamiento();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form Decisiones = new Decisiones();
            Decisiones.Show();
            this.Hide();
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
        public void cargar_produccion_marca()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT ID_produccion,descripcion_produccion_de_marca FROM produccion_marca", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["descripcion_produccion_de_marca"] = "Seleccione";
            dt.Rows.Add(fila);

            comboBox1.ValueMember = "ID_produccion";
            comboBox1.DisplayMember = "ID_produccion";
            comboBox1.DataSource = dt;
        }

       

        public void cargar_distribucion_y_almacenamiento()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT almacenamiento_ID,localizacion FROM distribucion_y_almacenamiento", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["localizacion"] = "Seleccione";
            dt.Rows.Add(fila);

            comboBox2.ValueMember = "almacenamiento_ID";
            comboBox2.DisplayMember = "almacenamiento_ID";
            comboBox2.DataSource = dt;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            /* codificacion */
            try
            {
                if (this.txt_instalacion.Text == String.Empty || txt_valor.Text == String.Empty || comboBox1.Text == String.Empty || comboBox2.Text == String.Empty)
                {
                    MessageBox.Show("LLENE TODOS LOS CAMPOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true "))
                    {
                        SqlCommand cmd = new SqlCommand("Insert Into instalacion_de_produccion (Descripcion_de_instalacion_de_produccion, valor_de_instalacion, ID_produccion, almacenamiento_ID) values ('" + txt_instalacion.Text + "','" + Convert.ToInt32(txt_valor.Text) + "','" + Convert.ToInt32(comboBox1.Text) + "','" + Convert.ToInt32(comboBox2.Text) + "')", con);



                        con.Open();

                        cmd.ExecuteNonQuery();

                        cmd.CommandType = CommandType.Text;

                        MessageBox.Show("Registro Insertado");

                        txt_instalacion.Clear();
                        txt_valor.Clear();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }


        }

        private void label8_Click(object sender, EventArgs e)
        {
            label8.Text = (this.comboBox1.SelectedItem.ToString());
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox1.Text;
            

        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            insalacion_de_produccion__imprimir_1 insalacion_de_produccion__imprimir = new insalacion_de_produccion__imprimir_1();
            insalacion_de_produccion__imprimir.Show();
            this.Hide();
        }

        private void txt_instalacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txt_valor_KeyPress(object sender, KeyPressEventArgs e)
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

