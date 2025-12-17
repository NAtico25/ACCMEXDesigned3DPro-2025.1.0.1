using TMPro;
using UnityEngine;

public class AgregarSilletasABB : MonoBehaviour
{
    public GameObject prefab;
    public Transform contenedor;   // ESTE es tu empty padre
    public float offsetX = 2f;

    private int contador = 1;
    private Vector3 ultimaPosicion;
    private bool primero = true;

    public void AgregarPrefab()
    {
        Vector3 pos;

        if (primero)
        {
            // Primer objeto se coloca donde está el empty
            pos = contenedor.position;
            ultimaPosicion = pos;
            primero = false;
        }
        else
        {
            // Los siguientes avanzan en X
            pos = ultimaPosicion + new Vector3(offsetX, 0, 0);
            ultimaPosicion = pos;
        }

        // Instanciar como hijo del empty
        GameObject nuevo = Instantiate(prefab, pos, Quaternion.identity, contenedor);

        // Asegura que no cambie de tamaño por el parent
        nuevo.transform.localScale = prefab.transform.localScale;
       
        nuevo.GetComponent<ent_seccion>().no_seccion = contenedor.childCount; // Asignar numero de seccion basado en la cantidad de hijos
        Debug.Log("Se agregó la silleta número: " + nuevo.GetComponent<ent_seccion>().no_seccion);

        // Cambiar el texto del prefab clonado
        TMP_Text texto = nuevo.GetComponentInChildren<TMP_Text>();
        if (texto != null)
        {
            texto.text = $"Seccion {contador}";
        }

        contador++;
    }
}
