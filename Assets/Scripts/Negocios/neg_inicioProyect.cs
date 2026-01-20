using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnityEngine;

public class neg_inicioProyect : MonoBehaviour
{
    public static async Task<DataTable> neg_ObtenerClientes()
    {
        DataTable sqldt_Clientes = null;
        dat_Conexion dat_Conexion = null;
        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(false);
            sqldt_Clientes = await dat_inicioProyect.dat_ObtenerClientes(dat_Conexion);
        }
        catch (System.Exception)
        {
            throw;
        }
        finally
        {
            if (dat_Conexion != null)
                dat_Conexion.CerrarConexion();
            Debug.Log("Conexión cerrada en neg_ObtenerClientes.");
        }
        return sqldt_Clientes;
    }

    public static async Task<int> neg_CrearCliente(string nombreCliente)
    {
        dat_Conexion dat_Conexion = null;
        int cont = 0;
        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(true);
            cont = await dat_inicioProyect.dat_CrearCliente(dat_Conexion, nombreCliente );
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
