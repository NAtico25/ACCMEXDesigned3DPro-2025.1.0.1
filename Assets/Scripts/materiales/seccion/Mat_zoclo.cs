using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_zoclo : Material
{
    public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    public materialPara MaterialPara = materialPara.Seccion;
    public bool con_zoclo { get; set; }
}
