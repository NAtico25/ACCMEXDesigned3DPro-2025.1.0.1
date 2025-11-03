using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_puerta : Material
{
    public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    public materialPara MaterialPara = materialPara.Seccion;

    public double alto { get; set; }
    public double ancho { get; set; }
    public int numero_seguros { get; set; }
    public int porta_seguros { get; set; }
}
