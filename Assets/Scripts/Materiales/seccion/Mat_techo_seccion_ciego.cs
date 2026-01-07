using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_techo_seccion_ciego : Material
{
    public Mat_techo_seccion_ciego(bool estado)
    {
        if (estado)
        {
            nombre_Material = "Techo de seccion ciego";
            Numero_Parte = "ABB-TCH-CIE";
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
