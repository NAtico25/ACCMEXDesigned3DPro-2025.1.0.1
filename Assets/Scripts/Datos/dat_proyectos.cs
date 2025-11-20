using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UnityEngine;

public class dat_proyectos : MonoBehaviour
{
    public static async Task<DataTable> dat_obtenerProyectos(dat_Conexion dat_Conexion)
    {
        SqlDataReader sqlDataReader_verificarSesion = null;
        DataTable dataTable_verificarSesion = new DataTable();
        try
        {
            dat_Conexion.sqlCommand.CommandType = CommandType.StoredProcedure;
            dat_Conexion.sqlCommand.CommandText = "sp_ObtenerProyectos";
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

    public static async Task<int> dat_crearProyecto(ent_proyecto ent_proyecto, dat_Conexion dat_Conexion)
    {
        try
        {
            dat_Conexion.sqlCommand.CommandType = CommandType.StoredProcedure;
            dat_Conexion.sqlCommand.CommandText = "sp_CrearProyecto";
            dat_Conexion.sqlCommand.Parameters.Clear();
            dat_Conexion.sqlCommand.Parameters.AddWithValue("@Nombre", ent_proyecto.nombreProyecto);
            dat_Conexion.sqlCommand.Parameters.AddWithValue("@Cliente", ent_proyecto.clienteProyecto);
            dat_Conexion.sqlCommand.Parameters.AddWithValue("@DadoAlta", ent_proyecto.dadoAltaProyecto);
            dat_Conexion.sqlCommand.Parameters.AddWithValue("@Fecha", ent_proyecto.fechaProyecto);
            dat_Conexion.sqlCommand.Parameters.AddWithValue("@Layout", ent_proyecto.LayoutProyecto);
            dat_Conexion.sqlCommand.Parameters.AddWithValue("@DocumentoCotizacion", ent_proyecto.documentoCotizacion);
            dat_Conexion.sqlCommand.Parameters.AddWithValue("@Gastos", ent_proyecto.gastosProyecto);
            int rowsAffected = await dat_Conexion.sqlCommand.ExecuteNonQueryAsync();
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
