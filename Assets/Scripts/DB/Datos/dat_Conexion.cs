using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using UnityEngine;

class dat_Conexion
{
    private SqlConnection SqlConnection = null;

    public SqlCommand sqlCommand { get; set; }
    private SqlTransaction sqlTransaction;

    public dat_Conexion()
    {
       this.SqlConnection = new SqlConnection("Data Source=IP_SERVIDOR;Initial Catalog=TU_BASE_DE_DATOS;User ID=TU_USUARIO;Password=TU_CONTRASEÑA");
    }   

    public void abrirConexion(Boolean transaction)
    {
        if (SqlConnection.State == System.Data.ConnectionState.Closed)
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
                //Console.WriteLine($"Error al abrir conección con la base de datos. {ex.Message}");
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
