using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_tapa_techo_seccion : Material
{
    public Mat_tapa_techo_seccion(bool estado)
    {
        if (estado)
        {
            nombre_Material = "Tapa de techo de seccion";
            Numero_Parte = "ABB-TAB-TCH-SCC";
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
