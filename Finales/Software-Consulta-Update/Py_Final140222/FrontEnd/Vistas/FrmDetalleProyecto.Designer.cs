
namespace Py_Final140222.FrontEnd.Vistas
{
    partial class FrmDetalleProyecto
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.lblNroProyecto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detalles del Proyecto";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(53, 118);
            this.dgvDetalles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.RowHeadersWidth = 82;
            this.dgvDetalles.RowTemplate.Height = 33;
            this.dgvDetalles.Size = new System.Drawing.Size(616, 243);
            this.dgvDetalles.TabIndex = 1;
            // 
            // lblNroProyecto
            // 
            this.lblNroProyecto.AutoSize = true;
            this.lblNroProyecto.Location = new System.Drawing.Point(276, 48);
            this.lblNroProyecto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNroProyecto.Name = "lblNroProyecto";
            this.lblNroProyecto.Size = new System.Drawing.Size(0, 16);
            this.lblNroProyecto.TabIndex = 2;
            // 
            // FrmDetalleProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 406);
            this.Controls.Add(this.lblNroProyecto);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmDetalleProyecto";
            this.Text = "FrmProyecto";
            this.Load += new System.EventHandler(this.FrmProyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label lblNroProyecto;
    }
}