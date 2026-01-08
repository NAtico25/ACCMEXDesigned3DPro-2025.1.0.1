using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_contraseguro : Material
{
    public int cantidad;
    public Mat_contraseguro()
    {
        nombre_Material = "Contraseguro";
        Numero_Parte = "ABB-BIG-SEG";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
        cantidad = 2;
    }
}
