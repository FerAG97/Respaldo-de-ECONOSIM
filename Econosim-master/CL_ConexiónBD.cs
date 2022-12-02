using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Econosim
{
    class CL_ConexiónBD
    {
        SqlDataAdapter da;
        DataTable dt;

        string conexion = "Data Source = localhost; Initial Catalog = proyecto_grupo_#3; Integrated security = true ";



        public SqlConnection sc = new SqlConnection();


        public CL_ConexiónBD()
        {
            sc.ConnectionString = conexion;

        }

        public void abrir()
        {
            try
            {
                sc.Open();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ocurrio un error con la base de Datos" + Ex);
            }
        }

        public void cargarDatos(DataGridView dgv, String tabla)
        {
            try
            {
                {
                    Convert.ToString(dgv);
                    da = new SqlDataAdapter("SELECT * FROM " + tabla, conexion);
                    dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden cargar los datos" + ex.Message);
            }
        }


        public void cargarDatosEquipo(DataGridView dgv, String tabla, String equipo)
        {
            try
            {
                {
                    Convert.ToString(dgv);
                    da = new SqlDataAdapter("SELECT nombre, apellido, nombre_de_usuario, emali, numero_de_grupo FROM " + tabla + " WHERE numero_de_grupo = " + equipo + ";", conexion);
                    dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden cargar los datos" + ex.Message);
            }
        }


        public void cerrar()
        {
            sc.Close();
        }

        public void cargarDatosAdmin(DataGridView dgv, String tabla, String equipo)
        {
            try
            {
                {
                    Convert.ToString(dgv);
                    da = new SqlDataAdapter("SELECT nombre, apellido, nombre_de_usuario, emali, numero_de_grupo,  FROM " + tabla + ";", conexion);
                    dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden cargar los datos" + ex.Message);
            }
        }


    }

    

}
