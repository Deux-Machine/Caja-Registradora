namespace Caja
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            btnFacturar = new Button();
            btnActualizar = new Button();
            btnSalir = new Button();
            label4 = new Label();
            txtCantidad = new TextBox();
            dataGridView1 = new DataGridView();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(111, 17);
            label1.TabIndex = 0;
            label1.Text = "Codigo Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 98);
            label2.Name = "label2";
            label2.Size = new Size(118, 17);
            label2.TabIndex = 1;
            label2.Text = "Nombre Producto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(146, 31);
            label3.Name = "label3";
            label3.Size = new Size(105, 17);
            label3.TabIndex = 2;
            label3.Text = "Precio Producto";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(12, 58);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 3;
            txtCodigo.TextChanged += txtCodigo_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 138);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(146, 58);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 5;
            // 
            // btnFacturar
            // 
            btnFacturar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnFacturar.Location = new Point(12, 207);
            btnFacturar.Name = "btnFacturar";
            btnFacturar.Size = new Size(76, 32);
            btnFacturar.TabIndex = 6;
            btnFacturar.Text = "Facturar";
            btnFacturar.UseVisualStyleBackColor = true;
            btnFacturar.Click += btnFacturar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnActualizar.Location = new Point(208, 207);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(88, 32);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "Actulizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.Location = new Point(589, 207);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(78, 32);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(146, 98);
            label4.Name = "label4";
            label4.Size = new Size(62, 17);
            label4.TabIndex = 9;
            label4.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(146, 138);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(77, 23);
            txtCantidad.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(257, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(410, 150);
            dataGridView1.TabIndex = 11;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.Location = new Point(406, 207);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(83, 32);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 300);
            Controls.Add(btnAgregar);
            Controls.Add(dataGridView1);
            Controls.Add(txtCantidad);
            Controls.Add(label4);
            Controls.Add(btnSalir);
            Controls.Add(btnActualizar);
            Controls.Add(btnFacturar);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Tiendecita pa' vender lo que ustedes no pueden";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private Button btnFacturar;
        private Button btnActualizar;
        private Button btnSalir;
        private Label label4;
        private TextBox txtCantidad;
        private DataGridView dataGridView1;
        private Button btnAgregar;
    }
}