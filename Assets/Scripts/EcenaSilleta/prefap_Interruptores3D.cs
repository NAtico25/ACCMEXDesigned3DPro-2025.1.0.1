using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefap_Interruptores3D : MonoBehaviour
{
    public GameObject MandoReenviadoTIpoA;
    public GameObject MandoReenviadoTIpoB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ConfigurarComponentes(Mat_interruptor componenteInterruptor, int numeroComponente)
    {
        Mat_interruptor.TipoInterruptor mat_interruptor = componenteInterruptor.tipoInterruptor;

        switch (mat_interruptor)
        {
            case Mat_interruptor.TipoInterruptor.TipoA:
                MandoReenviadoTIpoA.SetActive(true);
                MandoReenviadoTIpoB.SetActive(false);
                break;
            case Mat_interruptor.TipoInterruptor.TipoB:
                MandoReenviadoTIpoA.SetActive(false);
                MandoReenviadoTIpoB.SetActive(true);
                break;
            default:
                MandoReenviadoTIpoA.SetActive(false);
                MandoReenviadoTIpoB.SetActive(false);
                break;
        }
    }
}
