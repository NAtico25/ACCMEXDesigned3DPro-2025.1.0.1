using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableroManager : MonoBehaviour
{
    [Header("Slots dentro del gabinete")]
    public Transform[] slots; // 12 slots físicos en el gabinete

    [Header("Tipos de silletas")]
    public GameObject componenteTipo1; // ocupa 1 espacio
    public GameObject componenteTipo2; // ocupa 2 espacios
    public GameObject componenteTipo3; // ocupa 4 espacios
    public GameObject componenteTipo4; // ocupa 3 espacios
    public GameObject componenteTipo5; // ocupa  espacios
    public GameObject componenteTipo6; // ocupa  espacios

    [Header("UI")]
    public Text estadoTexto;

    private bool[] slotOcupado;

    //Almacenamiento para eliminar
    private List<GameObject> silletasInstanciadas = new List<GameObject>();


    void Start()
    {
        slotOcupado = new bool[slots.Length];

        if (slots == null || slots.Length == 0)
        {
            // Buscar automáticamente todos los hijos con nombre "Slot"
            Transform slotContainer = transform.Find("SlotContainer");
            if (slotContainer != null)
            {
                slots = new Transform[slotContainer.childCount];
                for (int i = 0; i < slotContainer.childCount; i++)
                    slots[i] = slotContainer.GetChild(i);
            }
        }

        slotOcupado = new bool[slots.Length];
    }

    // Método general para colocar silletas

    public bool PlaceTablero(int startSlot, GameObject silletaPrefab, int size, Vector3 localPosOffset)
    {
        // Verificar si hay espacio suficiente
        if (startSlot + size > slots.Length)
        {
            Debug.LogWarning("No hay suficiente espacio para esta silleta.");
            return false;
        }

        // Comprobar que los slots estén libres
        for (int i = startSlot; i < startSlot + size; i++)
        {
            if (slotOcupado[i])
            {
                Debug.LogWarning("Uno o más slots están ocupados.");
                return false;
            }
        }

        // Instanciar la silleta en el primer slot
        Transform firstSlot = slots[startSlot];
        GameObject silleta = Instantiate(silletaPrefab, firstSlot.position, firstSlot.rotation, firstSlot);

        Silleta_individual info = silleta.AddComponent<Silleta_individual>();
        info.startSlot = startSlot;
        info.size = size;

        //Eliminar
        silletasInstanciadas.Add(silleta);

        // Asignar solo la posición local personalizada
        silleta.transform.localPosition = localPosOffset;

        // Marcar los slots como ocupados
        for (int i = startSlot; i < startSlot + size; i++)
            slotOcupado[i] = true;

        return true;
    }

    // Coloca la silleta en el primer hueco disponible con offset
    public void ColocarTableroAuto(GameObject silletaPrefab, int size, Vector3 localPosOffset)
    {
        int slotInicio = BuscarEspacioDisponible(size);
        if (slotInicio == -1)
        {
            if (estadoTexto != null)
                estadoTexto.text = "No hay espacio disponible";
            return;
        }

        PlaceTablero(slotInicio, silletaPrefab, size, localPosOffset);

        if (estadoTexto != null)
            estadoTexto.text = $"Silleta colocada en posición {slotInicio + 1}";
    }


    private int BuscarEspacioDisponible(int size)
    {
        for (int i = 0; i < slots.Length - size + 1; i++)
        {
            bool libre = true;
            for (int j = 0; j < size; j++)
            {
                if (slotOcupado[i + j]) { libre = false; break; }
            }
            if (libre) return i;
        }
        return -1;
    }

    public void EliminarUltimaSilleta()
    {
        if (silletasInstanciadas.Count == 0)
        {
            Debug.LogWarning("No hay silletas para eliminar.");
            if (estadoTexto != null)
                estadoTexto.text = "No hay silletas para eliminar";
            return;
        }

        // Obtener la última silleta agregada
        GameObject ultimaSilleta = silletasInstanciadas[silletasInstanciadas.Count - 1];

        // Liberar sus slots
        Silleta_individual s = ultimaSilleta.GetComponent<Silleta_individual>();
        if (s != null)
        {
            for (int i = s.startSlot; i < s.startSlot + s.size; i++)
            {
                slotOcupado[i] = false;
            }
        }

        // Eliminarla del juego y de la lista
        Destroy(ultimaSilleta);
        silletasInstanciadas.RemoveAt(silletasInstanciadas.Count - 1);

        if (estadoTexto != null)
            estadoTexto.text = $"Silleta eliminada (quedan {silletasInstanciadas.Count})";
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (slots == null) return;
        foreach (Transform slot in slots)
        {
            if (slot != null)
                Gizmos.DrawWireCube(slot.position, new Vector3(0.46f, 0.1242188f, 0.2267891f));
        }
    }
}
