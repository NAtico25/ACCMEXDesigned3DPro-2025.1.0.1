using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_piso : Material
{
    public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    public materialPara MaterialPara = materialPara.Seccion;


    public enum piso
    {
        silleta,
        liso
    }

    //void Start()
    //{
    //    MaterialParaUso = materialParaUso.Miscelaneo;
    //    MaterialPara = materialPara.Seccion;
    //}
    // Start is called before the first frame update

}
