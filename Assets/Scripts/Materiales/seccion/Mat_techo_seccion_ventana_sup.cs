using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_techo_seccion_ventana_sup : Material
{
    public Mat_techo_seccion_ventana_sup(bool estado)
    {
        if (estado)
        {
            nombre_Material = "Techo de seccion con ventana";
            Numero_Parte = "ABB-TCH-SCC-VNT";
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
