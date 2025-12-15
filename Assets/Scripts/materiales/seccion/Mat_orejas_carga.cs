using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_orejas_carga : Material
{


    public int cantidad;

    public Mat_orejas_carga()
    {
        nombre_Material = "Orejas de carga";
        cantidad = 4;
        //Precio = 1500.75;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara =  materialPara.Seccion;

    }
}
