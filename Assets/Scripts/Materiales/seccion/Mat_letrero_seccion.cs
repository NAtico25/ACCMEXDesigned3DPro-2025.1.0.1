using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_letrero_seccion : Material
{
    public Mat_letrero_seccion(bool estado)
    {
        if (estado)
        {
            nombre_Material = "Letrero de seccion";
            Numero_Parte = "ABB-LET-SCC";
            MaterialParaUso = materialParaUso.Metal_mecanico;
            MaterialPara = materialPara.Seccion;
        }
        else
        {
            nombre_Material = "No asignado";
            Numero_Parte = "N/A";
        }

    }
}
