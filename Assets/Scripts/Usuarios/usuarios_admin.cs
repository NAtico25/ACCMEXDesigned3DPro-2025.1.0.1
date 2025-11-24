using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class usuarios_admin : MonoBehaviour
{
    public GameObject prefabItem;
    public Transform content;
    public UnityEngine.UI.Button botonCrearUsuario;
    public TMP_InputField busqueda;
    //public TMP_Dropdown dropdownOrdenar;


    private List<prefap_usuario> items = new List<prefap_usuario>();

    public void CrearLista(DataTable tabla)
    {
        // Limpia los objetos previos
        foreach (Transform child in content)
            Destroy(child.gameObject);

        items.Clear();

        // Crear los prefabs 
        foreach (DataRow row in tabla.Rows)
        {
            // Instanciar prefab
            GameObject nuevo = Instantiate(prefabItem, content);

            // Obtener el script del prefab
            Debug.Log("Creando item para usuario: " + row["NombreUsuario"].ToString());
            prefap_usuario item = nuevo.GetComponent<prefap_usuario>();

            // Asignar datos de la BD
            int id = int.Parse(row["IdUsuario"].ToString());
            string nombre = row["NombreUsuario"].ToString();
            string rol = row["NombreRol"].ToString();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");

            Debug.Log($"Asignando datos al item: Id={id}, NombreUsuario={nombre}, Rol={rol}");
            item.SetData(id, nombre, fecha, rol);

            items.Add(item); // Agregar a la lista de items para que pueda usarla en el sistema de busqueda :D ;v //
        }
    }
    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("Cargando usuarios...");
        DataTable usuarios = await CargarUsuarios();

        Debug.Log("Usuarios cargados.");
        if (usuarios != null)
            CrearLista(usuarios);


        botonCrearUsuario.onClick.AddListener(() =>
        {
            Debug.Log("Botón Crear usuario presionado.");
            // Lógica para crear un nuevo proyecto
        });

        busqueda.onValueChanged.AddListener(Filtrar);
        //dropdownOrdenar.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async Task<DataTable> CargarUsuarios()
    {
        DataTable dt_Proyectos = null;
        try
        {
            dt_Proyectos = await neg_usuarios.neg_obtenerUsuarios();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al cargar usuarios: " + ex.Message);
        }
        return dt_Proyectos;
    }

    private async Task<int> CrearUsuario(ent_proyecto nuevoProyecto)
    {
        int resultado = 0;
        try
        {
            resultado = await neg_proyectos.neg_crearProyecto(nuevoProyecto);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al crear proyecto: " + ex.Message);
        }
        return resultado;
    }

    void Filtrar(string texto)
    {
        string filtro = texto.ToLower();

        // Si está vacío, mostrar todo
        if (string.IsNullOrWhiteSpace(filtro))
        {
            foreach (var item in items)
                item.gameObject.SetActive(true);
            return;
        }

        // Filtrar normalmente
        foreach (var item in items)
        {
            bool coincide = item.usuario.text.ToLower().Contains(filtro);
            item.gameObject.SetActive(coincide);
        }
    }

    void OnDropdownValueChanged(int index)
    {
        // Dependiendo del índice, ejecuta la acción
        switch (index)
        {
            case 0: // Orden Alfabetico
                OrdenarAlfabeticamente();
                break;
            case 1: // None
                OrdenarFecha();
                break;
            

        }
    }

    void OrdenarAlfabeticamente(bool ascendente = true)
    {
        if (ascendente)
        {
            items.Sort((a, b) => a.usuario.text.CompareTo(b.usuario.text));
        }
        else
        {
            items.Sort((a, b) => b.usuario.text.CompareTo(a.usuario.text));
        }

        // Opcional: actualizar la posición en la UI si es necesario
        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.SetSiblingIndex(i);
        }
        Debug.Log("Lista ordenada alfabéticamente.");
    }

    void OrdenarFecha(bool ascendente = true)
    {
        if (ascendente)
        {
            items.Sort((a, b) => DateTime.Parse(a.fechaUsuario.text).CompareTo(DateTime.Parse(b.fechaUsuario.text)));
        }
        else
        {
            items.Sort((a, b) => DateTime.Parse(b.fechaUsuario.text).CompareTo(DateTime.Parse(a.fechaUsuario.text)));
        }

        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.SetSiblingIndex(i);
        }
        Debug.Log("Lista ordenada por fecha.");
    }
}
