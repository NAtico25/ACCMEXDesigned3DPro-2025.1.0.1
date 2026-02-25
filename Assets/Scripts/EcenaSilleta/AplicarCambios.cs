using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarCambios : MonoBehaviour
{
    public prefap_datosSilleta datos;
    public GameObject ContenidoSilleta;
    private Silleta silleta;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Aplicar()
    {
        silleta = datos.GuardarDatosSilleta();
        ProyectoManager.Instance.ent_silleta = silleta;
        Debug.Log("Datos de la silleta guardados correctamente en el ProyectoManager. Nombre: " + silleta.Nombre + ", NumeroParte: " + silleta.NumeroParte + ", TipoSilleta: " + silleta.tipoSilleta + ", Capacidad: " + silleta.capacidad + ", Piso: " + silleta.piso);
        Debug.Log("Los datos del proyecto manager son nombre: " + ProyectoManager.Instance.ent_silleta.interruptores.Count);
        ColocarComponnetesSilleta();
    }

    public void ColocarComponnetesSilleta()
    {
        //Obtener Silleta del hijo de ContenidoSilleta
        Silleta silleta = ContenidoSilleta.GetComponentInChildren<Silleta>();
        silleta.AplicarCambiosVisibles(ProyectoManager.Instance.ent_silleta);
    }
}
