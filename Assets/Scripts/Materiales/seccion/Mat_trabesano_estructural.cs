using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_trabesano_estructural : Material
{
    public Mat_trabesano_estructural()
    {
        nombre_Material = "Travesaño estructural";
        Numero_Parte = "ABB-TRAB-STR";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
    }
}
