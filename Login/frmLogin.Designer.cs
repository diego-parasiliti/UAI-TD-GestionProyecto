namespace Login
{
	partial class frmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
			this.lblEmail = new System.Windows.Forms.Label();
			this.lblClave = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.btnSalir = new System.Windows.Forms.Button();
			this.btnIngresar = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblTitulo = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.Location = new System.Drawing.Point(82, 43);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(34, 13);
			this.lblEmail.TabIndex = 0;
			this.lblEmail.Text = "Email";
			// 
			// lblClave
			// 
			this.lblClave.AutoSize = true;
			this.lblClave.Location = new System.Drawing.Point(82, 69);
			this.lblClave.Name = "lblClave";
			this.lblClave.Size = new System.Drawing.Size(34, 13);
			this.lblClave.TabIndex = 1;
			this.lblClave.Text = "Clave";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(122, 40);
			this.txtEmail.MaxLength = 50;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(175, 22);
			this.txtEmail.TabIndex = 0;
			// 
			// txtClave
			// 
			this.txtClave.Location = new System.Drawing.Point(122, 66);
			this.txtClave.MaxLength = 50;
			this.txtClave.Name = "txtClave";
			this.txtClave.PasswordChar = '*';
			this.txtClave.Size = new System.Drawing.Size(175, 22);
			this.txtClave.TabIndex = 1;
			// 
			// btnSalir
			// 
			this.btnSalir.Location = new System.Drawing.Point(141, 94);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(75, 23);
			this.btnSalir.TabIndex = 3;
			this.btnSalir.Text = "Salir";
			this.btnSalir.UseVisualStyleBackColor = true;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// btnIngresar
			// 
			this.btnIngresar.Image = ((System.Drawing.Image)(resources.GetObject("btnIngresar.Image")));
			this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnIngresar.Location = new System.Drawing.Point(222, 94);
			this.btnIngresar.Name = "btnIngresar";
			this.btnIngresar.Size = new System.Drawing.Size(75, 23);
			this.btnIngresar.TabIndex = 2;
			this.btnIngresar.Text = "Ingresar";
			this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnIngresar.UseVisualStyleBackColor = true;
			this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 64);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// lblTitulo
			// 
			this.lblTitulo.AutoSize = true;
			this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
			this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitulo.Location = new System.Drawing.Point(117, 9);
			this.lblTitulo.Name = "lblTitulo";
			this.lblTitulo.Size = new System.Drawing.Size(164, 30);
			this.lblTitulo.TabIndex = 7;
			this.lblTitulo.Text = "INICIAR SESION";
			// 
			// frmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 134);
			this.Controls.Add(this.lblTitulo);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnIngresar);
			this.Controls.Add(this.btnSalir);
			this.Controls.Add(this.txtClave);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.lblClave);
			this.Controls.Add(this.lblEmail);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(335, 173);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(335, 173);
			this.Name = "frmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Gestión de proyectos";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Label lblClave;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.Button btnSalir;
		private System.Windows.Forms.Button btnIngresar;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblTitulo;
	}
}

