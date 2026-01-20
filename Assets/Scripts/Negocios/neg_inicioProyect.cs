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
        int resultado = 0;
        dat_Conexion dat_Conexion = null;
        try
        {
            dat_Conexion = new dat_Conexion();
            dat_Conexion.abrirConexion(true);
            resultado = await dat_inicioProyect.dat_CrearCliente(dat_Conexion, nombreCliente);
        }
        catch (System.Exception)
        {
            throw;
        }
        finally
        {
            if (dat_Conexion != null)
                dat_Conexion.CerrarConexion();
            Debug.Log("Conexión cerrada en neg_CrearCliente.");
        }
        return resultado;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
