using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    // Start is called before the first frame update
    public materialParaUso MaterialParaUso { get; set; }
    public materialPara MaterialPara { get; set; }

    public double Precio { get; set; }


    public enum materialParaUso
    {
        Miscelaneo,
        Equipo,
        Metal_mecanico
    }

    public enum materialPara
    {
        Silleta,
        Seccion
    }
}
