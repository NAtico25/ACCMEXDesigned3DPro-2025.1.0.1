using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Permissions;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class proyectos : MonoBehaviour
{
    public GameObject prefabItem;  
    public Transform content;
    public Button botonCrearProyecto;
    public TMP_InputField busqueda;
    public TMP_Dropdown dropdownOrdenar;

    private List<prefap_proyecto> items = new List<prefap_proyecto>();

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
            Debug.Log("Creando item para proyecto: " + row["Nombre"].ToString());
            prefap_proyecto item = nuevo.GetComponent<prefap_proyecto>();

            // Asignar datos de la BD
            int id = int.Parse(row["IdProyecto"].ToString());
            string nombre = row["Nombre"].ToString();
            DateTime fechadate = (DateTime)row["Fecha"];
            string fecha = fechadate.ToString("dd/MM/yyyy");
            string cliente = row["Cliente"].ToString();

            Debug.Log($"Asignando datos al item: Id={id}, Nombre={nombre}, Fecha={fecha}");
            item.SetData(id, nombre, fecha, cliente);

            items.Add(item); // Agregar a la lista de items para que pueda usarla en el sistema de busqueda :D ;v //
        }
    }

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
            SceneManager.LoadScene("Inicio-Project");
        });

        busqueda.onValueChanged.AddListener(Filtrar);
        dropdownOrdenar.onValueChanged.AddListener(OnDropdownValueChanged);
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
            dt_Proyectos = await neg_proyectos.neg_obtenerProyectos();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al cargar proyectos: " + ex.Message);
        }
        return dt_Proyectos;
    }

    private async Task<int> CrearProyecto(ent_proyecto nuevoProyecto)
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
            bool coincide = item.nombreProyecto.text.ToLower().Contains(filtro);
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
            case 2:
                OrdenarClienteAlfabeticamente();
                break;
            case 3:
                OrdenarFavoritos();
                break;

        }
    }

    void OrdenarAlfabeticamente(bool ascendente = true)
    {
        if (ascendente)
        {
            items.Sort((a, b) => a.nombreProyecto.text.CompareTo(b.nombreProyecto.text));
        }
        else
        {
            items.Sort((a, b) => b.nombreProyecto.text.CompareTo(a.nombreProyecto.text));
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
            items.Sort((a, b) => DateTime.Parse(a.fechaProyecto.text).CompareTo(DateTime.Parse(b.fechaProyecto.text)));
        }
        else
        {
            items.Sort((a, b) => DateTime.Parse(b.fechaProyecto.text).CompareTo(DateTime.Parse(a.fechaProyecto.text)));
        }

        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.SetSiblingIndex(i);
        }
        Debug.Log("Lista ordenada por fecha.");
    }

    void OrdenarClienteAlfabeticamente(bool ascendente = true)
    {
        if (ascendente)
        {
            items.Sort((a, b) => a.clienteProyecto.text.CompareTo(b.clienteProyecto.text));
        }
        else
        {
            items.Sort((a, b) => b.clienteProyecto.text.CompareTo(a.clienteProyecto.text));
        }

        // Opcional: actualizar la posición en la UI si es necesario
        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.SetSiblingIndex(i);
        }
        Debug.Log("Lista ordenada por cliente.");
    }

    void OrdenarFavoritos()
    {
        items.Sort((a, b) =>
        {
            bool favoritoA = a.botonFavorito.image.sprite == a.iconoFavoritoOn;
            bool favoritoB = b.botonFavorito.image.sprite == b.iconoFavoritoOn;

            if (favoritoA && !favoritoB)
                return -1;
            if (!favoritoA && favoritoB) 
                return 1;

            // 3️⃣ Si ambos son iguales en favorito, ordenar alfabéticamente
            return a.nombreProyecto.text.CompareTo(b.nombreProyecto.text);
        });

        for (int i = 0; i < items.Count; i++)
            items[i].transform.SetSiblingIndex(i);
        Debug.Log("Lista ordenada por favoritos.");
    }
}
