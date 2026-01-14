using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inpectorDinamico : MonoBehaviour
{
    public GameObject textPrefap;
    public Transform contentPanel;

    
    public void MostrarObjeto(object obj)
    {
        Limpiar();

        if (obj == null)
        {
            CrearLinea("Objeto es NULL");
            return;
        }

        CrearLinea($"<b>{obj.GetType().Name}</b>");

        MostrarPropiedades(obj, 1);
    }

    //Se va a reacer codigo
    void MostrarPropiedades(object obj, int indentLevel)
    {
        var properties = obj.GetType().GetProperties();  //Nota: igual se puede probar con BindingFlags.Public | BindingFlags.Instance dentro de GetProperties() pero aun no estoy seguro de como funciona asi que de momento lo dejo asi
        foreach (var property in properties) 
        {
            object propertyValue = null;

            try
            {
                propertyValue = property.GetValue(obj);
            }
            catch
            {
                //CrearLinea($"{Indent(indentLevel)}{property.Name}: <no soportado>");
                continue;
            }

            if (propertyValue == null)
            {
                CrearLinea($"{Indent(indentLevel)}{property.Name}: NULL");
                continue;
            }

            #region Ignorar propiedades especificas
            if (typeof(UnityEngine.Object).IsAssignableFrom(property.PropertyType))
                continue;

            // Ignorar propiedades heredadas que no son tuyas
            if (property.DeclaringType != obj.GetType())
                continue;

            if (property.GetIndexParameters().Length > 0)
                continue;
            #endregion

            if (propertyValue is Enumerable && propertyValue.GetType() != typeof(string))
            {
                CrearLinea($"{Indent(indentLevel)}{property.Name}: (Lista)");
                IEnumerable lista = (IEnumerable)propertyValue;
                int index = 0;
                foreach (var item in lista)
                {
                    CrearLinea($"{Indent(indentLevel + 1)}[{index}]");
                    MostrarSubObjeto(item, indentLevel + 2);
                    index++;
                }
                continue;
            }

            // En caso de que sea un objeto derivado de otra clase Mat_Nombre de la clase se mostraran sus propiedades
            if (!property.PropertyType.IsPrimitive && property.PropertyType != typeof(string) && !property.PropertyType.IsEnum)
            {
                CrearLinea($"{Indent(indentLevel)}{property.Name}:");
                MostrarSubObjeto(propertyValue, indentLevel + 1);
                continue;
            }

            CrearLinea($"{Indent(indentLevel)}{property.Name}: {propertyValue}");
        }
    }

    void MostrarSubObjeto(object subObj, int indent)
    {
        if (subObj == null)
        {
            CrearLinea($"{Indent(indent)}NULL");
            return;
        }

        var subProps = subObj.GetType().GetProperties();

        foreach (var prop in subProps)
        {
            #region Ignorar propiedades especificas
            if (typeof(UnityEngine.Object).IsAssignableFrom(prop.PropertyType))
                continue;

            if (prop.DeclaringType != subObj.GetType())
                continue;

            if (prop.GetIndexParameters().Length > 0)
                continue;
            #endregion

            object valor = prop.GetValue(subObj);

            CrearLinea($"{Indent(indent)}{prop.Name}: {valor}");
        }
    }

    void CrearLinea(string texto)
    {
        var go = Instantiate(textPrefap, contentPanel);
        go.GetComponent<TextMeshProUGUI>().text = texto;
    }

    string Indent(int level)
    {
        return new string(' ', level * 4);
    }

    void Limpiar()
    {
        foreach (Transform t in contentPanel)
            Destroy(t.gameObject);
    }

    public void Guardar(ent_proyecto ent_Proyecto)
    {
        ent_Proyecto.LayoutProyecto = convertidor.ConvertirJson(ent_Proyecto);
        //string json = JsonUtility.ToJson(ent_Proyecto.LayoutProyecto, true);
        
    }
    void Start()
    {
        //ent_proyecto proyectoEjemplo = new ent_proyecto
        //{
        //    idProyecto = 1,
        //    nombreProyecto = "Proyecto de Ejemplo",
        //    clienteProyecto = "Cliente XYZ",
        //    dadoAltaProyecto = true,
        //    fechaProyecto = System.DateTime.Now,
        //    gastosProyecto = 1500.75,
        //    seccionesProyecto = new ent_seccion[]
        //    {
        //        new ent_seccion
        //        {
        //            nombre_Seccion = "Seccion A" ,
        //            no_seccion = 1,

        //            zoclo = new Mat_zoclo
        //            {
        //                con_zoclo = true
        //            },
        //            piezas_Anclaje = new Mat_piezas_anclaje
        //            {
        //                cantidad = 10
        //            },
        //            angulos_piso = new List<Mat_ang_piso>
        //            {
        //                new Mat_ang_piso
        //                { 
        //                    //nombre_Material = "Angulo para piso",
        //                    //MaterialParaUso = Material.materialParaUso.Metal_mecanico,
        //                    //MaterialPara = Material.materialPara.Seccion,
        //                    //Precio = 1800.25,
        //                    //largo = 20,
        //                    //ancho = 4 
        //                },
        //                new Mat_ang_piso
        //                {
        //                    //nombre_Material = "Angulo para piso",
        //                    //MaterialParaUso = Material.materialParaUso.Metal_mecanico,
        //                    //MaterialPara = Material.materialPara.Seccion,
        //                    //Precio = 1800.25,
        //                    //largo = 50, 
        //                    //ancho = 2 
        //                }
        //            },
        //            angulos_techo = new List<Mat_ang_techo>
        //            {
        //                new Mat_ang_techo
        //                {

        //                },
        //                new Mat_ang_techo
        //                {

        //                }
        //            },
        //            perfiles = new List<Mat_perfil>
        //            {
        //                new Mat_perfil
        //                {
        //                },
        //                new Mat_perfil
        //                {
        //                } 
        //            },
        //            piso_Seccion = null,
        //            pisos = new List<Mat_piso>
        //            {
        //                new Mat_piso
        //                {
        //                },
        //                new Mat_piso
        //                {
        //                }
        //            },
        //            puertas = new List<Mat_puerta>
        //            {
        //                new Mat_puerta
        //                {
        //                    PuertaTipo = Mat_puerta.tipo_Puerta.Superior,

        //                },
        //                new Mat_puerta
        //                {
        //                    PuertaTipo = Mat_puerta.tipo_Puerta.Inferior,
        //                }
        //            },
        //            techo_seccion_ventana_sup = new Mat_techo_seccion_ventana_sup(false)
        //            {

        //            },
        //            tapa_techo_seccion = new Mat_tapa_techo_seccion(true)
        //            {
        //            },
        //            bisagras_Puerta = new List<Mat_bisagras_puerta>
        //            {
        //            },
        //            acople_Plano = new Mat_acople_plano()
        //            {

        //            }

        //        },
        //        new ent_seccion { no_seccion = 2, nombre_Seccion = "Seccion B" }
        //    }
        //};

        //for (int j = 0; j <= proyectoEjemplo.seccionesProyecto.Length - 2; j ++) // debo cambiar el -2 a -1 pero primero debo agregar puertas a la seccion 1 [partiendo de 0 en adelante]
        //{
        //    for (int i = 0; i < proyectoEjemplo.seccionesProyecto[j].puertas.Count; i++)
        //    {
        //        proyectoEjemplo.seccionesProyecto[j].puertas[i].asignarNumeroParte();
        //        Debug.Log($"estamos en {j} con {i}");
        //    }
        //}

        ent_proyecto proyectoEjemplo;

        proyectoEjemplo = convertidor.ToCampo(ProyectoManager.Instance.proyectoNuevo);


        
        Debug.Log("ProyectoManager.Instance: " + (ProyectoManager.Instance == null ? "NULL" : "OK"));
        Debug.Log("proyectoNuevo: " + (ProyectoManager.Instance?.proyectoNuevo == null ? "NULL" : "OK"));

        if (proyectoEjemplo.seccionesProyecto == null)
        {
            Debug.Log("seccionesProyecto es NULL");
        }
        else
        {
            for (int j = 0; j <= proyectoEjemplo.seccionesProyecto.Length - 1; j++) // debo cambiar el -2 a -1 pero primero debo agregar puertas a la seccion 1 [partiendo de 0 en adelante]
            {
                var seccion = proyectoEjemplo.seccionesProyecto[j];

                if (seccion?.puertas == null || seccion.puertas.Count == 0)
                    continue;

                for (int i = 0; i < seccion.puertas.Count; i++)
                {
                    if (seccion.puertas[i] == null)
                        continue;

                    seccion.puertas[i].asignarNumeroParte();
                    Debug.Log($"estamos en {j} con {i}");
                }
            }
        }



            Guardar(proyectoEjemplo);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("Guardando proyecto...");
        }
    }

}
