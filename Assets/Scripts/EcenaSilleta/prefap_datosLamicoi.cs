using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class prefap_datosLamicoi : MonoBehaviour
{
    public TMP_Dropdown dropdownTipo;
    public GameObject contenido;
    public prefap_contenidoLamicoi[] scripsContenidoLamicoi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Mat_lamicoi.TipoLamicoi ObtenerTipoLamicoi()
    {
        Mat_lamicoi.TipoLamicoi tipo = (Mat_lamicoi.TipoLamicoi)dropdownTipo.value;
        return tipo;
    }

    public Mat_lamicoi.ComponenteLamicoi[] ObtenerListaComponentesLamicoi() { 
        Mat_lamicoi.ComponenteLamicoi[] listaComponentes = new Mat_lamicoi.ComponenteLamicoi[scripsContenidoLamicoi.Length];
        for (int i = 0; i < scripsContenidoLamicoi.Length; i++)
        {
            listaComponentes[i] = scripsContenidoLamicoi[i].ObtenerComponenteLamicoi();
        }
        return listaComponentes;
    }
    public Mat_lamicoi.ColorLampara[] ObtenerListaColoresLamicoi()
    {
        Mat_lamicoi.ColorLampara[] listaColores = new Mat_lamicoi.ColorLampara[scripsContenidoLamicoi.Length];
        for (int i = 0; i < scripsContenidoLamicoi.Length; i++)
        {
            listaColores[i] = scripsContenidoLamicoi[i].ObtenerColorLamicoi();
        }
        return listaColores;
    }

    //Se llamará este primero
    public void ObtenerCantidadContenidoLamicoi()
    {
        scripsContenidoLamicoi = new prefap_contenidoLamicoi[contenido.transform.childCount];
        //Se obtendran los hijos de contenido y se obtendra su prefap_contenidoLamicoi para obtener la cantidad de componentes y colores seleccionados
        for (int i = 0; i < contenido.transform.childCount; i++)
        {
            GameObject hijo = contenido.transform.GetChild(i).gameObject;
            prefap_contenidoLamicoi scriptContenido = hijo.GetComponent<prefap_contenidoLamicoi>();
            if (scriptContenido != null)
            {
                scripsContenidoLamicoi[i] = scriptContenido;
                Debug.Log("El contenido no es null: " + i);
            }
        }
    }

    //Se llamará este después de obtener la cantidad de contenido ojo

    public Mat_lamicoi ObtenerLamicoi()
    {
        Mat_lamicoi.TipoLamicoi tipo = ObtenerTipoLamicoi();
        Mat_lamicoi.ComponenteLamicoi[] componentes = ObtenerListaComponentesLamicoi();
        Mat_lamicoi.ColorLampara[] colores = ObtenerListaColoresLamicoi();
        Mat_lamicoi lamicoi = new Mat_lamicoi
        {
            TipoComponenteLamicoi = tipo,
            componentes = componentes,
            colorLampara = colores
        };
        Debug.Log($"Lamicoi datos: tipo {lamicoi.TipoComponenteLamicoi}, cantidad de componentes {lamicoi.componentes.Length}, cantidad de colores {lamicoi.colorLampara.Length}");
        return lamicoi;
    }

    
}
