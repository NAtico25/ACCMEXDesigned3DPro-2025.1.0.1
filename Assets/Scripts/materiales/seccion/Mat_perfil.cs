using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_perfil : Material
{
    // Start is called before the first frame update

    public double largo;
    public int cantidad;    

    public Mat_perfil()
    {
        nombre_Material = "Perfil de sección";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Seccion;
        //Precio = 1750.00;
        largo = 0;
        cantidad = 1;
    }
}
