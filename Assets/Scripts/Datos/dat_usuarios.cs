using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UnityEngine;

public class dat_usuarios : MonoBehaviour
{
    public static async Task<DataTable> dat_obtenerUsuarios(dat_Conexion dat_Conexion)
    {
        SqlDataReader sqlDataReader_verificarSesion = null;
        DataTable dataTable_verificarSesion = new DataTable();
        try
        {
            dat_Conexion.sqlCommand.CommandType = CommandType.StoredProcedure;
            dat_Conexion.sqlCommand.CommandText = "sp_ObtenerUsuarios";
            dat_Conexion.sqlCommand.Parameters.Clear();
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
