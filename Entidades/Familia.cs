using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Familia : Identity
    {
		public Familia()
		{
			LstPatente = new List<Patente>();
		}

		public string Nombre { get; set; }
		public List<Entidades.Patente> LstPatente { get; set; }
	}
}
