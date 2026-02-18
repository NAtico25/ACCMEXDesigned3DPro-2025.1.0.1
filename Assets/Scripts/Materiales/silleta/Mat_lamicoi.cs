using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

[System.Serializable]
public class Mat_lamicoi : Material
{

    public string descripcion;
    public int cantidadComponentes;
    public ComponenteLamicoi[] componentes;
    public ColorLampara[] colorLampara;
    public Mat_lamicoi()
    {
        nombre_Material = "Lamicoi";
        MaterialParaUso = materialParaUso.Metal_mecanico;
        MaterialPara = materialPara.Silleta;
        Precio = 1750.00;
        descripcion = "Describir especificaciones del lamicoi";
        cantidadComponentes = 2;
    }

    public enum ComponenteLamicoi
    {
        Boton,
        Lampara,
        Selector,
        BotonRetroiluminado
    }

    public enum ColorLampara
    {
        Rojo,
        Verde,
        Azul,
        Amarillo,
        Blanco
    }
    public enum TipoLamicoi
    {
        Doble,
        Triple,
        Cuadrupe,
        Quituple
    }
}
