using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_cubre_bus : Material
{
    // Start is called before the first frame update
    public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    public materialPara MaterialPara = materialPara.Seccion;

    public int cantidad { get; set; }
}
