using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefapComponentesLamicoi : MonoBehaviour
{
    public GameObject Selector;
    public GameObject lampara;
    public GameObject boton;
    public GameObject botonRetroiluminado;
    public lamparaControlador controladorLampara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConfigurarComponentes(Mat_lamicoi componenteLamicoi, int numeroComponente)
    {
        Mat_lamicoi.ComponenteLamicoi mat_Lamicoi = componenteLamicoi.componentes[numeroComponente];

        switch (mat_Lamicoi)
        {
            case Mat_lamicoi.ComponenteLamicoi.Boton:
                Selector.SetActive(false);
                lampara.SetActive(false);
                boton.SetActive(true);
                botonRetroiluminado.SetActive(false);
                break;
            case Mat_lamicoi.ComponenteLamicoi.Lampara:
                Selector.SetActive(false);
                lampara.SetActive(true);
                boton.SetActive(false);
                botonRetroiluminado.SetActive(false);
                controladorLampara.AsignarColor(componenteLamicoi.colorLampara[numeroComponente]);
                break;
            case Mat_lamicoi.ComponenteLamicoi.Selector:
                Selector.SetActive(true);
                lampara.SetActive(false);
                boton.SetActive(false);
                botonRetroiluminado.SetActive(false);
                break;
            case Mat_lamicoi.ComponenteLamicoi.BotonRetroiluminado:
                Selector.SetActive(false);
                lampara.SetActive(false);
                boton.SetActive(false);
                botonRetroiluminado.SetActive(true);
                break;
             default:
                Selector.SetActive(false);
                lampara.SetActive(false);
                boton.SetActive(false);
                botonRetroiluminado.SetActive(false);
                break;
        }
    }
}
