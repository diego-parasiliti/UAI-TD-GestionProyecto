using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionProyecto
{
	public partial class frmPrincipal : Form
	{
		public frmPrincipal()
		{
			InitializeComponent();
		}

		private void frmPrincipal_Load(object sender, EventArgs e)
		{
			try
			{
				Entidades.Usuario usuario = null;
				Login.frmLogin frm = new Login.frmLogin();
				if (frm.ShowDialog() != DialogResult.OK)
					Application.Exit();

				usuario = frm.Usuario;
				MessageBox.Show(string.Format("Bienvenido al sistema {0}",usuario.Email) , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
