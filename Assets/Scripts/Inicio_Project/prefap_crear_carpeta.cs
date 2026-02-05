using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prefap_crear_carpeta : MonoBehaviour
{
    public Button botonCrearCarpeta;
    public Button botonCancelar;
    public CanvasGroup canvasGroup;
    public TMP_InputField inputNombreCarpeta;
    public string pathCarpeta;
    public prefap_selecciones prefap_Selecciones;
    // Start is called before the first frame update
    void Start()
    {
        botonCrearCarpeta.onClick.AddListener(() =>
        {
            string nombreCarpeta = inputNombreCarpeta.text;
            if (!string.IsNullOrEmpty(nombreCarpeta))
            {
                CrearNuevaCarpeta(ProyectoManager.Instance.rutaProyectoActual, nombreCarpeta);
                prefap_Selecciones.RefrescarContenido(ProyectoManager.Instance.rutaProyectoActual);
                DesactivarVentana();
            }
            else
            {
                Debug.LogWarning("El nombre de la carpeta no puede estar vacío.");
            }
        });
        botonCancelar.onClick.AddListener(DesactivarVentana);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarVentana()
    {
        gameObject.SetActive(true);
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        Time.timeScale = 0f; // Congela el resto de elementos

    }


    public void DesactivarVentana()
    {
        gameObject.SetActive(false);
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        Time.timeScale = 1f; // Reanuda 
    }
    public void CrearNuevaCarpeta(string path, string nombreCarpeta)
    {
        string nuevaRuta = System.IO.Path.Combine(path, nombreCarpeta);
        if (!System.IO.Directory.Exists(nuevaRuta))
        {
            System.IO.Directory.CreateDirectory(nuevaRuta);
            Debug.Log($"Carpeta creada en: {nuevaRuta}");
        }
        else
        {
            Debug.LogWarning("La carpeta ya existe.");
        }
    }
}
