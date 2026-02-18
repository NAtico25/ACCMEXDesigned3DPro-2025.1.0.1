using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefap_mandoReenviado : MonoBehaviour
{
    public GameObject mandoReenviadoA;
    public GameObject mandoReenviadoB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activarMandoReenviado(Mat_interruptor.TipoInterruptor tipoInterruptor)
    {
        switch(tipoInterruptor)
        {
            case Mat_interruptor.TipoInterruptor.TipoA:
                mandoReenviadoA.SetActive(true);
                mandoReenviadoB.SetActive(false);
                break;
            case Mat_interruptor.TipoInterruptor.TipoB:
                mandoReenviadoA.SetActive(false);
                mandoReenviadoB.SetActive(true);
                break;
        }
    }
}
