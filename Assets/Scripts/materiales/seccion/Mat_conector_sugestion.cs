using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_conector_sugestion : Material
{
    //public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    //public materialPara MaterialPara = materialPara.Seccion;

    public int cantidad;

    public Mat_conector_sugestion()
    {
        nombre_Material = "Conector de sugestion";
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;
    }
}
