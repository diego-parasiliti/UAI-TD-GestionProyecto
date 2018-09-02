using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Datos.Datos
{
	/// -----------------------------------------------------------------------------
	/// Project	 : Datos
	/// Class	 : Patente
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla Patente.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[Diego Parasiliti]	17/07/2018 13:43:37
	/// </history>
	/// -----------------------------------------------------------------------------
	internal static class Patente
	{

		/// <summary>
		/// Inserta registros dentro de la tabla Patente.
		/// </summary>
		/// <param name="accion"></param>
		/// <param name="formulario"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:37
		/// </history>
		public static int Insert(string accion, string formulario)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PatenteInsert");

			myDatabase.AddInParameter(myCommand,"@Accion", DbType.String, accion);
			myDatabase.AddInParameter(myCommand,"@Formulario", DbType.String, formulario);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Actualiza registros de la tabla Patente.
		/// </summary>
		/// <param name="iD"></param>
		/// <param name="accion"></param>
		/// <param name="formulario"></param>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:37
		/// </history>
		public static void Update(int iD, string accion, string formulario)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PatenteUpdate");

			myDatabase.AddInParameter(myCommand,"@ID", DbType.Int32, iD);
			myDatabase.AddInParameter(myCommand,"@Accion", DbType.String, accion);
			myDatabase.AddInParameter(myCommand,"@Formulario", DbType.String, formulario);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Suprime un registro de la tabla Patente por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:37
		/// </history>
		public static void Delete(int iD)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PatenteDelete");

			myDatabase.AddInParameter(myCommand,"@ID", DbType.Int32, iD);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla Patente.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PatenteSelect");

			myDatabase.AddInParameter(myCommand,"@ID", DbType.Int32, iD);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla Patente.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("PatenteSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
