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
    public partial class resultados_informacion_de_costos_ : Form
    {
        string SSCadenaConexion = "Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ";

        SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ");
        public resultados_informacion_de_costos_()
        {
            InitializeComponent();
            ID_responsabilidad_social();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void resultados_informacion_de_costos__Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenargrid(SSCadenaConexion);
            dataGridView2.DataSource = llenargrid2(SSCadenaConexion);
        }


        private DataTable llenargrid(string CadenaConexion)
        {
            DataTable tlb = new DataTable();
            SqlConnection sqlcon1 = new SqlConnection(CadenaConexion);
            SqlCommand sqlcom1;
            SqlDataAdapter sqlData1;


            sqlcon1.Open();
            sqlcom1 = new SqlCommand("costes_totales", sqlcon1);
            sqlData1 = new SqlDataAdapter(sqlcom1);
            sqlcom1.CommandType = CommandType.StoredProcedure;
            sqlData1.Fill(tlb);
            sqlcon1.Close();
            return tlb;
        }
        private DataTable llenargrid2(string CadenaConexion)
        {
            DataTable tlb = new DataTable();
            SqlConnection sqlcon1 = new SqlConnection(CadenaConexion);
            SqlCommand sqlcom1;
            SqlDataAdapter sqlData1;


            sqlcon1.Open();
            sqlcom1 = new SqlCommand("informe_costo", sqlcon1);
            sqlData1 = new SqlDataAdapter(sqlcom1);
            sqlcom1.CommandType = CommandType.StoredProcedure;
            sqlData1.Fill(tlb);
            sqlcon1.Close();
            return tlb;
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

            comboBox1.ValueMember = "ID_responsabilidad_social";
            comboBox1.DisplayMember = "ID_responsabilidad_social";
            comboBox1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Resultados resultados = new Resultados();
            resultados.Show();
            this.Hide();
        }

        private void circlebutton2_Click(object sender, EventArgs e)
        {
            /* codificacion */

            try
            {
                if (this.comboBox1.Text == String.Empty || textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty)
                {
                    MessageBox.Show("LLENE TODOS LOS CAMPOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true "))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO informe_de_costes(descripcion_costes, valor_costes, total_costes, ID_responsabilidad_social) values ('" + textBox1.Text + "','" + Convert.ToInt32(textBox2.Text) + "','" + Convert.ToInt32(textBox3.Text) + "','" + Convert.ToInt32(comboBox1.Text) + "')", con);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        cmd.CommandType = CommandType.Text;

                        MessageBox.Show("Registro Insertado");

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
