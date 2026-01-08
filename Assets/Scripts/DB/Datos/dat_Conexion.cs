//using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;
using UnityEngine;



public class dat_Conexion
{
    private SqlConnection SqlConnection = null;

    public SqlCommand sqlCommand { get; set; }
    private SqlTransaction sqlTransaction;

    public dat_Conexion()
    {
        try
        {
            this.SqlConnection = new SqlConnection(@"Data Source=35.224.226.204,1433;Initial Catalog=bd_CCM_design;User ID=TI;Password=bjk2291;Encrypt=False;TrustServerCertificate=True;");
            //this.SqlConnection = new SqlConnection(@"Data Source=10.10.10.248,1433;Initial Catalog=Sistema_Cotizacion;User ID=Alex;Password=Fron0417");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error al crear la conección con la base de datos. {ex.Message}");
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
