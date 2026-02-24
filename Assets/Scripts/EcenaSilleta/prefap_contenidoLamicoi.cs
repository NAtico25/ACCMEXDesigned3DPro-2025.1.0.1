using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class prefap_contenidoLamicoi : MonoBehaviour
{
    public TMP_Dropdown dropdownComponente;
    public TMP_Dropdown dropdownColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Mat_lamicoi.ComponenteLamicoi ObtenerComponenteLamicoi()
    {
        Mat_lamicoi.ComponenteLamicoi componente = (Mat_lamicoi.ComponenteLamicoi)dropdownComponente.value;
        Debug.Log("Componente seleccionado: " + componente);
        return componente;
    }

    public Mat_lamicoi.ColorLampara ObtenerColorLamicoi()
    {
        Mat_lamicoi.ColorLampara color = (Mat_lamicoi.ColorLampara)dropdownColor.value;
        Debug.Log("Color seleccionado: " + color);
        return color;
    }
}
