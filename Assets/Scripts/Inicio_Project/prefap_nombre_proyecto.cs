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
}
