using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class datosJsonProyecto
{
    public int idProyecto;
    public string nombreProyecto;
    public string clienteProyecto;
    public bool dadoAltaProyecto;
    public DateTime fechaProyecto;
    public byte[] LayoutProyecto;
    public byte[] documentoCotizacion;
    public double gastosProyecto;

    public SeccionData[] secciones;
}

 
[System.Serializable]
public class SeccionData
{
    public string nombre_Seccion = "Seccion";
    public int no_seccion;
    public Mat_zoclo zoclo;
    public Mat_piezas_anclaje piezas_Anclaje;
    public Mat_orejas_carga orejas_Carga;
    public Mat_placas_metal_piso placas_Metal_Piso;
    public List<Mat_ang_piso> angulos_piso;
    public List<Mat_ang_techo> angulos_techo;
    public List<Mat_perfil> perfiles; // largo
    public List<Mat_piso> pisos; // Si son para silleta o lisos (enum)
    public Mat_cubre_bus cubre_Bus;
    public Mat_porta_bus porta_Bus;
    public Mat_bus_lateral bus_lateral;
    //public List<Mat_tapa_bus_lateral> tapas_bus_lateral; // largo y ancho
    public Mat_conector_bus conectores_bus;
    public List<Mat_puerta> puertas; // cada una debe tener sus medidas (alto y ancho) cuando se agrega se debe agregar un numero de seguros y porta seguros (esto lo define el usuario)
    public Mat_pestana_superior pestana_superior; // la cosa que cubre la etiqueta roja de arriba
    public Mat_angulo_anclaje angulos_anclaje; // son las L
    public Mat_conector_sugestion conectores_sujecion;
    public Mat_tapa_trasera_seccion tapa_trasera_seccion;
    public Mat_tapas_laterales_seccion tapas_laterales_seccion;
    public Mat_tapa_lateral_Inferior_seccion tapa_lateral_Inferior_seccion;
    public Mat_tapa_superior_seccion tapa_superior_seccion;
}
