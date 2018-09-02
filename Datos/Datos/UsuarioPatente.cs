using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Datos.Datos
{
	/// -----------------------------------------------------------------------------
	/// Project	 : Datos
	/// Class	 : UsuarioPatente
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla UsuarioPatente.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[Diego Parasiliti]	17/07/2018 13:43:38
	/// </history>
	/// -----------------------------------------------------------------------------
	internal static class UsuarioPatente
	{

		/// <summary>
		/// Inserta registros dentro de la tabla UsuarioPatente.
		/// </summary>
		/// <param name="idUsuario"></param>
		/// <param name="idPatente"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static int Insert(int idUsuario, int idPatente)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioPatenteInsert");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);
			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Suprime un registro de la tabla UsuarioPatente por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static void Delete(int idUsuario, int idPatente)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioPatenteDelete");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);
			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla UsuarioPatente a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static void DeleteByIdUsuario(int idUsuario)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioPatenteDeleteByIdUsuario");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla UsuarioPatente a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static void DeleteByIdPatente(int idPatente)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioPatenteDeleteByIdPatente");

			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla UsuarioPatente.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static DataSet  Select(int idUsuario, int idPatente) 
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioPatenteSelect");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);
			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla UsuarioPatente.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static DataSet  SelectAll()
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioPatenteSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla UsuarioPatente a través de una foreign key.
		/// </summary>
		/// <param name="idUsuario"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static DataSet  SelectByIdUsuario(int idUsuario) 
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioPatenteSelectByIdUsuario");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla UsuarioPatente a través de una foreign key.
		/// </summary>
		/// <param name="idPatente"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static DataSet  SelectByIdPatente(int idPatente) 
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioPatenteSelectByIdPatente");

			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
