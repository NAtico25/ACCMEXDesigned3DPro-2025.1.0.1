using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamparaControlador : MonoBehaviour
{
    public UnityEngine.Material[] materialesLampara;


    public void AsignarColor(Mat_lamicoi.ColorLampara color)
    {
        switch (color)
        {
            case Mat_lamicoi.ColorLampara.Rojo:
                GetComponent<Renderer>().material = materialesLampara[0];
                break;
            case Mat_lamicoi.ColorLampara.Verde:
                GetComponent<Renderer>().material = materialesLampara[1];
                break;
            case Mat_lamicoi.ColorLampara.Azul:
                GetComponent<Renderer>().material = materialesLampara[2];
                break;
            case Mat_lamicoi.ColorLampara.Amarillo:
                GetComponent<Renderer>().material = materialesLampara[3];
                break;
            case Mat_lamicoi.ColorLampara.Blanco:
                GetComponent<Renderer>().material = materialesLampara[4];
                break;
             default:
                GetComponent<Renderer>().material = materialesLampara[0];
                break;
        }
    }
}
