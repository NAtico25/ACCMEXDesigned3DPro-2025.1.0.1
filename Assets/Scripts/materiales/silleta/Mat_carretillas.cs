using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_carretillas : Material
{
    public int cantidad;
    public string descripcion;

    public Mat_carretillas()
    {
        nombre_Material = "Carretillas";
        Numero_Parte = "CA-001";
        descripcion = "Carrettilas para silleta";
        Precio = 50.0;
        cantidad = 4;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Silleta;
    }
}
