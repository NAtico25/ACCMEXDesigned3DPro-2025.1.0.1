using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_ang_piso : Material
{
    public double largo;
    public double ancho;

    public Mat_ang_piso()
    {
        nombre_Material = "Angulo para piso";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
        //Precio = 1800.25;
        //largo = 0;
        //ancho = 0;
    }
}
