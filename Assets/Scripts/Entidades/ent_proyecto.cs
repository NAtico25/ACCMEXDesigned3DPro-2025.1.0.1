using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ent_proyecto : MonoBehaviour
{
    public int idProyecto { get; set; }
    public string nombreProyecto { get; set; }
    public string clienteProyecto { get; set; }
    public bool dadoAltaProyecto { get; set; }
    public DateTime fechaProyecto { get; set; }
    public byte[] LayoutProyecto { get; set; }
    public byte[] documentoCotizacion { get; set; }
    public double gastosProyecto { get; set; }
}
