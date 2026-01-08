using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_base_tapa_trasera : Material
{
    public Mat_base_tapa_trasera()
    {
        nombre_Material = "Base de tapa trasera ";
        Numero_Parte = "ABB-BSE-TP-TRAS°";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
    }
}
