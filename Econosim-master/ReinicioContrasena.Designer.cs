
namespace Econosim
{
    partial class ReinicioContrasena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReinicioContrasena));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRec_Correo = new System.Windows.Forms.TextBox();
            this.linklblReturn = new System.Windows.Forms.LinkLabel();
            this.circlebutton5 = new Materiasles_1.circlebutton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::Econosim.Properties.Resources.shield;
            this.pictureBox1.Location = new System.Drawing.Point(286, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(127, 155);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(439, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Por favor, ingrese el correo electrónico asociado a su cuenta para \r\nrecibir info" +
    "rmación de reinicio de contraseña.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtRec_Correo
            // 
            this.txtRec_Correo.Location = new System.Drawing.Point(232, 218);
            this.txtRec_Correo.Name = "txtRec_Correo";
            this.txtRec_Correo.Size = new System.Drawing.Size(254, 20);
            this.txtRec_Correo.TabIndex = 2;
            // 
            // linklblReturn
            // 
            this.linklblReturn.AutoSize = true;
            this.linklblReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblReturn.LinkColor = System.Drawing.Color.White;
            this.linklblReturn.Location = new System.Drawing.Point(307, 311);
            this.linklblReturn.Name = "linklblReturn";
            this.linklblReturn.Size = new System.Drawing.Size(87, 13);
            this.linklblReturn.TabIndex = 10;
            this.linklblReturn.TabStop = true;
            this.linklblReturn.Text = "Regresar a Inicio\r\n";
            this.linklblReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblReturn_LinkClicked);
            // 
            // circlebutton5
            // 
            this.circlebutton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(103)))), ((int)(((byte)(171)))));
            this.circlebutton5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(103)))), ((int)(((byte)(171)))));
            this.circlebutton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.circlebutton5.BorderRadius = 19;
            this.circlebutton5.BorderSize = 0;
            this.circlebutton5.FlatAppearance.BorderSize = 0;
            this.circlebutton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circlebutton5.ForeColor = System.Drawing.Color.White;
            this.circlebutton5.Location = new System.Drawing.Point(232, 255);
            this.circlebutton5.Name = "circlebutton5";
            this.circlebutton5.Size = new System.Drawing.Size(254, 40);
            this.circlebutton5.TabIndex = 21;
            this.circlebutton5.Text = "Solicitar Reinicio de Contraseña";
            this.circlebutton5.TextColor = System.Drawing.Color.White;
            this.circlebutton5.UseVisualStyleBackColor = false;
            // 
            // ReinicioContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(704, 341);
            this.Controls.Add(this.circlebutton5);
            this.Controls.Add(this.linklblReturn);
            this.Controls.Add(this.txtRec_Correo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReinicioContrasena";
            this.Text = "Reinicio de Contrasena";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRec_Correo;
        private System.Windows.Forms.LinkLabel linklblReturn;
        private Materiasles_1.circlebutton circlebutton5;
    }
}