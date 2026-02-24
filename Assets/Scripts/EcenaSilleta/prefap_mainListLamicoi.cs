using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefap_mainListLamicoi : MonoBehaviour
{
    public GameObject contenido;
    public prefap_datosLamicoi[] scriptsDatosLamicoi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Mat_lamicoi> ObtenerListaLamicoi()
    {
        //Primero agregamo a scriptsDatosLamicoi la cantidad de hijos que tenga contenido y su respectivo prefap_datosLamicoi}
        scriptsDatosLamicoi = new prefap_datosLamicoi[contenido.transform.childCount];
        Debug.Log("Cantidad de hijos en contenido: " + contenido.transform.childCount);
        for (int i = 0; i < contenido.transform.childCount; i++)
        {
            GameObject hijo = contenido.transform.GetChild(i).gameObject;
            prefap_datosLamicoi scriptDatos = hijo.GetComponent<prefap_datosLamicoi>();
            if (scriptDatos != null)
            {
                scriptsDatosLamicoi[i] = scriptDatos;
                scriptsDatosLamicoi[i].ObtenerCantidadContenidoLamicoi();
            }
        }


        List<Mat_lamicoi> listaLamicoi = new List<Mat_lamicoi>();
        for (int i = 0; i < scriptsDatosLamicoi.Length; i++)
        {
            Mat_lamicoi lamicoi = scriptsDatosLamicoi[i].ObtenerLamicoi();
            listaLamicoi.Add(lamicoi);
        }
        return listaLamicoi;
    }
}
