using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_bus_lateral : Material
{
    //public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    //public materialPara MaterialPara = materialPara.Seccion;

    public int cantidad;

    public Mat_bus_lateral()
    {
        nombre_Material = "Bus lateral";
        cantidad = 0;
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;
    }
}
