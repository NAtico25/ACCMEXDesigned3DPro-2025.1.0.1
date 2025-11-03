using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_porta_clemas : Material
{
    public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    public materialPara MaterialPara = materialPara.Silleta;

    public int cantidad { get; set; }
}
