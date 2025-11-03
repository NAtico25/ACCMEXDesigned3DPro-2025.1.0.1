using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    private string usuario = "admin";
    private string contrasena = "root";


    private bool autenticar(string user, string pass)
    {
        if (user == usuario && pass == contrasena)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void abrirEscena()
    {
        SceneManager.LoadScene("NombreDeLaEscena");
    }

    public void comprobarUsuario(string user, string pass)
    {
        bool autenticado = autenticar(user, pass);
        if (autenticado)
        {
            abrirEscena();
        }
        else
        {
            Debug.Log("Usuario o contraseña incorrectos.");
        }
    }
}
