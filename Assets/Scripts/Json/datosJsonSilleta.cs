using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static Silleta;

[System.Serializable]
public class datosJsonSilleta
{
    public string path;

    #region Getters y Setters publicos
    public string PosicionSilleta;
    public Mat_piso.piso piso;
    public Mat_porta_clemas portaClemas;
    public Mat_clemas clemas;
    public Mat_guia_silleta guiaSilleta;
    public Mat_carretillas carretillas;
    public Mat_acrilicos_separadores acrilicosSeparadores;
    public Mat_clemas_fuerza clemas_fuerza;
    public List<Mat_interruptor> interruptores;
    public List<Mat_adicionales> adicionales;
    public TipoSilleta tipoSilleta;
    public Capacidad capacidad;
    public string Nombre;
    public string NumeroParte;
    public string Descripcion;
    public double Precio;
    public Vector3 Coordenadas;
    public Quaternion Rotacion;
    #endregion

}
