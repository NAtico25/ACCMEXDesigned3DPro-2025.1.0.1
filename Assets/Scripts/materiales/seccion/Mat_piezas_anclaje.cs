using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_piezas_anclaje : Material
{
    // Start is called before the first frame update


    public int cantidad;
    public Mat_piezas_anclaje()
    {
        nombre_Material = "piezas de anclaje";
        cantidad = 0;
        //Precio = 1000.50;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
    }
}
