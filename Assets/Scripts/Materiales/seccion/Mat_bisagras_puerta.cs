using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_bisagras_puerta : Material
{
    public int cantidad;
    public double largo;
    public double ancho;
    public string descripcion; 
    public Mat_bisagras_puerta(bool estado)
    {
        if (estado)
        {
            nombre_Material = "Bisagras para puerta";
            Numero_Parte = "ABB-BIS-GDE";
            MaterialParaUso = materialParaUso.Metal_mecanico;
            MaterialPara = materialPara.Seccion;
            cantidad = 2;
        }
        else
        {
            nombre_Material = "No asignado";
            Numero_Parte = "N/A";
        }

    }
}
