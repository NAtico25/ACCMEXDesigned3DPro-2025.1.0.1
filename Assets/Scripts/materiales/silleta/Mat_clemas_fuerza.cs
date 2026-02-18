using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_clemas_fuerza : Material
{
    public int cantidad;
    public string descripcion;

    public Mat_clemas_fuerza()
    {
        nombre_Material = "Clemas de fuerza";
        Numero_Parte = "CF-001";
        descripcion = "Clemas de fuerza para silleta";
        Precio = 50.0;
        cantidad = 1;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Silleta;
    }
}
