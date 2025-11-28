using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ent_seccion : MonoBehaviour
{
    public int no_seccion { get; set; }
    public Mat_zoclo zoclo { get; set; }
    public Mat_piezas_anclaje piezas_Anclaje { get; set; }
    public Mat_orejas_carga orejas_Carga { get; set; }
    public Mat_placas_metal_piso placas_Metal_Piso { get; set; }
    public List<Mat_ang_piso> angulos_piso { get; set; }
    public List<Mat_ang_techo> angulos_techo { get; set; }
    public List<Mat_perfil> perfiles { get; set; } // largo
    public List<Mat_piso.piso> pisos { get; set; } // Si son para silleta o lisos (enum)
    public Mat_cubre_bus cubre_Bus { get; set; }
    public Mat_porta_bus porta_Bus { get; set; }
    public Mat_bus_lateral bus_lateral { get; set; }
    public List<Mat_tapa_bus_lateral> tapas_bus_lateral { get; set; } // largo y ancho
    public Mat_conector_bus conectores_bus { get; set; }
    public List<Mat_puerta> puertas { get; set; } // cada una debe tener sus medidas (alto y ancho) cuando se agrega se debe agregar un numero de seguros y porta seguros (esto lo define el usuario)
    public Mat_pestana_superior pestana_superior { get; set; } // la cosa que cubre la etiqueta roja de arriba
    public Mat_angulo_anclaje angulos_anclaje { get; set; } // son las L
    public Mat_conector_sugestion conectores_sujecion { get; set; }



    // cuando se agrega una silleta se debe agregar piso, porta clemas, clemas, guia de silleta, carretillas, acrilicos separadores, clemas de fuerza.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        no_seccion = 1;
        zoclo = new Mat_zoclo();
        piezas_Anclaje = new Mat_piezas_anclaje();
        orejas_Carga = new Mat_orejas_carga();
        placas_Metal_Piso = new Mat_placas_metal_piso();

        angulos_piso = new List<Mat_ang_piso>();
        angulos_techo = new List<Mat_ang_techo>();
        perfiles = new List<Mat_perfil>();
        pisos = new List<Mat_piso.piso>();

        cubre_Bus = new Mat_cubre_bus();
        porta_Bus = new Mat_porta_bus();
        bus_lateral = new Mat_bus_lateral();
        tapas_bus_lateral = new List<Mat_tapa_bus_lateral>();

        conectores_bus = new Mat_conector_bus();
        puertas = new List<Mat_puerta>();
        pestana_superior = new Mat_pestana_superior();
        angulos_anclaje = new Mat_angulo_anclaje();
        conectores_sujecion = new Mat_conector_sugestion();
    }



}
