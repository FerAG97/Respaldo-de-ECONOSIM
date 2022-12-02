
namespace Econosim
{
    partial class FormReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Resultado = new Econosim.Resultado();
            this.produccion_marcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produccion_marcaTableAdapter = new Econosim.ResultadoTableAdapters.produccion_marcaTableAdapter();
            this.compensacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compensacionTableAdapter = new Econosim.ResultadoTableAdapters.compensacionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Resultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccion_marcaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compensacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Produccion_Marca";
            reportDataSource1.Value = this.produccion_marcaBindingSource;
            reportDataSource2.Name = "Compensacion";
            reportDataSource2.Value = this.compensacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Econosim.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(22, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(754, 306);
            this.reportViewer1.TabIndex = 0;
            // 
            // Resultado
            // 
            this.Resultado.DataSetName = "Resultado";
            this.Resultado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produccion_marcaBindingSource
            // 
            this.produccion_marcaBindingSource.DataMember = "produccion_marca";
            this.produccion_marcaBindingSource.DataSource = this.Resultado;
            // 
            // produccion_marcaTableAdapter
            // 
            this.produccion_marcaTableAdapter.ClearBeforeFill = true;
            // 
            // compensacionBindingSource
            // 
            this.compensacionBindingSource.DataMember = "compensacion";
            this.compensacionBindingSource.DataSource = this.Resultado;
            // 
            // compensacionTableAdapter
            // 
            this.compensacionTableAdapter.ClearBeforeFill = true;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.Load += new System.EventHandler(this.FormReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Resultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccion_marcaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compensacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource produccion_marcaBindingSource;
        private Resultado Resultado;
        private System.Windows.Forms.BindingSource compensacionBindingSource;
        private ResultadoTableAdapters.produccion_marcaTableAdapter produccion_marcaTableAdapter;
        private ResultadoTableAdapters.compensacionTableAdapter compensacionTableAdapter;
    }
}