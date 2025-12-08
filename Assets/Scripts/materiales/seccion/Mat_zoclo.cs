using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_zoclo : Material
{

    //public materialParaUso MaterialParaUso = materialParaUso.Metal_mecanico;
    //public materialPara MaterialPara = materialPara.Seccion;

    public bool con_zoclo { get; set; }
    public Mat_zoclo()
    {
        nombre_Material = "Zoclo";
        con_zoclo = true;
        Precio = 1000.50;
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
    }
    
}
