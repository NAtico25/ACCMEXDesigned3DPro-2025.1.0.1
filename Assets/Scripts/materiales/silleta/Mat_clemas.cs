using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_clemas : Material
{
    public int cantidad;
    public string descripcion;


    public Mat_clemas()
    {
        nombre_Material = "Clemas";
        Numero_Parte = "C-001";
        descripcion = "Clemas para Silleta";
        Precio = 50.0;
        cantidad = 0;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Silleta;
    }
}
