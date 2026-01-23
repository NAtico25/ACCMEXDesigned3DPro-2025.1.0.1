using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefap_guardarNuevoProyecto : MonoBehaviour
{
    public Button boton_guardar;
    public Button boton_cancelar;
    public CanvasGroup canvasGroup;
    public prefap_nombre_proyecto nombre_Proyecto;
    void Start()
    {
        boton_guardar.onClick.AddListener(() =>
        {
            Debug.Log("Guardar nuevo proyecto");
            verificarCrearProyecto(ProyectoManager.Instance.esNuevoProyecto);
            //Agregar funcionalidad de guardar nuevo proyecto aqui
            DesactivarVentana();
        });

        boton_cancelar.onClick.AddListener(() =>
        {
            Debug.Log("Cancelar nuevo proyecto");
            //Agregar funcionalidad de cancelar nuevo proyecto aqui
            DesactivarVentana();
        });
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

    private async void verificarCrearProyecto(bool esNuevo)
    {
        if (ProyectoManager.Instance.esNuevoProyecto == true)
        {
            ProyectoManager.Instance.ent_Proyecto.documentoCotizacion = convertidor.ConvertirJson(ProyectoManager.Instance.ent_Proyecto);
            ProyectoManager.Instance.ent_Proyecto.LayoutProyecto = convertidor.ConvertirJson(ProyectoManager.Instance.ent_Proyecto);
            ProyectoManager.Instance.ent_Proyecto.clienteProyecto = "PruebaClienteCodigo";
            ProyectoManager.Instance.ent_Proyecto.dadoAltaProyecto = true;
            Debug.Log($"Los datos son los siguientes: {ProyectoManager.Instance.ent_Proyecto.clienteProyecto}");
            Debug.Log("Creando nuevo proyecto en la base de datos...");
            int valor = await nombre_Proyecto.CrearProyecto(ProyectoManager.Instance.ent_Proyecto);
        }
    }
}
