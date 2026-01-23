using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ent_seccion : MonoBehaviour
{
    public string nombre_Seccion = "Seccion";
    public double largo_Seccion = 246; // en centimetros con zoclo
    public double ancho_Seccion = 60; // en centimetros sin tapas laterales
    public double profundidad_Seccion = 45; // en centimetros sin tapa
    public int no_seccion { get; set; }
    public Mat_zoclo zoclo { get; set; } // Obligatorio
    public Mat_piezas_anclaje piezas_Anclaje { get; set; }
    public Mat_orejas_carga orejas_Carga { get; set; } // Obligatorio
    public Mat_placas_metal_piso placas_Metal_Piso { get; set; }
    public List<Mat_ang_piso> angulos_piso { get; set; }
    public List<Mat_ang_techo> angulos_techo { get; set; }
    public List<Mat_perfil> perfiles { get; set; } // largo
    public Mat_piso_seccion piso_Seccion { get; set; } // piso general de la seccion
    public List<Mat_piso> pisos { get; set; } // Si son para silleta o lisos (enum)
    public Mat_cubre_bus cubre_Bus { get; set; }
    public Mat_porta_bus porta_Bus { get; set; }
    public Mat_bus_lateral bus_lateral { get; set; }
    //public List<Mat_tapa_bus_lateral> tapas_bus_lateral { get; set; } // largo y ancho tambien conocida como puerta lateral o puerta de bus
    public Mat_conector_bus conectores_bus { get; set; }
    public List<Mat_puerta> puertas { get; set; } // cada una debe tener sus medidas (alto y ancho) cuando se agrega se debe agregar un numero de seguros y porta seguros (esto lo define el usuario)
    public Mat_pestana_superior pestana_superior { get; set; } // la cosa que cubre la etiqueta roja de arriba
    public Mat_angulo_anclaje angulos_anclaje { get; set; } // son las L
    public Mat_conector_sugestion conectores_sujecion { get; set; }


    // Nuevos datos agregados el dia 17/12/25
    public Mat_tapa_trasera_seccion tapa_trasera_seccion { get; set; }
    public Mat_tapas_laterales_seccion tapas_laterales_seccion { get; set; }
    public Mat_tapa_lateral_Inferior_seccion tapa_lateral_Inferior_seccion { get; set; }
    //public Mat_tapa_superior_seccion tapa_superior_seccion { get; set; }

    // Nuevos datos agregados el dia 07/01/26
    public Mat_trabesano_estructural trabesano_estructural { get; set; }
    public Mat_tapa_piso_seccion tapa_piso_seccion { get; set; }
    public Mat_techo_seccion_ventana_sup techo_seccion_ventana_sup { get; set; }
    public Mat_tapa_techo_seccion tapa_techo_seccion { get; set; }
    public Mat_techo_seccion_ciego techo_seccion_ciego { get; set; }
    public Mat_letrero_seccion letrero_Seccion { get; set; }
    public List<Mat_bisagras_puerta> bisagras_Puerta { get; set; }
    public Mat_acople_plano acople_Plano { get; set; }
    public Mat_acople_l acople_L { get; set; }
    public Mat_contraseguro contraseguro { get; set; }
    public Mat_soporte_aislante_bus soporte_Aislante_Bus { get; set; }
    public Mat_base_tapa_trasera base_Tapa_Trasera { get; set; }


    //Lista
    public List<Material> ObtenerMateriales()
    {
        List<Material> materiales = new List<Material>();

        void AddIfNotNull(Material mat)
        {
            if (mat != null)
                materiales.Add(mat);
        }

        AddIfNotNull(zoclo);
        AddIfNotNull(piezas_Anclaje);
        AddIfNotNull(orejas_Carga);
        AddIfNotNull(placas_Metal_Piso);
        AddIfNotNull(piso_Seccion);
        AddIfNotNull(cubre_Bus);
        AddIfNotNull(porta_Bus);
        AddIfNotNull(bus_lateral);
        AddIfNotNull(conectores_bus);
        AddIfNotNull(pestana_superior);
        AddIfNotNull(angulos_anclaje);
        AddIfNotNull(conectores_sujecion);
        AddIfNotNull(tapa_trasera_seccion);
        AddIfNotNull(tapas_laterales_seccion);
        AddIfNotNull(tapa_lateral_Inferior_seccion);
        AddIfNotNull(trabesano_estructural);
        AddIfNotNull(tapa_piso_seccion);
        AddIfNotNull(techo_seccion_ventana_sup);
        AddIfNotNull(tapa_techo_seccion);
        AddIfNotNull(techo_seccion_ciego);
        AddIfNotNull(letrero_Seccion);
        AddIfNotNull(acople_Plano);
        AddIfNotNull(acople_L);
        AddIfNotNull(contraseguro);
        AddIfNotNull(soporte_Aislante_Bus);
        AddIfNotNull(base_Tapa_Trasera);

        if (perfiles != null) materiales.AddRange(perfiles);
        if (puertas != null) materiales.AddRange(puertas);
        if (pisos != null) materiales.AddRange(pisos);
        if (bisagras_Puerta != null) materiales.AddRange(bisagras_Puerta);

        return materiales;
    }



    //Agregar tapas de seccion, letrero de seccion,  


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
        
    }



}
