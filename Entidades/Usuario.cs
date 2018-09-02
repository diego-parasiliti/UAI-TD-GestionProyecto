using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Usuario : Identity
	{
		public Usuario ()
		{
			LstFamilia = new List<Familia>();
			LstPatente = new List<Patente>();
		}

		public string Email { get; set; }
		public string Clave { get; set; }
		public List<Entidades.Familia> LstFamilia { get; set; }
		public List<Entidades.Patente> LstPatente { get; set; }
	}
}
