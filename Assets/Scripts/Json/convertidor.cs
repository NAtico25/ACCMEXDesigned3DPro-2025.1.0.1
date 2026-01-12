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
            datos.secciones[i].piso_Seccion = ent_Proyecto.seccionesProyecto[i].piso_Seccion;
            datos.secciones[i].pisos = ent_Proyecto.seccionesProyecto[i].pisos;
            datos.secciones[i].cubre_Bus = ent_Proyecto.seccionesProyecto[i].cubre_Bus;
            datos.secciones[i].porta_Bus = ent_Proyecto.seccionesProyecto[i].porta_Bus;
            datos.secciones[i].bus_lateral = ent_Proyecto.seccionesProyecto[i].bus_lateral;
            datos.secciones[i].conectores_bus = ent_Proyecto.seccionesProyecto[i].conectores_bus;
            datos.secciones[i].puertas = ent_Proyecto.seccionesProyecto[i].puertas;
            datos.secciones[i].pestana_superior = ent_Proyecto.seccionesProyecto[i].pestana_superior;
            datos.secciones[i].angulos_anclaje = ent_Proyecto.seccionesProyecto[i].angulos_anclaje;
            datos.secciones[i].conectores_sujecion = ent_Proyecto.seccionesProyecto[i].conectores_sujecion;
            datos.secciones[i].tapa_trasera_seccion = ent_Proyecto.seccionesProyecto[i].tapa_trasera_seccion;
            datos.secciones[i].tapas_laterales_seccion = ent_Proyecto.seccionesProyecto[i].tapas_laterales_seccion;
            datos.secciones[i].tapa_lateral_Inferior_seccion = ent_Proyecto.seccionesProyecto[i].tapa_lateral_Inferior_seccion;
            //datos.secciones[i].tapa_superior_seccion = ent_Proyecto.seccionesProyecto[i].tapa_superior_seccion;
            datos.secciones[i].trabesano_estructural = ent_Proyecto.seccionesProyecto[i].trabesano_estructural;
            datos.secciones[i].tapa_piso_seccion = ent_Proyecto.seccionesProyecto[i].tapa_piso_seccion;
            datos.secciones[i].techo_seccion_ventana_sup = ent_Proyecto.seccionesProyecto[i].techo_seccion_ventana_sup;
            datos.secciones[i].tapa_techo_seccion = ent_Proyecto.seccionesProyecto[i].tapa_techo_seccion;
            datos.secciones[i].techo_seccion_ciego = ent_Proyecto.seccionesProyecto[i].techo_seccion_ciego;
            datos.secciones[i].letrero_Seccion = ent_Proyecto.seccionesProyecto[i].letrero_Seccion;
            datos.secciones[i].bisagras_Puerta = ent_Proyecto.seccionesProyecto[i].bisagras_Puerta;
            datos.secciones[i].acople_Plano = ent_Proyecto.seccionesProyecto[i].acople_Plano;
            datos.secciones[i].acople_L = ent_Proyecto.seccionesProyecto[i].acople_L;
            datos.secciones[i].contraseguro = ent_Proyecto.seccionesProyecto[i].contraseguro;
            datos.secciones[i].soporte_Aislante_Bus = ent_Proyecto.seccionesProyecto[i].soporte_Aislante_Bus;
            datos.secciones[i].base_Tapa_Trasera = ent_Proyecto.seccionesProyecto[i].base_Tapa_Trasera;
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

    public static json_usuario ConvertirUsuario(ent_usuario ent_Usuario)
    {
        json_usuario jsonUsuario = new json_usuario
        {
            usuario = ent_Usuario.usuario,
            rol = ent_Usuario.rol,
            id_usuario = ent_Usuario.id_usuario,
        };
        return jsonUsuario;
    }
}
