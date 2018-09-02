using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
	public partial class frmLogin : Form
	{
		public Entidades.Usuario Usuario;

		public frmLogin()
		{
			InitializeComponent();
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void frmLogin_Load(object sender, EventArgs e)
		{
			Usuario = null;
			txtEmail.Focus();
		}

		private void btnIngresar_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtEmail.Text.Trim() == string.Empty)
				{ 
					MessageBox.Show("Debe ingresar el email.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtEmail.Focus();
					return;
				}

				Usuario = new Negocios.Usuario().TraerUsuarioPorEmailClave(txtEmail.Text, txtClave.Text);
				if (Usuario != null)
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					MessageBox.Show("Los datos ingresados son incorrectos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtEmail.Focus();
					return;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
