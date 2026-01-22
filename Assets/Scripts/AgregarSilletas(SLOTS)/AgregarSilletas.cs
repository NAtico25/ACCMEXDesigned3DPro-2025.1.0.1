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
        // Validar rango
        if (startSlot < 0 || startSlot + size > slots.Count)
            return false;

        // VALIDAR SI HAY ALGÚN SLOT OCUPADO
        for (int i = startSlot; i < startSlot + size; i++)
        {
            SlotsDrop3D s = slots[i].GetComponent<SlotsDrop3D>();
            if (s.ocupado)
            {
                Debug.Log("Slot ocupado: " + slots[i].name);
                return false;
            }
        }

        // Crear silleta
        Transform slotBase = slots[startSlot];
        GameObject silleta = Instantiate(silletaPrefab, slotBase);
        silleta.transform.localPosition = localPosOffset;
        silleta.transform.localRotation = Quaternion.identity;

        // Configurar silleta
        SilletaInstanciada si = silleta.GetComponent<SilletaInstanciada>();
        si.startSlot = startSlot;
        si.size = size;
        si.slotsOcupados = new SlotsDrop3D[size];

        // Marcar slots como ocupados
        for (int i = 0; i < size; i++)
        {
            SlotsDrop3D s = slots[startSlot + i].GetComponent<SlotsDrop3D>();
            s.ocupado = true;
            s.silletaActual = si;
            si.slotsOcupados[i] = s;
        }

        return true;
    }

    public bool TryPlaceSilleta(SilletaInstanciada silleta, int startSlot)
    {
        int size = silleta.size;

        // validar rango
        if (startSlot < 0 || startSlot + size > slots.Count)
            return false;

        // validar espacio
        for (int i = startSlot; i < startSlot + size; i++)
        {
            if (slots[i].GetComponent<SlotsDrop3D>().ocupado)
                return false;
        }

        // colocar
        silleta.startSlot = startSlot;
        silleta.slotsOcupados = new SlotsDrop3D[size];

        for (int i = 0; i < size; i++)
        {
            SlotsDrop3D s = slots[startSlot + i].GetComponent<SlotsDrop3D>();
            s.ocupado = true;
            silleta.slotsOcupados[i] = s;
        }

        // snap exacto al slot
        silleta.transform.SetParent(slots[startSlot]);
        silleta.transform.localPosition = Vector3.zero;

        silleta.lastValidPosition = silleta.transform.position;

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
