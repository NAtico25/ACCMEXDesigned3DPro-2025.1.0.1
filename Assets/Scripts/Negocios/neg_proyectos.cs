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

    public static async Task<DataTable> neg_obtenerTodosProyectos()
    {
        DataTable sqldt_VerificarSesion = null;
        dat_Conexion dat_Conexion = null;

        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(false);
            sqldt_VerificarSesion = await dat_proyectos.dat_obtenerTodosProyectos(dat_Conexion);
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

    public static async Task<int> neg_crearProyecto(ent_proyecto ent_proyecto)
    {
        dat_Conexion dat_Conexion = null;
        int cont = 0;
        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(true);
            cont = await dat_proyectos.dat_crearProyecto(ent_proyecto, dat_Conexion);
            dat_Conexion.sqlCommand.Transaction.Commit();
        }
        catch (Exception)
        {
            dat_Conexion.sqlCommand.Transaction.Rollback();
            throw;
        }
        finally
        {
            dat_Conexion.CerrarConexion();
        }
        return cont;
    }

    public static async Task<DataTable> neg_cambiarEstadoProyecto(ent_proyecto ent_Proyecto)
    {
        DataTable sqldt_VerificarSesion = null;
        dat_Conexion dat_Conexion = null;

        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(false);
            sqldt_VerificarSesion = await dat_proyectos.dat_cambiarEstadoProyecto(ent_Proyecto, dat_Conexion);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (dat_Conexion != null)
                dat_Conexion.CerrarConexion();
            Debug.Log("Conexión cerrada en neg_cambiarEstadoProyecto.");
        }
        return sqldt_VerificarSesion;
    }
}
