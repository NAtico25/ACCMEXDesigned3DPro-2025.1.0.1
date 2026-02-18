using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefap_lamicoi : MonoBehaviour
{
    public prefapComponentesLamicoi superior;
    public prefapComponentesLamicoi inferior;
    // Start is called before the first frame update

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConfigurarSuperior(Mat_lamicoi lamicoi, int numeroComponente)
    {
        superior.ConfigurarComponentes(lamicoi, numeroComponente);
    }

    public void ConfigurarInferior(Mat_lamicoi lamicoi, int numeroComponente)
    {
        inferior.ConfigurarComponentes(lamicoi, numeroComponente);
    }
}
