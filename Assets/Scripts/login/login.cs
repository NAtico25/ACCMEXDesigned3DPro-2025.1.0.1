//using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class login : MonoBehaviour
{
    public TMP_InputField usuarioInput;
    public TMP_InputField contrasenaInput;
    public Button botonLogin;
    public Button botonQuit;

    private string usuario;
    private string contrasena;
    string usuarioActual = "";

    ent_usuario ent_Usuario;


    private void Start()
    {
        string user = CargarUsuario();
        if (user != "")
        {
            usuarioInput.text = user;
        }
        botonLogin.onClick.AddListener(() => comprobarUsuario(usuarioInput.text, contrasenaInput.text));
        botonQuit.onClick.AddListener(() => salirAplicacion());

        if(usuarioInput.text == null || usuarioInput.text == "")
        {
            EventSystem.current.SetSelectedGameObject(usuarioInput.gameObject);
            usuarioInput.ActivateInputField();
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(contrasenaInput.gameObject);
            contrasenaInput.ActivateInputField();
        }
    }

    private async Task<bool> autenticar(string user, string pass)
    {
        Debug.Log("Iniciando autenticación para el usuario: " + user);
        ent_Usuario = new ent_usuario
        {
            usuario = user,
            contrasena = pass
        };
        
        
        DataTable dtUsuario = await neg_login.neg_loginUser(ent_Usuario);

        if (dtUsuario.Columns.Contains("IdUsuario"))
        {
            ent_Usuario.id_usuario = int.Parse(dtUsuario.Rows[0]["IdUsuario"].ToString());
            ent_Usuario.rol = dtUsuario.Rows[0]["NombreRol"].ToString();
            usuarioActual = ent_Usuario.usuario;
            PlayerPrefs.SetString("UsuarioGuardado", usuarioActual);
            return true;
        }
        else if (dtUsuario.Columns.Contains("Mensaje"))
        {
            Debug.Log("Error de autenticación: " + dtUsuario.Rows[0]["Mensaje"].ToString());
            return false;
        }
        else
        {
            Debug.Log("Error desconocido durante la autenticación.");
            return false;
        }
    }

    private void abrirEscena()
    {
        if (ent_Usuario.rol == "Administrador")
            SceneManager.LoadScene("AdminProject");
        else if (ent_Usuario.rol == "Usuario")
            SceneManager.LoadScene("CreateProject");
        else
            Debug.Log("Rol de usuario desconocido.");

    }

    public  async void comprobarUsuario(string user, string pass)
    {
        bool autenticado = await autenticar(user, pass);
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
