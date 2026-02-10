using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_porta_clemas : Material
{

    public int cantidad;
    public string descripcion;
    public Mat_porta_clemas()
    {
        nombre_Material = "Porta Clemas";
        Numero_Parte = "PC-001";
        descripcion = "Porta Clemas para Silleta";
        Precio = 50.0;
        cantidad = 1;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Silleta;
    }
}
