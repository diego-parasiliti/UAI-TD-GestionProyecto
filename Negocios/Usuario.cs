using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Usuario
    {

		public Entidades.Usuario TraerUsuarioPorEmailClave(string email, string clave)
		{
			Entidades.Usuario usuario = null;
			Datos.Facade.FacadeUsuario facadeUsuario = new Datos.Facade.FacadeUsuario();
			try
			{
				if (facadeUsuario.ExisteUsuario(email))
				{
					usuario = facadeUsuario.TraerUsuarioPorEmailClave(email, Utilidades.Funcion.General().EncriptarClave(clave));
				}
				else
					throw new Exception("El usuario no esta registrado.");
			}
			catch(Exception ex)
			{
				Utilidades.Funcion.General().GuardarError(ex);
				throw;
			}
			return usuario;
		}





    }
}
