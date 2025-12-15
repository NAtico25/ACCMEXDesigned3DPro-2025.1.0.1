using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_angulo_anclaje : Material
{
    //public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    //public materialPara MaterialPara = materialPara.Seccion;

    public int cantidad;

    public Mat_angulo_anclaje()
    {
        nombre_Material = "Angulos de anclaje";
        cantidad = 1;
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;
    }
}
