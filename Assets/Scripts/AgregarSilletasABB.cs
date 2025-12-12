using UnityEngine;

public class AgregarSilletasABB : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;       // El empty donde quieres que aparezca
    public float offsetX = 2f;         // Separación hacia la derecha
    private Vector3 ultimoSpawn;

    private bool primero = true;

    public void AgregarPrefab()
    {
        Vector3 posicion;

        if (primero)
        {
            // El primer modelo aparece EXACTO donde está tu empty
            posicion = spawnPoint.position;
            ultimoSpawn = posicion;
            primero = false;
        }
        else
        {
            // Para los siguientes, simplemente avanzamos en X
            posicion = ultimoSpawn + new Vector3(offsetX, 0, 0);
            ultimoSpawn = posicion;
        }

        // Instanciamos sin que el pivot lo mueva
        GameObject nuevo = Instantiate(prefab, posicion, Quaternion.identity);

        // Evita que cambie de tamaño por el parent
        nuevo.transform.localScale = prefab.transform.localScale;
    }
}
