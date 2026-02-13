using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_adicionales : Material
{
    public string descripcion;
    public int cantidad;
    

    public Mat_adicionales()
    {
        nombre_Material = "";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Silleta;
        Precio = 0.00;
        descripcion = "Describir especificaciones de los adicionales";
        cantidad = 1;
        Numero_Parte = "Número de parte del material adicional";
    }
}
