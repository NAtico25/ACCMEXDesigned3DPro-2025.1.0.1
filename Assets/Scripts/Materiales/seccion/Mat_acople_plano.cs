using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Material;

[System.Serializable]
public class Mat_acople_plano : Material
{
    public int cantidad;
    public Mat_acople_plano()
    {
        nombre_Material = "Acople plano";
        Numero_Parte = "ABB-CLA-PL";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
        cantidad = 4;
    }
}
