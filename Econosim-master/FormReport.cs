using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econosim
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Resultado.produccion_marca' Puede moverla o quitarla según sea necesario.
            this.produccion_marcaTableAdapter.Fill(this.Resultado.produccion_marca);
            // TODO: esta línea de código carga datos en la tabla 'Resultado.compensacion' Puede moverla o quitarla según sea necesario.
            this.compensacionTableAdapter.Fill(this.Resultado.compensacion);

            this.reportViewer1.RefreshReport();
        }
    }
}
