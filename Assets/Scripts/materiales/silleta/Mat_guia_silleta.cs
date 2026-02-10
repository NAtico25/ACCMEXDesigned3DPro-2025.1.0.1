using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_guia_silleta : Material
{

    public int cantidad;
    public string descripcion;

    Mat_guia_silleta()
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
