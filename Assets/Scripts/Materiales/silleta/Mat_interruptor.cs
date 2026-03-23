using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mat_interruptor : Material
{
    //Nuevo test
    public string numeroParteMandoReenviado;
    public string descripcionMandoReenviado;
    public double precioMandoReenviado;
    public string descripcionInterruptor;
    public int cantidad;
    public TipoInterruptor tipoInterruptor;
    //public double precio;
    public Mat_interruptor()
    {
        nombre_Material = "Interruptor";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Silleta;
        Precio = 1750.00;
        descripcionInterruptor = "Describir especificaciones del interruptor";
        cantidad = 1;

    }

    public enum TipoInterruptor
    {
        TipoA,
        TipoB
    }

}
