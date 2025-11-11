using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnityEngine;
//using Microsoft.Data.SqlClient;

public class neg_login : MonoBehaviour
{
    // Start is called before the first frame update
    public static async Task<DataTable> neg_loginUser(ent_usuario ent_Usuario)
    {
        DataTable sqldt_VerificarSesion = null;
        dat_Conexion dat_Conexion = null;

        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(false);
            sqldt_VerificarSesion = await Dat_login.dat_loginUser(dat_Conexion, ent_Usuario);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (dat_Conexion != null)
                dat_Conexion.CerrarConexion();
        }
        return sqldt_VerificarSesion;
    }
}
