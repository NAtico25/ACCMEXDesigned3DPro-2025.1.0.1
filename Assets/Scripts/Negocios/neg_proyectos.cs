using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnityEngine;

public class neg_proyectos : MonoBehaviour
{
    public static async Task<DataTable> neg_obtenerProyectos()
    {
        DataTable sqldt_VerificarSesion = null;
        dat_Conexion dat_Conexion = null;

        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(false);
            sqldt_VerificarSesion = await dat_proyectos.dat_obtenerProyectos(dat_Conexion);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (dat_Conexion != null)
                dat_Conexion.CerrarConexion();
            Debug.Log("Conexión cerrada en neg_obtenerProyectos.");
        }
        return sqldt_VerificarSesion;
    }
}
