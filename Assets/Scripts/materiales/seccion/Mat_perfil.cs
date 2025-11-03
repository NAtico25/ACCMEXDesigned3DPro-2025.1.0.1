using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_perfil : Material
{
    // Start is called before the first frame update
    public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    public materialPara MaterialPara = materialPara.Seccion;

    public double largo { get; set; }
}
