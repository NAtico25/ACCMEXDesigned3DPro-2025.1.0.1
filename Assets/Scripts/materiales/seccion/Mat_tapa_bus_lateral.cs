using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_tapa_bus_lateral : Material
{
    // Start is called before the first frame update
    //public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    //public materialPara MaterialPara = materialPara.Seccion;

    public double largo;
    public double ancho;

    public Mat_tapa_bus_lateral()
    {
        nombre_Material = "Tapa para bus lateral";
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;
    }
}
