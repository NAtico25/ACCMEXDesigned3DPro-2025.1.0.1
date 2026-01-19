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

public class prefap_nombre_proyecto : MonoBehaviour
{
    public TMP_InputField nombreProyectoInput;
    // Start is called before the first frame update
    void Start()
    {
        nombreProyectoInput.text = ProyectoManager.Instance.proyectoNuevo.nombreProyecto;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task<int> CrearProyecto(ent_proyecto nuevoProyecto)
    {
        int resultado = 0;
        try
        {
            ProyectoManager.Instance.proyectoNuevo.nombreProyecto = nombreProyectoInput.text;
            resultado = await neg_proyectos.neg_crearProyecto(nuevoProyecto);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al crear proyecto: " + ex.Message);
        }
        return resultado;
    }
}
