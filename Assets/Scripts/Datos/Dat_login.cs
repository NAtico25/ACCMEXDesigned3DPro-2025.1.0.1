using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UnityEngine;
//using Microsoft.Data.SqlClient;

public class Dat_login : MonoBehaviour
{
    // Start is called before the first frame update
    public static async Task<DataTable> dat_loginUser(dat_Conexion dat_Conexion, ent_usuario ent_Usuario)
    {
        SqlDataReader sqlDataReader_verificarSesion = null;
        DataTable dataTable_verificarSesion = new DataTable();
        try
        {
            dat_Conexion.sqlCommand.CommandType = CommandType.StoredProcedure;
            dat_Conexion.sqlCommand.CommandText = "sp_LoginUsuario";
            dat_Conexion.sqlCommand.Parameters.Clear();
            dat_Conexion.sqlCommand.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.VarChar)).Value = ent_Usuario.usuario;
            dat_Conexion.sqlCommand.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.NVarChar)).Value = ent_Usuario.contrasena;
            sqlDataReader_verificarSesion = await dat_Conexion.sqlCommand.ExecuteReaderAsync();

            if (sqlDataReader_verificarSesion.HasRows)
            {
                dataTable_verificarSesion.Load(sqlDataReader_verificarSesion);
            }
        }
        catch (Exception)
        {
            throw;
            throw new Exception("Ha ocurrido un error conectandose a la base de datos." + "\n\nDetalle del Error:\n");
        }
        finally
        {
            if (sqlDataReader_verificarSesion != null)
            {
                if (!sqlDataReader_verificarSesion.IsClosed)
                {
                    sqlDataReader_verificarSesion.Close();
                }
                sqlDataReader_verificarSesion.Dispose();
            }
        }
        return dataTable_verificarSesion;
    }
}
