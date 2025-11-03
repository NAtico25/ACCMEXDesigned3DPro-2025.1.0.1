using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_conector_sugestion : Material
{
    public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    public materialPara MaterialPara = materialPara.Seccion;

    public int cantidad { get; set; }
}
