using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_ang_techo : Material
{
    // Start is called before the first frame update

    public double largo;
    public double ancho;

    public Mat_ang_techo()
    {
        nombre_Material = "Angulo para techo";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
        Precio = 1750.00;
        largo = 0;
        ancho = 0;
    }
}
