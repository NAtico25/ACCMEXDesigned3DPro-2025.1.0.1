using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_puerta : Material
{
    //public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    //public materialPara MaterialPara = materialPara.Seccion;

    public tipo_Puerta PuertaTipo;
    public double alto;
    public double ancho;
    public int numero_seguros;
    public int porta_seguros;
    public string descripcion;
    public double espesor_Puerta = 2.5; // centimetros

    public enum tipo_Puerta
    {
        Superior,
        Inferior,
        Bus
    }

    public Mat_puerta()
    {
        nombre_Material = "Puerta de sección";
        MaterialPara = materialPara.Seccion;
        MaterialParaUso = materialParaUso.Metal_mecanico;

        asignarNumeroParte();
    }

    public void asignarNumeroParte()
    {

        switch (PuertaTipo)
        {
            case tipo_Puerta.Superior:
                Numero_Parte = "2TDA010230P0010";
                descripcion = "Puerta superior de sección";
                break;
            case tipo_Puerta.Inferior:
                Numero_Parte = "2TDA010230T007";
                descripcion = "Puerta inferior de sección";
                break;
            case tipo_Puerta.Bus:
                Numero_Parte = "2TDA010024P1002";
                descripcion = "Puerta para bus de la sección";
                break;
        }

        Debug.Log("Número de parte asignado a la puerta: " + Numero_Parte);
    }
}
