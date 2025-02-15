﻿using System;
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
    public partial class compesacion_y_beneficios__imprimir_ : Form
    {
        public compesacion_y_beneficios__imprimir_()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ");

        private void compesacion_y_beneficios__imprimir__Load(object sender, EventArgs e)
        {
            string consulta = "Select * From compensacion";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, con);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection("Data Source = DESKTOP-LPK0UAA; Initial Catalog = proyecto_grupo_#3; Integrated security = true ");

                SqlCommand cmd = new SqlCommand("delete from compensacion where ID_compensacion=" + dataGridView1.SelectedRows[0].Cells[0].Value , con);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.ExecuteNonQuery();

                MessageBox.Show("Registro Eliminado");

                con.Close();    


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Decisiones_compensacion_ decisiones_compensacion_ = new Decisiones_compensacion_();
            decisiones_compensacion_.Show();
            this.Hide();
        }

        public void exportaraexcel(DataGridView tabla)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int IndiceColumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {

                IndiceColumna++;

                excel.Cells[1, IndiceColumna] = col.Name;

            }

            int IndeceFila = 0;

            foreach (DataGridViewRow row in tabla.Rows)
            {

                IndeceFila++;

                IndiceColumna = 0;

                foreach (DataGridViewColumn col in tabla.Columns)
                {

                    IndiceColumna++;

                    excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;

                }

            }

            excel.Visible = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbl_espere.Visible = true;
            lbl_espere.Text = "Exportando datos";
            exportaraexcel(dataGridView1);
        }


        /* Bitmap objBmp = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(objBmp, new Rectangle(0,0, this.dataGridView1.Width, this.dataGridView1.Height));

            e.Graphics.DrawImage(objBmp, 250, 90); */


        /*
                private void printDocument(object sender, System.Drawing.Printing.PrintPageEventArgs e)
                {

                }
        */

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap objBmp = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(objBmp, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            e.Graphics.DrawImage(objBmp, 250, 90);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_espere_Click(object sender, EventArgs e)
        {

        }

        private void Imprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
