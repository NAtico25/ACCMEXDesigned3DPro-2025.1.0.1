using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_piso : Material
{

    public piso tipoPiso;

    public enum piso
    {
        silleta,
        liso
    }

    public Mat_piso()
    {
        nombre_Material = "Angulo para techo";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
        //Precio = 1750.00;
        //tipoPiso = piso.silleta;
    }

    //void Start()
    //{
    //    MaterialParaUso = materialParaUso.Miscelaneo;
    //    MaterialPara = materialPara.Seccion;
    //}
    // Start is called before the first frame update

}
