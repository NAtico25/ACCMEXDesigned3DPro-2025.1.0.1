using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_tapa_bus_lateral : Material
{
    // Start is called before the first frame update
    public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    public materialPara MaterialPara = materialPara.Seccion;

    public double largo { get; set; }
    public double ancho { get; set; }
}
