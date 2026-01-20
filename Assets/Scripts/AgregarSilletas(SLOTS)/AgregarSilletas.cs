using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgregarSilletas : MonoBehaviour
{
    //Se crea los campos para que se agreguen los diferentes tipos de silletas
    [Header("Slots dentro del gabinete")]
    public List<Transform> slots = new List<Transform>(); // 12 slots físicos en el gabinete

    [Header("Tipos de silletas")]
    public GameObject silleta0_5F; // ocupa 1 espacio
    public GameObject silleta1F; // ocupa 2 espacios
    public GameObject silleta1_5F; // ocupa 3 espacios
    public GameObject silleta2F; // ocupa 4 espacios
    public GameObject silleta2_5F; // ocupa 5 espacios
    public GameObject silleta3F; // ocupa 6 espacios
    public GameObject silleta6F; // ocupa 12 espacios

    //Cuantas secciones hay  puestas
    [Header("Prefabs")]
    public GameObject slotPrefab;
    public Transform slotContainer;

    public int slotsPorSeccion = 12;
    public float separacionX = 0.35f;

    [Header("UI")]
    public Text estadoTexto;

    //Dice cuantos slots hay ocupado
    private List<bool> slotOcupado = new List<bool>();
    //Hara la funcion de eliminar silleta
    private List<GameObject> silletasInstanciadas = new List<GameObject>();

    public void AgregarSeccion()
    {
        int inicio = slots.Count;

        for (int i = 0; i < slotsPorSeccion; i++)
        {
            GameObject nuevoSlot = Instantiate(slotPrefab, slotContainer);

            // Posición consecutiva
            nuevoSlot.transform.localPosition =
                new Vector3((inicio + i) * separacionX, 0, 0);

            slots.Add(nuevoSlot.transform);
            slotOcupado.Add(false);
        }
    }

    public bool PlaceSilleta(int startSlot, GameObject silletaPrefab, int size, Vector3 localPosOffset)
    {
        // Verificar si hay espacio suficiente
        if (startSlot + size > slots.Count)
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
        for (int i = 0; i < slots.Count - size + 1; i++)
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
                Gizmos.DrawWireCube(slot.position, new Vector3(0.3242188f, 0.1242188f, 0.2267891f));
        }
    }
}
