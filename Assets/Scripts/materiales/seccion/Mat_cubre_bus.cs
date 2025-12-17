using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_cubre_bus : Material
{
    // Start is called before the first frame update
    //public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    //public materialPara MaterialPara = materialPara.Seccion;

    public int cantidad;

    public Mat_cubre_bus()
    {
        nombre_Material = "Cubre bus";
        cantidad = 0;
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;
    }
}
