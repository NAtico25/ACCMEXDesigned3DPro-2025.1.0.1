using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_tapa_piso_seccion : Material
{
    public Mat_tapa_piso_seccion()
    {
        nombre_Material = "Tapa de piso de sección";
        Numero_Parte = "ABB-TAB-PI-SCC";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
    }
}
