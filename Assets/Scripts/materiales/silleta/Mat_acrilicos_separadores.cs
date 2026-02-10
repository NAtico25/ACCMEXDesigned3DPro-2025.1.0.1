using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_acrilicos_separadores : Material
{
    public int cantidad;
    public string descripcion;

    Mat_acrilicos_separadores()
    {
        nombre_Material = "Acrilicos separadores";
        Numero_Parte = "CA-001";
        descripcion = "Acrilicos para silleta";
        Precio = 50.0;
        cantidad = 1;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Silleta;
    }
}
