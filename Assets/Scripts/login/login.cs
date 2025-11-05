//using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class login : MonoBehaviour
{
    public TMP_InputField usuarioInput;
    public TMP_InputField contrasenaInput;
    public Button botonLogin;
    public Button botonQuit;

    private string usuario = "Admin";
    private string contrasena = "Root";
    string usuarioActual = "";

    private void Start()
    {
        string user = CargarUsuario();
        if (user != "")
        {
            usuarioInput.text = user;
        }
        botonLogin.onClick.AddListener(() => comprobarUsuario(usuarioInput.text, contrasenaInput.text));
        botonQuit.onClick.AddListener(() => salirAplicacion());
    }

    private bool autenticar(string user, string pass)
    {
        if (user == usuario && pass == contrasena)
        {
            usuarioActual = user;
            PlayerPrefs.SetString("UsuarioGuardado", usuarioActual);
            PlayerPrefs.Save();
            Debug.Log("Usuario autenticado: " + usuarioActual);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void abrirEscena()
    {
        SceneManager.LoadScene("SampleScene");
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

    public string CargarUsuario()
    {
        if (PlayerPrefs.HasKey("UsuarioGuardado"))
        {
            usuarioActual = PlayerPrefs.GetString("UsuarioGuardado");
            Debug.Log("Usuario cargado: " + usuarioActual);
            return usuarioActual;
        }
        else
        {
            Debug.Log("No hay usuario guardado.");
            return "";
        }
    }

    public void salirAplicacion()
    {
        Application.Quit();
        Debug.Log("Aplicación cerrada.");
    }
}
