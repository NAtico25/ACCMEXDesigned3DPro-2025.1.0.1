using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class proyectosAdmin : MonoBehaviour
{
    public GameObject prefabItem;
    public Transform content;
    public UnityEngine.UI.Button botonCrearProyecto;
    public UnityEngine.UI.Button botonGestionarUsuarios;
    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("Cargando proyectos...");
        DataTable proyectos = await CargarProyectos();

        Debug.Log("Proyectos cargados.");
        if (proyectos != null)
            CrearLista(proyectos);

        botonCrearProyecto.onClick.AddListener(() =>
        {
            Debug.Log("Botón Crear Proyecto presionado.");
            // Lógica para crear un nuevo proyecto
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async Task<DataTable> CargarProyectos()
    {
        DataTable dt_Proyectos = null;
        try
        {
            dt_Proyectos = await neg_proyectos.neg_obtenerTodosProyectos();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al cargar proyectos: " + ex.Message);
        }
        return dt_Proyectos;
    }

    public void CrearLista(DataTable tabla)
    {
        // Limpia los objetos previos
        foreach (Transform child in content)
            Destroy(child.gameObject);

        // Crear los prefabs 
        foreach (DataRow row in tabla.Rows)
        {
            // Instanciar prefab
            GameObject nuevo = Instantiate(prefabItem, content);

            // Obtener el script del prefab
            Debug.Log("Creando item para proyecto: " + row["Nombre"].ToString());
            prefapAdmin_proyecto item = nuevo.GetComponent<prefapAdmin_proyecto>();

            // Asignar datos de la BD
            int id = int.Parse(row["IdProyecto"].ToString());
            string nombre = row["Nombre"].ToString();
            DateTime fechadate = (DateTime)row["Fecha"];
            string fecha = fechadate.ToString("dd/MM/yyyy");
            bool esActivo = (bool)row["DadoAlta"];

            Debug.Log($"Asignando datos al item: Id={id}, Nombre={nombre}, Fecha={fecha}");
            item.SetData(id, nombre, fecha, esActivo);

        }
    }
}
