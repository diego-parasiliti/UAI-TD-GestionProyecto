using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Patente : Identity
	{
		public string Nombre { get; set; }
		public string Formulario { get; set; }
		public string Accion { get; set; }
		
	}
}
