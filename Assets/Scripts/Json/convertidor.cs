using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public static class convertidor
{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public static byte[] ConvertirJson(ent_proyecto ent_Proyecto)
    {
        datosJsonProyecto datos = new datosJsonProyecto();
        datos.idProyecto = ent_Proyecto.idProyecto;
        datos.nombreProyecto = ent_Proyecto.nombreProyecto;
        datos.clienteProyecto = ent_Proyecto.clienteProyecto;
        datos.dadoAltaProyecto = ent_Proyecto.dadoAltaProyecto;
        datos.gastosProyecto = ent_Proyecto.gastosProyecto;
        datos.secciones = new SeccionData[ent_Proyecto.seccionesProyecto.Length];

        for (int i = 0; i < ent_Proyecto.seccionesProyecto.Length; i++)
        {
            datos.secciones[i] = new SeccionData();
            datos.secciones[i].nombre_Seccion = ent_Proyecto.seccionesProyecto[i].nombre_Seccion;
            datos.secciones[i].no_seccion = ent_Proyecto.seccionesProyecto[i].no_seccion;
            datos.secciones[i].zoclo = ent_Proyecto.seccionesProyecto[i].zoclo;
            datos.secciones[i].piezas_Anclaje = ent_Proyecto.seccionesProyecto[i].piezas_Anclaje;
            datos.secciones[i].orejas_Carga = ent_Proyecto.seccionesProyecto[i].orejas_Carga;
            datos.secciones[i].placas_Metal_Piso = ent_Proyecto.seccionesProyecto[i].placas_Metal_Piso;
            datos.secciones[i].angulos_piso = ent_Proyecto.seccionesProyecto[i].angulos_piso;
            datos.secciones[i].angulos_techo = ent_Proyecto.seccionesProyecto[i].angulos_techo;
            datos.secciones[i].perfiles = ent_Proyecto.seccionesProyecto[i].perfiles;
            datos.secciones[i].pisos = ent_Proyecto.seccionesProyecto[i].pisos;
            datos.secciones[i].cubre_Bus = ent_Proyecto.seccionesProyecto[i].cubre_Bus;
            datos.secciones[i].porta_Bus = ent_Proyecto.seccionesProyecto[i].porta_Bus;
            datos.secciones[i].bus_lateral = ent_Proyecto.seccionesProyecto[i].bus_lateral;
            datos.secciones[i].tapas_bus_lateral = ent_Proyecto.seccionesProyecto[i].tapas_bus_lateral;
            datos.secciones[i].conectores_bus = ent_Proyecto.seccionesProyecto[i].conectores_bus;
            datos.secciones[i].puertas = ent_Proyecto.seccionesProyecto[i].puertas;
            datos.secciones[i].pestana_superior = ent_Proyecto.seccionesProyecto[i].pestana_superior;
            datos.secciones[i].angulos_anclaje = ent_Proyecto.seccionesProyecto[i].angulos_anclaje;
            datos.secciones[i].conectores_sujecion = ent_Proyecto.seccionesProyecto[i].conectores_sujecion;
        }


    string json = JsonUtility.ToJson(datos, true);
        string path = Application.persistentDataPath + "/proyecto_" + ent_Proyecto.idProyecto + ".json";
        File.WriteAllText(path, json);
        Debug.Log("Guardando proyecto en: " + path);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
        return bytes;
    }
    public static ent_proyecto ConvertirDesdeBytes(byte[] bytes)
    {
        // byte[] → string
        string json = System.Text.Encoding.UTF8.GetString(bytes);

        // string → objeto
        ent_proyecto proyecto = JsonUtility.FromJson<ent_proyecto>(json);

        return proyecto;
    }

}
