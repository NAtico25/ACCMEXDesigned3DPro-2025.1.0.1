using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class prefap_nombre_usuario : MonoBehaviour
{
    public TextMeshProUGUI InputNombreUsuario;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Asignando puesto de usuario...");
        try
        {
            InputNombreUsuario.text = "Usuario: " + ProyectoManager.Instance.ent_Usuario.usuario;
            Debug.Log("Nombre de usuario asignado: " + InputNombreUsuario.text);
            Debug.Log(ProyectoManager.Instance.ent_Usuario.usuario);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error al asignar el puesto de usuario: " + ex.Message);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
