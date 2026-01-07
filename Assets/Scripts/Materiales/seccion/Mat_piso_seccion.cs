using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_piso_seccion : Material
{
   

    public Mat_piso_seccion()
    {
        nombre_Material = "Piso de sección";
        Numero_Parte = "ABB-PI-SCC";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
    }
}
