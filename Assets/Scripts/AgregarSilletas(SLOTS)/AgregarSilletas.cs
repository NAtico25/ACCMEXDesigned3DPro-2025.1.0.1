using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgregarSilletas : MonoBehaviour
{
    //Se crea los campos para que se agreguen los diferentes tipos de silletas
    [Header("Slots dentro del gabinete")]
    public List<Transform> slots = new List<Transform>(); // 12 slots físicos en la seccion

    [Header("Tipos de silletas")]
    public GameObject silleta0_5F; // ocupa 1 espacio
    public GameObject silleta1F; // ocupa 2 espacios
    public GameObject silleta1_5F; // ocupa 3 espacios
    public GameObject silleta2F; // ocupa 4 espacios
    public GameObject silleta2_5F; // ocupa 5 espacios
    public GameObject silleta3F; // ocupa 6 espacios
    public GameObject silleta6F; // ocupa 12 espacios

    //Cuantas secciones hay puestas
    [Header("Prefabs")]
    public GameObject slotPrefab;
    public Transform slotContainer;

    public int slotsPorSeccion = 12;
    public float separacionX = 0.35f;

    [Header("UI")]
    public Text estadoTexto;

    //Dice cuantos slots hay ocupado
    private List<bool> slotOcupado = new List<bool>();
    //Hara la funcion de eliminar silleta solo en el anterior en este no funciona
    private List<GameObject> silletasInstanciadas = new List<GameObject>();

    public TableroManager manager;

    void Start()
    {

    }

    public bool PlaceSilleta(int startSlot, GameObject silletaPrefab, int size, Vector3 localPosOffset)
    {
        Transform slot = slots[startSlot];

        Debug.Log("Instanciando silleta en: " + slot.name);

        // CLON del prefab del botón
        GameObject silleta = Instantiate(
            silletaPrefab,
            slot.position,
            slot.rotation,
            slotContainer.parent
        );

        silleta.transform.localScale = Vector3.one;
        silleta.transform.position += localPosOffset;

        Debug.Log("Silleta creada correctamente");

        return true;
    }

    public void ColocarSilletaAuto(GameObject silletaPrefab, int size, Vector3 localPosOffset)
    {
        int slotInicio = BuscarEspacioDisponible(size);
        if (slotInicio == -1)
        {
            if (estadoTexto != null)
                estadoTexto.text = "No hay espacio disponible";
            return;
        }

        PlaceSilleta(slotInicio, silletaPrefab, size, localPosOffset);

        if (estadoTexto != null)
            estadoTexto.text = $"Silleta colocada en posición {slotInicio + 1}";
    }

    private int BuscarEspacioDisponible(int size)
    {
        for (int i = 0; i <= slots.Count - size; i++)
        {
            bool libre = true;
            for (int j = 0; j < size; j++)
            {
                if (slotOcupado[i + j])
                {
                    libre = false;
                    break;
                }
            }
            if (libre) return i;
        }
        return -1;
    }

    public void EliminarUltimaSilleta()
    {
        if (silletasInstanciadas.Count == 0)
        {
            if (estadoTexto != null)
                estadoTexto.text = "No hay silletas para eliminar";
            return;
        }

        GameObject ultima = silletasInstanciadas[silletasInstanciadas.Count - 1];
        Silleta_individual s = ultima.GetComponent<Silleta_individual>();
        if (s != null)
        {
            for (int i = s.startSlot; i < s.startSlot + s.size; i++)
                slotOcupado[i] = false;
        }

        Destroy(ultima);
        silletasInstanciadas.RemoveAt(silletasInstanciadas.Count - 1);

        if (estadoTexto != null)
            estadoTexto.text = $"Silleta eliminada (quedan {silletasInstanciadas.Count})";
    }

    void OnDrawGizmos()
    {
        if (slots == null) return;
        Gizmos.color = Color.green;
        foreach (Transform slot in slots)
        {
            if (slot != null)
                Gizmos.DrawWireCube(slot.position, new Vector3(0.324f, 0.124f, 0.226f));
        }
    }
}
