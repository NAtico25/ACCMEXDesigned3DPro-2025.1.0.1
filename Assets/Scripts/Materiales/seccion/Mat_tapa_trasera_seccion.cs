using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_tapa_trasera_seccion : Material
{
    public bool tiene_Tapa_Trasera;

    public Mat_tapa_trasera_seccion()
    {
        nombre_Material = "Tapa trasera de seccion";
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        Numero_Parte = "2TDA010226P1006";
    }
}
