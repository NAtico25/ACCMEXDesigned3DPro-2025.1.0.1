using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_tapa_lateral_Inferior_seccion : Material
{
    public Mat_tapa_lateral_Inferior_seccion()
    {
        nombre_Material = "Tapa Lateral Inferior Seccion";
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        Numero_Parte = "S/N";
    }
}
