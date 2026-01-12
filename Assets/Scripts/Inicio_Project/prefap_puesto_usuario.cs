using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class prefap_puesto_usuario : MonoBehaviour
{
    public TextMeshProUGUI InputPuesto;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Asignando puesto de usuario...");
        try
        {
            InputPuesto.text = "Puesto: " + ProyectoManager.Instance.ent_Usuario.rol;
            Debug.Log("Puesto de usuario asignado: " + InputPuesto.text);
            Debug.Log(ProyectoManager.Instance.ent_Usuario.rol);
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
