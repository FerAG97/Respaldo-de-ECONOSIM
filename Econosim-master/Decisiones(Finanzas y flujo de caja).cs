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
    public partial class Decisiones_Finanzas_y_flujo_de_caja_ : Form
    {
        SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ");
        public Decisiones_Finanzas_y_flujo_de_caja_()
        {
            InitializeComponent();
            cargar_id_instalacion();
            cargar_id_estado();
            cargar_id_informe_mercado();
            cargar_id_informe_costes();
            cargar_id_compesacion();
            cargar_id_rrhh();
            cargar_ID_ratio();
            ID_responsabilidad_social();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Decisiones_Distribucion_y_almacenamiento_ decisiones_Distribucion_Y_Almacenamiento_ = new Decisiones_Distribucion_y_almacenamiento_();
            decisiones_Distribucion_Y_Almacenamiento_.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Decisiones__Instalaciones_de_produccion_ decisiones__Instalaciones_De_Produccion = new Decisiones__Instalaciones_de_produccion_();
            decisiones__Instalaciones_De_Produccion.Show();
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

        private void label3_Click(object sender, EventArgs e)
        {
            Form Decisiones = new Decisiones();
            Decisiones.Show();
            this.Hide();
        }

        public void cargar_id_instalacion()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID_instalacion,Descripcion_de_instalacion_de_produccion FROM instalacion_de_produccion", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["Descripcion_de_instalacion_de_produccion"] = "seleccione";
            dt.Rows.Add(fila);

            comboBox1.ValueMember = "ID_instalacion";
            comboBox1.DisplayMember = "ID_instalacion";
            comboBox1.DataSource = dt;

        }

        public void cargar_id_estado()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID_estado, descripcion_de_estado FROM estado_financiero", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["descripcion_de_estado"] = "seleccione";
            dt.Rows.Add(fila);

            comboBox2.ValueMember = "ID_estado";
            comboBox2.DisplayMember = "ID_estado";
            comboBox2.DataSource = dt;
        }

        public void cargar_id_informe_mercado()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID_informe_mercado, descripcion_informe_mercado FROM informe_de_mercado", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["descripcion_informe_mercado"] = "seleccione";

            comboBox3.ValueMember = "ID_informe_mercado";
            comboBox3.DisplayMember = "ID_informe_mercado";
            comboBox3.DataSource = dt;
        }

        public void cargar_id_informe_costes()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID_informe_costes, descripcion_costes FROM informe_de_costes", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["descripcion_costes"] = "seleccione";

            comboBox4.ValueMember = "ID_informe_costes";
            comboBox4.DisplayMember = "ID_informe_costes";
            comboBox4.DataSource = dt;
        }

        public void cargar_id_compesacion()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID_compensacion, descripcion_de_recompensa FROM compensacion", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["descripcion_de_recompensa"] = "seleccione";

            comboBox5.ValueMember = "ID_compensacion";
            comboBox5.DisplayMember = "ID_compensacion";
            comboBox5.DataSource = dt;
        }

        public void cargar_id_rrhh()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID_informe_rrhh, descripcion_de_rrhh FROM informe_de_rrhh", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["descripcion_de_rrhh"] = "seleccione";

            comboBox6.ValueMember = "ID_informe_rrhh";
            comboBox6.DisplayMember = "ID_informe_rrhh";
            comboBox6.DataSource = dt;
        }

        public void cargar_ID_ratio()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID_ratio, descripcion_de_ratio FROM ratio", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["descripcion_de_ratio"] = "seleccione";

            comboBox7.ValueMember = "ID_ratio";
            comboBox7.DisplayMember = "ID_ratio";
            comboBox7.DataSource = dt;
        }

        public void ID_responsabilidad_social()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID_responsabilidad_social, descripcion_responsabilidad_social FROM responsabilidad_social", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["descripcion_responsabilidad_social"] = "seleccione";

            comboBox8.ValueMember = "ID_responsabilidad_social";
            comboBox8.DisplayMember = "ID_responsabilidad_social";
            comboBox8.DataSource = dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /* codificacion pendiente */

            try
            {
                if (this.comboBox1.Text == String.Empty || comboBox2.Text == String.Empty || comboBox3.Text == String.Empty || comboBox4.Text == String.Empty || comboBox5.Text == String.Empty || textBox1.Text == String.Empty || comboBox6.Text == String.Empty || comboBox7.Text == String.Empty || comboBox8.Text == String.Empty)
                {
                    MessageBox.Show("LLENE TODOS LOS CAMPOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true "))
                    {
                        SqlCommand cmd = new SqlCommand ("INSERT INTO finanza_flujo_de_caja (ID_instalacion, ID_estado, ID_informe_mercado, ID_informe_costes, ID_compensacion, finanza_total, ID_informe_rrhh, ID_ratio, ID_responsabilidad_social) values ('" + Convert.ToInt32(comboBox1.Text) + "','" + Convert.ToInt32(comboBox2.Text) + "','" + Convert.ToInt32(comboBox3.Text) + "','" + Convert.ToInt32(comboBox4.Text) + "','" + Convert.ToInt32(comboBox5.Text) + "','" + Convert.ToInt32(textBox1.Text) + "','" + Convert.ToInt32(comboBox6.Text) + "','" + Convert.ToInt32(comboBox7.Text) + "','" + Convert.ToInt32(comboBox8.Text) + "')",  con);

                        con.Open();

                        cmd.ExecuteNonQuery();

                        cmd.CommandType = CommandType.Text;

                        MessageBox.Show("Registro Insertado");

                        textBox1.Clear();
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
            Finanzas_y_flujo_de_caja__imprimir_ finanzas_Y_Flujo_De = new Finanzas_y_flujo_de_caja__imprimir_();
            finanzas_Y_Flujo_De.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
