using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using UnityEngine;
//using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;



public class dat_Conexion
{
    private SqlConnection SqlConnection = null;

    public SqlCommand sqlCommand { get; set; }
    private SqlTransaction sqlTransaction;

    public dat_Conexion()
    {
        try
        {
            this.SqlConnection = new SqlConnection(@"Data Source=127.0.0.1,1433;Initial Catalog=Sistema_Cotizacion;User ID=Alex;Password=Fron0417");
            //this.SqlConnection = new SqlConnection("Data Source=35.224.226.204;Initial Catalog=bd_ERP_ACC_MEX_2020;User ID=ds;Password=Visual2020");
        }
        catch (Exception ex)
        {
            Debug.Log($"Error al crear la conección con la base de datos. {ex.Message}");
            throw;

        }
    } 
    
    public void abrirConexion(Boolean transaction)
    {
        if (SqlConnection.State == ConnectionState.Closed)
        {
            try
            {
                SqlConnection.Open();
                sqlCommand = SqlConnection.CreateCommand();
                sqlCommand.CommandTimeout = 0;

                if (transaction)
                {
                    sqlTransaction = SqlConnection.BeginTransaction();
                    sqlCommand.Transaction = sqlTransaction;
                }

            }
            catch (Exception ex)
            {
                Debug.Log($"Error al abrir conección con la base de datos. {ex.Message}");
                throw;
            }
        }
    }
    public void CerrarConexion()
    {
        try
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
                SqlConnection.Dispose();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
