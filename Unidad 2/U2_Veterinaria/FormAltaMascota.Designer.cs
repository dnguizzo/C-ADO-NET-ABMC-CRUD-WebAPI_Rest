namespace U2_Veterinaria
{
    partial class FormAltaMascota
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAtencion = new System.Windows.Forms.DataGridView();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescricpion = new System.Windows.Forms.TextBox();
            this.dTFecha = new System.Windows.Forms.DateTimePicker();
            this.btAgregar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.id_asistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtencion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboCliente);
            this.panel1.Controls.Add(this.btAgregar);
            this.panel1.Controls.Add(this.dTFecha);
            this.panel1.Controls.Add(this.txtDescricpion);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtEdad);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.txtImporte);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboTipo);
            this.panel1.Controls.Add(this.dgvAtencion);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 0;
            // 
            // dgvAtencion
            // 
            this.dgvAtencion.AllowUserToAddRows = false;
            this.dgvAtencion.AllowUserToDeleteRows = false;
            this.dgvAtencion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtencion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_asistencia,
            this.Fecha,
            this.Descripción,
            this.Importe,
            this.Accion});
            this.dgvAtencion.Location = new System.Drawing.Point(219, 226);
            this.dgvAtencion.Name = "dgvAtencion";
            this.dgvAtencion.ReadOnly = true;
            this.dgvAtencion.RowHeadersWidth = 51;
            this.dgvAtencion.RowTemplate.Height = 24;
            this.dgvAtencion.Size = new System.Drawing.Size(554, 197);
            this.dgvAtencion.TabIndex = 0;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(148, 119);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(121, 24);
            this.cboTipo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre mascota";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(22, 27);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(48, 16);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Edad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(113, 226);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(100, 22);
            this.txtImporte.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(148, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(262, 22);
            this.textBox3.TabIndex = 10;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(148, 89);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(100, 22);
            this.txtEdad.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Fecha";
            // 
            // txtDescricpion
            // 
            this.txtDescricpion.Location = new System.Drawing.Point(145, 172);
            this.txtDescricpion.Name = "txtDescricpion";
            this.txtDescricpion.Size = new System.Drawing.Size(528, 22);
            this.txtDescricpion.TabIndex = 13;
            // 
            // dTFecha
            // 
            this.dTFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTFecha.Location = new System.Drawing.Point(519, 117);
            this.dTFecha.Name = "dTFecha";
            this.dTFecha.Size = new System.Drawing.Size(237, 22);
            this.dTFecha.TabIndex = 14;
            // 
            // btAgregar
            // 
            this.btAgregar.Location = new System.Drawing.Point(25, 290);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(75, 23);
            this.btAgregar.TabIndex = 15;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(319, 465);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 16;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(420, 465);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 17;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // id_asistencia
            // 
            this.id_asistencia.HeaderText = "id_asistencia";
            this.id_asistencia.MinimumWidth = 6;
            this.id_asistencia.Name = "id_asistencia";
            this.id_asistencia.ReadOnly = true;
            this.id_asistencia.Visible = false;
            this.id_asistencia.Width = 125;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 125;
            // 
            // Descripción
            // 
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.MinimumWidth = 6;
            this.Descripción.Name = "Descripción";
            this.Descripción.ReadOnly = true;
            this.Descripción.Width = 125;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.MinimumWidth = 6;
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 125;
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.MinimumWidth = 6;
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Width = 125;
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(148, 19);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(262, 24);
            this.cboCliente.TabIndex = 16;
            // 
            // FormAltaMascota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.panel1);
            this.Name = "FormAltaMascota";
            this.Text = "Alta_Mascota";
            this.Load += new System.EventHandler(this.FormAltaMascota_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtencion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAtencion;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.DateTimePicker dTFecha;
        private System.Windows.Forms.TextBox txtDescricpion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_asistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.ComboBox cboCliente;
    }
}

