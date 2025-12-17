using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_puerta : Material
{
    //public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    //public materialPara MaterialPara = materialPara.Seccion;

    public double alto;
    public double ancho;
    public int numero_seguros;
    public int porta_seguros;
    public bool conPuerta;
    public string descripcion;

    public enum tipo_Puerta
    {
        Superior,
        Inferior,
        General
    }

    public Mat_puerta()
    {
        nombre_Material = "Puerta de sección";
        conPuerta = false;
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;
    }
}
