namespace WinFormHotel
{
    partial class Form1
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
            System.Windows.Forms.Label descuentoLabel;
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label rucLabel;
            System.Windows.Forms.Label tipoLabel;
            this.descuentoTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.rucTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tipoComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.iniciarButton = new System.Windows.Forms.Button();
            this.nuevoButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clienteDataGridView = new System.Windows.Forms.DataGridView();
            descuentoLabel = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            rucLabel = new System.Windows.Forms.Label();
            tipoLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clienteDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // descuentoLabel
            // 
            descuentoLabel.AutoSize = true;
            descuentoLabel.Location = new System.Drawing.Point(6, 128);
            descuentoLabel.Name = "descuentoLabel";
            descuentoLabel.Size = new System.Drawing.Size(62, 13);
            descuentoLabel.TabIndex = 1;
            descuentoLabel.Text = "Descuento:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(6, 24);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(19, 13);
            idLabel.TabIndex = 3;
            idLabel.Text = "Id:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(6, 50);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(47, 13);
            nombreLabel.TabIndex = 5;
            nombreLabel.Text = "Nombre:";
            // 
            // rucLabel
            // 
            rucLabel.AutoSize = true;
            rucLabel.Location = new System.Drawing.Point(6, 76);
            rucLabel.Name = "rucLabel";
            rucLabel.Size = new System.Drawing.Size(30, 13);
            rucLabel.TabIndex = 7;
            rucLabel.Text = "Ruc:";
            // 
            // tipoLabel
            // 
            tipoLabel.AutoSize = true;
            tipoLabel.Location = new System.Drawing.Point(6, 102);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new System.Drawing.Size(31, 13);
            tipoLabel.TabIndex = 9;
            tipoLabel.Text = "Tipo:";
            // 
            // descuentoTextBox
            // 
            this.descuentoTextBox.Location = new System.Drawing.Point(74, 125);
            this.descuentoTextBox.Name = "descuentoTextBox";
            this.descuentoTextBox.ReadOnly = true;
            this.descuentoTextBox.Size = new System.Drawing.Size(173, 20);
            this.descuentoTextBox.TabIndex = 2;
            this.descuentoTextBox.Text = "0";
            this.descuentoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(74, 21);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(173, 20);
            this.idTextBox.TabIndex = 4;
            this.idTextBox.Text = "0";
            this.idTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(74, 47);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(173, 20);
            this.nombreTextBox.TabIndex = 6;
            // 
            // rucTextBox
            // 
            this.rucTextBox.Location = new System.Drawing.Point(74, 73);
            this.rucTextBox.Name = "rucTextBox";
            this.rucTextBox.Size = new System.Drawing.Size(173, 20);
            this.rucTextBox.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tipoComboBox);
            this.groupBox1.Controls.Add(this.descuentoTextBox);
            this.groupBox1.Controls.Add(descuentoLabel);
            this.groupBox1.Controls.Add(tipoLabel);
            this.groupBox1.Controls.Add(this.rucTextBox);
            this.groupBox1.Controls.Add(idLabel);
            this.groupBox1.Controls.Add(rucLabel);
            this.groupBox1.Controls.Add(this.idTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 160);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cliente:";
            // 
            // tipoComboBox
            // 
            this.tipoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoComboBox.FormattingEnabled = true;
            this.tipoComboBox.Items.AddRange(new object[] {
            "PREMIUM",
            "REGULARES"});
            this.tipoComboBox.Location = new System.Drawing.Point(74, 99);
            this.tipoComboBox.Name = "tipoComboBox";
            this.tipoComboBox.Size = new System.Drawing.Size(173, 21);
            this.tipoComboBox.TabIndex = 10;
            this.tipoComboBox.SelectedIndexChanged += new System.EventHandler(this.tipoComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.iniciarButton);
            this.groupBox2.Controls.Add(this.nuevoButton);
            this.groupBox2.Controls.Add(this.eliminarButton);
            this.groupBox2.Controls.Add(this.guardarButton);
            this.groupBox2.Location = new System.Drawing.Point(271, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 159);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones:";
            // 
            // iniciarButton
            // 
            this.iniciarButton.BackColor = System.Drawing.Color.Tomato;
            this.iniciarButton.Location = new System.Drawing.Point(197, 30);
            this.iniciarButton.Name = "iniciarButton";
            this.iniciarButton.Size = new System.Drawing.Size(125, 51);
            this.iniciarButton.TabIndex = 0;
            this.iniciarButton.Text = "INICIAR";
            this.iniciarButton.UseVisualStyleBackColor = false;
            this.iniciarButton.Click += new System.EventHandler(this.iniciarButton_Click);
            // 
            // nuevoButton
            // 
            this.nuevoButton.Location = new System.Drawing.Point(197, 89);
            this.nuevoButton.Name = "nuevoButton";
            this.nuevoButton.Size = new System.Drawing.Size(125, 51);
            this.nuevoButton.TabIndex = 0;
            this.nuevoButton.Text = "NUEVO";
            this.nuevoButton.UseVisualStyleBackColor = true;
            this.nuevoButton.Click += new System.EventHandler(this.nuevoButton_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(19, 89);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(125, 51);
            this.eliminarButton.TabIndex = 0;
            this.eliminarButton.Text = "ELIMINAR";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(19, 26);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(125, 51);
            this.guardarButton.TabIndex = 0;
            this.guardarButton.Text = "GUARDAR";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Lista de Clientes";
            // 
            // clienteDataGridView
            // 
            this.clienteDataGridView.AllowUserToAddRows = false;
            this.clienteDataGridView.AllowUserToDeleteRows = false;
            this.clienteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clienteDataGridView.Location = new System.Drawing.Point(12, 211);
            this.clienteDataGridView.Name = "clienteDataGridView";
            this.clienteDataGridView.ReadOnly = true;
            this.clienteDataGridView.Size = new System.Drawing.Size(656, 146);
            this.clienteDataGridView.TabIndex = 15;
            this.clienteDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clienteDataGridView_CellDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 369);
            this.Controls.Add(this.clienteDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Gestion de Clientes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clienteDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descuentoTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox rucTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button iniciarButton;
        private System.Windows.Forms.Button nuevoButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tipoComboBox;
        private System.Windows.Forms.DataGridView clienteDataGridView;
    }
}

