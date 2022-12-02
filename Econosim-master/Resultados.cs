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
    public partial class Resultados : Form
    {
        public Resultados()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void circlebutton2_Click(object sender, EventArgs e)
        {
            resultados_estadofinanciero_ resultados_Estadofinanciero = new resultados_estadofinanciero_();
            resultados_Estadofinanciero.Show();
            this.Hide();
        }

        private void circlebutton1_Click(object sender, EventArgs e)
        {
            resultados_ratio_ resultados_Ratio = new resultados_ratio_();
            resultados_Ratio.Show();
            this.Hide();
        }

        private void circlebutton3_Click(object sender, EventArgs e)
        {
            resultado_informe_de_mercado_ resultado_Informe_De_Mercado = new resultado_informe_de_mercado_();
            resultado_Informe_De_Mercado.Show();
            this.Hide();
        }

        private void circlebutton4_Click(object sender, EventArgs e)
        {
            resultados_informe_rrhh_ resultados_Informe_Rrhh = new resultados_informe_rrhh_();
            resultados_Informe_Rrhh.Show();
            this.Hide();
        }

        private void circlebutton5_Click(object sender, EventArgs e)
        {
            resultado_informe_responsabilidad_social_ responsabilidad_Social_ = new resultado_informe_responsabilidad_social_();
            responsabilidad_Social_.Show();
            this.Hide();
        }

        private void circlebutton6_Click(object sender, EventArgs e)
        {
            resultados_informe_de_produccion_ resultados_Informe_De_Produccion = new resultados_informe_de_produccion_();
            resultados_Informe_De_Produccion.Show();
            this.Hide();
        }

        private void circlebutton7_Click(object sender, EventArgs e)
        {
            resultados_informacion_de_costos_ resultados_Informacion_De_Costos = new resultados_informacion_de_costos_();
            resultados_Informacion_De_Costos.Show();
            this.Hide();
        }

        private void circlebutton8_Click(object sender, EventArgs e)
        {

        }

        private void REPORTE_Click(object sender, EventArgs e)
        {
            FormReport newForm = new FormReport();
            newForm.Show();
        }
    }
}
