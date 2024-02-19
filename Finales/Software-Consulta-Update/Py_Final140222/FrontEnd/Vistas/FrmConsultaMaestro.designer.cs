
namespace Py_Final140222.FrontEnd.Vistas
{
    partial class FrmConsultaMaestro
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colidproyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfecini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfecfin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevaReceta = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtp2);
            this.groupBox2.Controls.Add(this.dtp1);
            this.groupBox2.Controls.Add(this.btnConsultar);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(17, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(675, 293);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados:";
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(317, 62);
            this.dtp2.Margin = new System.Windows.Forms.Padding(2);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(143, 22);
            this.dtp2.TabIndex = 8;
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(113, 62);
            this.dtp1.Margin = new System.Windows.Forms.Padding(2);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(143, 22);
            this.dtp1.TabIndex = 7;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(519, 59);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(148, 28);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(496, 252);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(123, 16);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total de proyectos:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colidproyecto,
            this.colnombre,
            this.colfecini,
            this.colfecfin,
            this.colaccion});
            this.dataGridView1.Location = new System.Drawing.Point(8, 95);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.Size = new System.Drawing.Size(659, 144);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colidproyecto
            // 
            this.colidproyecto.HeaderText = "Numero Proyecto";
            this.colidproyecto.MinimumWidth = 6;
            this.colidproyecto.Name = "colidproyecto";
            this.colidproyecto.ReadOnly = true;
            this.colidproyecto.Width = 125;
            // 
            // colnombre
            // 
            this.colnombre.HeaderText = "Nombre Proyecto";
            this.colnombre.MinimumWidth = 6;
            this.colnombre.Name = "colnombre";
            this.colnombre.ReadOnly = true;
            this.colnombre.Width = 125;
            // 
            // colfecini
            // 
            this.colfecini.HeaderText = "Fecha Inicio";
            this.colfecini.MinimumWidth = 6;
            this.colfecini.Name = "colfecini";
            this.colfecini.ReadOnly = true;
            this.colfecini.Width = 125;
            // 
            // colfecfin
            // 
            this.colfecfin.HeaderText = "Fecha Fin";
            this.colfecfin.MinimumWidth = 6;
            this.colfecfin.Name = "colfecfin";
            this.colfecfin.ReadOnly = true;
            this.colfecfin.Width = 125;
            // 
            // colaccion
            // 
            this.colaccion.HeaderText = "Accion";
            this.colaccion.MinimumWidth = 6;
            this.colaccion.Name = "colaccion";
            this.colaccion.ReadOnly = true;
            this.colaccion.Width = 125;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(563, 332);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(121, 28);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevaReceta
            // 
            this.btnNuevaReceta.Location = new System.Drawing.Point(17, 332);
            this.btnNuevaReceta.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevaReceta.Name = "btnNuevaReceta";
            this.btnNuevaReceta.Size = new System.Drawing.Size(127, 28);
            this.btnNuevaReceta.TabIndex = 6;
            this.btnNuevaReceta.Text = "Ver proyecto";
            this.btnNuevaReceta.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(152, 332);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(127, 28);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar proyecto";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmConsultaMaestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 372);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnNuevaReceta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmConsultaMaestro";
            this.Text = "Consultar proyectos";
            this.Load += new System.EventHandler(this.FrmConsultarProyecto_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnNuevaReceta;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidproyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colfecini;
        private System.Windows.Forms.DataGridViewTextBoxColumn colfecfin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colaccion;
    }
}