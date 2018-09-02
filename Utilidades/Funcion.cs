using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Funcion
    {
		private static Funcion m_General = null;

		public static Funcion General()
		{
			if (m_General == null)
				m_General = new Funcion();

			return m_General;
		}

		public string EncriptarClave(string clave)
		{
			string claveEncriptada = string.Empty;
			MD5CryptoServiceProvider md5Hasher;
			try
			{
				md5Hasher = new MD5CryptoServiceProvider();
				Byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(clave));
				StringBuilder sbuilder = new StringBuilder();
				for (int i = 0; i <= data.Length - 1; i++)
				{
					sbuilder.Append(data[i].ToString("x2"));
				}

				claveEncriptada = sbuilder.ToString();
			}
			catch
			{
				throw;
			}
			return claveEncriptada;
		}

		public void GuardarError(Exception exception)
		{
			try
			{
				string ruta = AppDomain.CurrentDomain.BaseDirectory;

				if (!Directory.Exists(ruta))
					Directory.CreateDirectory(ruta);

				System.IO.StreamWriter oLog = new System.IO.StreamWriter(Path.Combine(ruta, string.Format("Errores{0}.log", DateTime.Now.ToString("yyyyMMdd"))), true);
				oLog.WriteLine(DateTime.Now.ToString("HH:mm") + " - " + exception.Message + " - " + exception.StackTrace);
				oLog.Close();
				oLog.Dispose();
			}
			catch
			{
				throw;
			}
		}

		public void GuardarEvento(string mensaje)
		{
			try
			{
				string ruta = AppDomain.CurrentDomain.BaseDirectory;

				if (!Directory.Exists(ruta))
					Directory.CreateDirectory(ruta);

				System.IO.StreamWriter oLog = new System.IO.StreamWriter(Path.Combine(ruta, string.Format("Eventos{0}.log", DateTime.Now.ToString("yyyyMMdd"))), true);
				oLog.WriteLine(DateTime.Now.ToString("HH:mm") + " - " + mensaje);
				oLog.Close();
				oLog.Dispose();
			}
			catch
			{
				throw;
			}
		}
	}
}
