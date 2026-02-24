using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputSilleta : MonoBehaviour
{
    public InputActionReference Guardar;
    public previewCaptura previewCapturaScript;
    public TMP_InputField nombreSilletaInput;
    // Start is called before the first frame update
    void Start()
    {
        Guardar.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
       if (Guardar.action.WasPressedThisFrame())
        {
            GuardarSilleta(ProyectoManager.Instance.rutaProyectoActual);
        }
    }

    private void OnEnable()
    {
        Guardar.action.Enable();
    }

    private void OnDisable()
    {
        Guardar.action.Disable();
    }

    private void GuardarSilleta(string path)
    {
        string pathCompletoCarpetaNombre = path + "/" + nombreSilletaInput.text;
        //crear carpeta en path si no existe
        if (!Directory.Exists(pathCompletoCarpetaNombre))
        {
            Directory.CreateDirectory(pathCompletoCarpetaNombre);
        }


        byte[] data = convertidor.ConvertirJson(ProyectoManager.Instance.ent_silleta, pathCompletoCarpetaNombre);
        Debug.Log("Cantidad de lamicoiis: " + ProyectoManager.Instance.ent_silleta.lamicois.Count);
        previewCapturaScript.Captura(pathCompletoCarpetaNombre);
    }
}
