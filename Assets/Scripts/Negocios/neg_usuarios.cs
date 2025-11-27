using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnityEngine;

public class neg_usuarios : MonoBehaviour
{
    public static async Task<DataTable> neg_obtenerUsuarios()
    {
        DataTable sqldt_VerificarSesion = null;
        dat_Conexion dat_Conexion = null;

        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(false);
            sqldt_VerificarSesion = await dat_usuarios.dat_obtenerUsuarios(dat_Conexion);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (dat_Conexion != null)
                dat_Conexion.CerrarConexion();
            Debug.Log("Conexión cerrada en neg_obtenerUsuarios.");
        }
        return sqldt_VerificarSesion;
    }

    public static async Task<DataTable> neg_cambiarEstadoUsuario(ent_usuario ent_Usuario)
    {
        DataTable sqldt_VerificarSesion = null;
        dat_Conexion dat_Conexion = null;

        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(false);
            sqldt_VerificarSesion = await dat_usuarios.dat_cambiarEstadoUsuario(ent_Usuario, dat_Conexion);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (dat_Conexion != null)
                dat_Conexion.CerrarConexion();
            Debug.Log("Conexión cerrada en neg_cambiarEstadoUsuario.");
        }
        return sqldt_VerificarSesion;
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
