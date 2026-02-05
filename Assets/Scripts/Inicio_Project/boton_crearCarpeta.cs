using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boton_crearCarpeta : MonoBehaviour
{
    public Button botonCrearCarpeta;
    public Button botonRegresar;
    public prefap_crear_carpeta ventanaCrearCarpeta;
    public prefap_selecciones prefap_Selecciones;
    // Start is called before the first frame update
    void Start()
    {
        //accion cuando se presiona el boton
        botonCrearCarpeta.onClick.AddListener(() =>
        {
            ventanaCrearCarpeta.ActivarVentana();
        });

        botonRegresar.onClick.AddListener(() =>
        {
            Debug.Log("Boton regresar presionado");
            prefap_Selecciones.RefrescarContenido(ProyectoManager.Instance.rutaPrincipalProyectos);
            ProyectoManager.Instance.rutaProyectoActual = ProyectoManager.Instance.rutaPrincipalProyectos;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
