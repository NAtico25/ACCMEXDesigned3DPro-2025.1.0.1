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

    public void ConfigurarSuperior(Mat_lamicoi lamicoi)
    {
        superior.ConfigurarComponentes(lamicoi, 0);
    }

    public void ConfigurarInferior(Mat_lamicoi lamicoi)
    {
        inferior.ConfigurarComponentes(lamicoi, 1);
    }
}
