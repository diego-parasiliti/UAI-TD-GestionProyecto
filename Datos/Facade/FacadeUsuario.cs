using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Facade
{
	public class FacadeUsuario
	{

		private Entidades.Usuario Mapear(DataRow row)
		{
			Entidades.Usuario usuario = new Entidades.Usuario();
			try
			{
				usuario.ID = (int)row["ID"];
				usuario.Email = (string)row["Email"];
				usuario.Clave = (string)row["Clave"];
			}
			catch
			{
				throw;
			}
			return usuario;
		}

		public bool ExisteUsuario(string email)
		{
			bool existe = false;
			List<Entidades.Usuario> lst = new List<Entidades.Usuario>();
			try
			{
				foreach (DataRow row in Datos.Usuario.SelectAll().Tables[0].Rows)
					lst.Add(Mapear(row));

				if (lst.Count == 0 || !(from usu in lst where usu.Email.ToUpper() == email.ToUpper() select usu).Any())
					existe = false;
				else
					existe = true;
			}
			catch
			{
				throw;
			}
			return existe;
		}

		public Entidades.Usuario TraerUsuarioPorEmailClave(string email, string clave)
		{
			Entidades.Usuario usuario = null;
			List<Entidades.Usuario> lst = new List<Entidades.Usuario>();
			try
			{
				foreach (DataRow row in Datos.Usuario.SelectAll().Tables[0].Rows)
					lst.Add(Mapear(row));

				lst = (from usu in lst where usu.Email.ToUpper() == email.ToUpper() && usu.Clave == clave select usu).ToList();
				if (lst.Any())
					usuario = lst.First();
			}
			catch
			{
				throw;
			}
			return usuario;
		}

	}
}
