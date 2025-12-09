using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Material
{
    // Start is called before the first frame update
    //public string nombre_Material { get; set; }
    //public materialParaUso MaterialParaUso { get; set; }
    //public materialPara MaterialPara { get; set; }



    public string nombre_Material;
    public materialParaUso MaterialParaUso;
    public materialPara MaterialPara;

    public double Precio;


    public enum materialParaUso
    {
        Miscelaneo,
        Equipo,
        Metal_mecanico
    }

    public enum materialPara
    {
        Silleta,
        Seccion
    }
}
