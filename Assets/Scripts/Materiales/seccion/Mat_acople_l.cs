using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_acople_l : Material
{
    public int cantidad;
    public Mat_acople_l()
    {
        nombre_Material = "Acople en L";
        Numero_Parte = "ABB-CLA-90°";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
        cantidad = 2;
    }
}
