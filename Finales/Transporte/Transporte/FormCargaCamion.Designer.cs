namespace Transporte
{
    partial class FormCargaCamion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCamion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalCarga = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.txtPesoMax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPeso = new System.Windows.Forms.NumericUpDown();
            this.cboTipoCarga = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colidTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnombreTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCamion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTotalCarga);
            this.panel1.Controls.Add(this.txtEstado);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtPatente);
            this.panel1.Controls.Add(this.txtPesoMax);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numPeso);
            this.panel1.Controls.Add(this.cboTipoCarga);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.dgvDetalle);
            this.panel1.Location = new System.Drawing.Point(28, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 401);
            this.panel1.TabIndex = 0;
            // 
            // txtCamion
            // 
            this.txtCamion.Enabled = false;
            this.txtCamion.Location = new System.Drawing.Point(448, 81);
            this.txtCamion.Name = "txtCamion";
            this.txtCamion.Size = new System.Drawing.Size(100, 22);
            this.txtCamion.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "N° Camión";
            // 
            // txtTotalCarga
            // 
            this.txtTotalCarga.Location = new System.Drawing.Point(554, 356);
            this.txtTotalCarga.Name = "txtTotalCarga";
            this.txtTotalCarga.Size = new System.Drawing.Size(100, 22);
            this.txtTotalCarga.TabIndex = 16;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(448, 35);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(100, 22);
            this.txtEstado.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Estado";
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(162, 38);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 22);
            this.txtPatente.TabIndex = 13;
            // 
            // txtPesoMax
            // 
            this.txtPesoMax.Location = new System.Drawing.Point(162, 78);
            this.txtPesoMax.Name = "txtPesoMax";
            this.txtPesoMax.Size = new System.Drawing.Size(100, 22);
            this.txtPesoMax.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Peso Máximo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Patente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Peso de la carga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo de Carga";
            // 
            // numPeso
            // 
            this.numPeso.Location = new System.Drawing.Point(318, 159);
            this.numPeso.Name = "numPeso";
            this.numPeso.Size = new System.Drawing.Size(120, 22);
            this.numPeso.TabIndex = 7;
            // 
            // cboTipoCarga
            // 
            this.cboTipoCarga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCarga.FormattingEnabled = true;
            this.cboTipoCarga.Location = new System.Drawing.Point(47, 157);
            this.cboTipoCarga.Name = "cboTipoCarga";
            this.cboTipoCarga.Size = new System.Drawing.Size(121, 24);
            this.cboTipoCarga.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total KG";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(502, 158);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(118, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(89, 353);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(173, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(299, 353);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(139, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colidTipo,
            this.colnombreTipo,
            this.colpeso,
            this.accion});
            this.dgvDetalle.Location = new System.Drawing.Point(47, 197);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.Size = new System.Drawing.Size(649, 132);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
            // 
            // colidTipo
            // 
            this.colidTipo.HeaderText = "Id de Tipo";
            this.colidTipo.MinimumWidth = 6;
            this.colidTipo.Name = "colidTipo";
            this.colidTipo.ReadOnly = true;
            this.colidTipo.Width = 125;
            // 
            // colnombreTipo
            // 
            this.colnombreTipo.HeaderText = "Tipo de Carga";
            this.colnombreTipo.MinimumWidth = 6;
            this.colnombreTipo.Name = "colnombreTipo";
            this.colnombreTipo.ReadOnly = true;
            this.colnombreTipo.Width = 125;
            // 
            // colpeso
            // 
            this.colpeso.HeaderText = "Peso KG";
            this.colpeso.MinimumWidth = 6;
            this.colpeso.Name = "colpeso";
            this.colpeso.ReadOnly = true;
            this.colpeso.Width = 125;
            // 
            // accion
            // 
            this.accion.HeaderText = "Quitar";
            this.accion.MinimumWidth = 6;
            this.accion.Name = "accion";
            this.accion.ReadOnly = true;
            this.accion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.accion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.accion.Width = 125;
            // 
            // FormCargaCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormCargaCamion";
            this.Text = "CAMION";
            this.Load += new System.EventHandler(this.FormCargaCamion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.ComboBox cboTipoCarga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPeso;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.TextBox txtPesoMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalCarga;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCamion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnombreTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpeso;
        private System.Windows.Forms.DataGridViewButtonColumn accion;
    }
}