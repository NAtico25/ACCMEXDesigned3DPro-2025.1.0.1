using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        if(datos.secciones != null)
        {
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
    public static ent_proyecto ToCampo(datosJsonProyecto p) => new ent_proyecto
    {
        idProyecto = p.idProyecto,
        nombreProyecto = p.nombreProyecto,
        clienteProyecto = p.clienteProyecto,
        dadoAltaProyecto = p.dadoAltaProyecto,
        fechaProyecto = p.fechaProyecto,
        LayoutProyecto = p.LayoutProyecto,
        documentoCotizacion = p.documentoCotizacion,
        gastosProyecto = p.gastosProyecto,
        seccionesProyecto = p.secciones?.Select(Tocampo).ToArray()
    };
    public static ent_seccion Tocampo(SeccionData s) => new ent_seccion
    {
        nombre_Seccion = s.nombre_Seccion,
        no_seccion = s.no_seccion,
        zoclo = s.zoclo,
        piezas_Anclaje = s.piezas_Anclaje,
        orejas_Carga = s.orejas_Carga,
        placas_Metal_Piso = s.placas_Metal_Piso,
        angulos_piso = s.angulos_piso,
        angulos_techo = s.angulos_techo,
        perfiles = s.perfiles,
        piso_Seccion = s.piso_Seccion,
        pisos = s.pisos,
        cubre_Bus = s.cubre_Bus,
        porta_Bus = s.porta_Bus,
        bus_lateral = s.bus_lateral,
        conectores_bus = s.conectores_bus,
        puertas = s.puertas,
        pestana_superior = s.pestana_superior,
        angulos_anclaje = s.angulos_anclaje,
        conectores_sujecion = s.conectores_sujecion,
        tapa_trasera_seccion = s.tapa_trasera_seccion,
        tapas_laterales_seccion = s.tapas_laterales_seccion,
        tapa_lateral_Inferior_seccion = s.tapa_lateral_Inferior_seccion,
        trabesano_estructural = s.trabesano_estructural,
        tapa_piso_seccion = s.tapa_piso_seccion,
        techo_seccion_ventana_sup = s.techo_seccion_ventana_sup,
        tapa_techo_seccion = s.tapa_techo_seccion,
        techo_seccion_ciego = s.techo_seccion_ciego,
        letrero_Seccion = s.letrero_Seccion,
        bisagras_Puerta = s.bisagras_Puerta,
        acople_Plano = s.acople_Plano,
        acople_L = s.acople_L,
        contraseguro = s.contraseguro,
        soporte_Aislante_Bus = s.soporte_Aislante_Bus,
        base_Tapa_Trasera = s.base_Tapa_Trasera
    };
    public static datosJsonProyecto ToCampo(ent_proyecto p) => new datosJsonProyecto
    {
        idProyecto = p.idProyecto,
        nombreProyecto = p.nombreProyecto,
        clienteProyecto = p.clienteProyecto,
        dadoAltaProyecto = p.dadoAltaProyecto,
        fechaProyecto = p.fechaProyecto,
        LayoutProyecto = p.LayoutProyecto,
        documentoCotizacion = p.documentoCotizacion,
        gastosProyecto = p.gastosProyecto,
        secciones = p.seccionesProyecto?.Select(Tocampo).ToArray()
    };
    public static SeccionData Tocampo(ent_seccion s) => new SeccionData
    {
        nombre_Seccion = s.nombre_Seccion,
        no_seccion = s.no_seccion,
        zoclo = s.zoclo,
        piezas_Anclaje = s.piezas_Anclaje,
        orejas_Carga = s.orejas_Carga,
        placas_Metal_Piso = s.placas_Metal_Piso,
        angulos_piso = s.angulos_piso,
        angulos_techo = s.angulos_techo,
        perfiles = s.perfiles,
        piso_Seccion = s.piso_Seccion,
        pisos = s.pisos,
        cubre_Bus = s.cubre_Bus,
        porta_Bus = s.porta_Bus,
        bus_lateral = s.bus_lateral,
        conectores_bus = s.conectores_bus,
        puertas = s.puertas,
        pestana_superior = s.pestana_superior,
        angulos_anclaje = s.angulos_anclaje,
        conectores_sujecion = s.conectores_sujecion,
        tapa_trasera_seccion = s.tapa_trasera_seccion,
        tapas_laterales_seccion = s.tapas_laterales_seccion,
        tapa_lateral_Inferior_seccion = s.tapa_lateral_Inferior_seccion,
        trabesano_estructural = s.trabesano_estructural,
        tapa_piso_seccion = s.tapa_piso_seccion,
        techo_seccion_ventana_sup = s.techo_seccion_ventana_sup,
        tapa_techo_seccion = s.tapa_techo_seccion,
        techo_seccion_ciego = s.techo_seccion_ciego,
        letrero_Seccion = s.letrero_Seccion,
        bisagras_Puerta = s.bisagras_Puerta,
        acople_Plano = s.acople_Plano,
        acople_L = s.acople_L,
        contraseguro = s.contraseguro,
        soporte_Aislante_Bus = s.soporte_Aislante_Bus,
        base_Tapa_Trasera = s.base_Tapa_Trasera
    };
}
