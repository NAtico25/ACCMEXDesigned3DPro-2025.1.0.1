using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_placas_metal_piso : Material
{
    public int cantidad;

    public Mat_placas_metal_piso()
    {
        nombre_Material = "Placas de metal para piso";
        cantidad = 0;
        Precio = 2000.00;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;




    }
}
