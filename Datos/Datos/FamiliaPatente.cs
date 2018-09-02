using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Datos.Datos
{
	/// -----------------------------------------------------------------------------
	/// Project	 : Datos
	/// Class	 : FamiliaPatente
	/// 
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// Clase de acceso a datos para la tabla FamiliaPatente.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[Diego Parasiliti]	17/07/2018 13:43:38
	/// </history>
	/// -----------------------------------------------------------------------------
	internal static class FamiliaPatente
	{

		/// <summary>
		/// Inserta registros dentro de la tabla FamiliaPatente.
		/// </summary>
		/// <param name="idPatente"></param>
		/// <param name="idFamilia"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static int Insert(int idPatente, int idFamilia)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("FamiliaPatenteInsert");

			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);
			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			//Ejecuta la consulta y retorna el nuevo identity.
			int returnValue = Convert.ToInt32(myDatabase.ExecuteScalar(myCommand));
			return returnValue;
		}

		/// <summary>
		/// Suprime un registro de la tabla FamiliaPatente por una clave primaria(primary key).
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static void Delete(int idPatente, int idFamilia)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("FamiliaPatenteDelete");

			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);
			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla FamiliaPatente a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static void DeleteByIdFamilia(int idFamilia)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("FamiliaPatenteDeleteByIdFamilia");

			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Elimina un registro de la tabla FamiliaPatente a través de una foreign key.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static void DeleteByIdPatente(int idPatente)
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("FamiliaPatenteDeleteByIdPatente");

			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);

			myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// Selecciona un registro desde la tabla FamiliaPatente.
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[Diego Parasiliti]	17/07/2018 13:43:38
		/// </history>
		public static DataSet  Select(int idPatente, int idFamilia) 
		{
			Database myDatabase = DatabaseFactory.CreateDatabase();
			DbCommand myCommand = myDatabase.GetStoredProcCommand("FamiliaPatenteSelect");

			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);
			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla FamiliaPatente.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("FamiliaPatenteSelectAll");

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla FamiliaPatente a través de una foreign key.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("FamiliaPatenteSelectByIdFamilia");

			myDatabase.AddInParameter(myCommand,"@IdFamilia", DbType.Int32, idFamilia);

			return myDatabase.ExecuteDataSet(myCommand);
		}

		/// <summary>
		/// Selecciona todos los registros de la tabla FamiliaPatente a través de una foreign key.
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
			DbCommand myCommand = myDatabase.GetStoredProcCommand("FamiliaPatenteSelectByIdPatente");

			myDatabase.AddInParameter(myCommand,"@IdPatente", DbType.Int32, idPatente);

			return myDatabase.ExecuteDataSet(myCommand);
		}
	}
}
