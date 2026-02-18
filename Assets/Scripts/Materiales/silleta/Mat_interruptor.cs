using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_interruptor : Material
{
    public string descripcion;
    public int cantidad;
    public TipoInterruptor tipoInterruptor;
    //public double precio;
    public Mat_interruptor()
    {
        nombre_Material = "Interruptor";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Silleta;
        Precio = 1750.00;
        descripcion = "Describir especificaciones del interruptor";
        cantidad = 1;
    }

    public enum TipoInterruptor
    {
        TipoA,
        TipoB
    }

}
