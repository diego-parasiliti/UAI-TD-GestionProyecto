using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Datos.Datos
{
	/// -----------------------------------------------------------------------------
	/// Project	 : Datos
	/// Class	 : Usuario
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Usuario.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[Diego Parasiliti]	17/07/2018 13:43:37
	/// </history>
	/// -----------------------------------------------------------------------------
	internal static class Usuario
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Usuario.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="clave"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:37
		/// </history>
		public static int Insert(string email, string clave)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioInsert");

			myDatabase.AddInParameter(myCommand,"@Email", DbType.String, email);
			myDatabase.AddInParameter(myCommand,"@Clave", DbType.String, clave);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Usuario.
		/// </summary>
		/// <param name="iD"></param>
		/// <param name="email"></param>
		/// <param name="clave"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:37
		/// </history>
		public static void Update(int iD, string email, string clave)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioUpdate");

			myDatabase.AddInParameter(myCommand,"@ID", DbType.Int32, iD);
			myDatabase.AddInParameter(myCommand,"@Email", DbType.String, email);
			myDatabase.AddInParameter(myCommand,"@Clave", DbType.String, clave);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Usuario por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:37
		/// </history>
		public static void Delete(int iD)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioDelete");

			myDatabase.AddInParameter(myCommand,"@ID", DbType.Int32, iD);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Usuario.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:37
		/// </history>
		public static DataSet  Select(int iD) 
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioSelect");

			myDatabase.AddInParameter(myCommand,"@ID", DbType.Int32, iD);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Usuario.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:37
		/// </history>
		public static DataSet  SelectAll()
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
