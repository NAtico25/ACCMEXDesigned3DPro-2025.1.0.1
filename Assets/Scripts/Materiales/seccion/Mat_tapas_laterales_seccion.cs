using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_tapas_laterales_seccion : Material
{
   
    public bool tapa_Izquierda;
    public bool tapa_Derecha;
    
    public Mat_tapas_laterales_seccion()
    {
        nombre_Material = "Tapa de seccion";
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        Numero_Parte = "2TDA010222P1002";
    }
}
