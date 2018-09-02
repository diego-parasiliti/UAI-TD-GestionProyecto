using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Datos.Datos
{
	/// -----------------------------------------------------------------------------
	/// Project	 : Datos
	/// Class	 : UsuarioFamilia
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla UsuarioFamilia.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[Diego Parasiliti]	17/07/2018 13:43:38
	/// </history>
	/// -----------------------------------------------------------------------------
	internal static class UsuarioFamilia
	{

		/// <summary>
		/// Inserta registros dentro de la tabla UsuarioFamilia.
		/// </summary>
		/// <param name="idUsuario"></param>
		/// <param name="idFamilia"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static int Insert(int idUsuario, int idFamilia)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioFamiliaInsert");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);
			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Suprime un registro de la tabla UsuarioFamilia por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static void Delete(int idUsuario, int idFamilia)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioFamiliaDelete");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);
			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla UsuarioFamilia a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static void DeleteByIdFamilia(int idFamilia)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioFamiliaDeleteByIdFamilia");

			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla UsuarioFamilia a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static void DeleteByIdUsuario(int idUsuario)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioFamiliaDeleteByIdUsuario");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla UsuarioFamilia.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static DataSet  Select(int idUsuario, int idFamilia) 
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioFamiliaSelect");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);
			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla UsuarioFamilia.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioFamiliaSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla UsuarioFamilia a través de una foreign key.
		/// </summary>
		/// <param name="idFamilia"></param>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static DataSet  SelectByIdFamilia(int idFamilia) 
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioFamiliaSelectByIdFamilia");

			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla UsuarioFamilia a través de una foreign key.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("UsuarioFamiliaSelectByIdUsuario");

			myDatabase.AddInParameter(myCommand,"@IdUsuario", DbType.Int32, idUsuario);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
