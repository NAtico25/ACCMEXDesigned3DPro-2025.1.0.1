using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_orejas_carga : Material
{


    public int cantidad;

    public Mat_orejas_carga()
    {
        nombre_Material = "Orejas de izaje";
        cantidad = 4;
        Numero_Parte = "ABB-SUJ-SCC";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara =  materialPara.Seccion;

    }
}
