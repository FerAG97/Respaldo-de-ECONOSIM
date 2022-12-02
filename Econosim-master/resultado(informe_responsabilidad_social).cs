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
    public partial class resultado_informe_responsabilidad_social_ : Form
    {
        string SSCadenaConexion = "Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ";
        public resultado_informe_responsabilidad_social_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }



        private void resultado_informe_responsabilidad_social__Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenargrid(SSCadenaConexion);
        }

        private DataTable llenargrid(string CadenaConexion)
        {
            DataTable tlb = new DataTable();
            SqlConnection sqlcon1 = new SqlConnection(CadenaConexion);
            SqlCommand sqlcom1;
            SqlDataAdapter sqlData1;


            sqlcon1.Open();
            sqlcom1 = new SqlCommand("responsabilidad", sqlcon1);
            sqlData1 = new SqlDataAdapter(sqlcom1);
            sqlcom1.CommandType = CommandType.StoredProcedure;
            sqlData1.Fill(tlb);
            sqlcon1.Close();
            return tlb;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Resultados resultados = new Resultados();
            resultados.Show();
            this.Hide();
        }

        private void circlebutton5_Click(object sender, EventArgs e)
        {
            /* codificacion */

            try
            {
                if (this.textBox1.Text == String.Empty || textBox2.Text == String.Empty)
                {
                    MessageBox.Show("LLENE TODOS LOS CAMPOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true "))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO responsabilidad_social(descripcion_responsabilidad_social, valor_responsabilidad_social) values ('" + textBox1.Text + "','" + Convert.ToInt32(textBox2.Text) + "')", con);

                        con.Open();

                        cmd.ExecuteNonQuery();

                        cmd.CommandType = CommandType.Text;

                        MessageBox.Show("Registro Insertado");

                        textBox1.Clear();
                        textBox2.Clear();
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
