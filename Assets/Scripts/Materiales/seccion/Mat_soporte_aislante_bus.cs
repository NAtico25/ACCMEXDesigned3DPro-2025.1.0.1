using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_soporte_aislante_bus : Material
{
    public Mat_soporte_aislante_bus()
    {
        nombre_Material = "Soporte para el aislante de bus";
        Numero_Parte = "ABB-SOP-AIS-BB°";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
    }
}
