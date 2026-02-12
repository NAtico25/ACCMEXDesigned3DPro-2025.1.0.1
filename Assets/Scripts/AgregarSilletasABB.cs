using TMPro;
using UnityEngine;

public class AgregarSilletasABB : MonoBehaviour
{
    public Transform contenedor;

    public void AgregarPrefab(GameObject prefab)
    {
        Vector3 pos;

        if (contenedor.childCount == 0)
        {
            pos = contenedor.position;
        }
        else
        {
            Transform ultimoHijo = contenedor.GetChild(contenedor.childCount - 1);

            float anchoUltimo = ObtenerAncho(ultimoHijo.gameObject);
            float anchoNuevo = ObtenerAncho(prefab);

            pos = ultimoHijo.position +
                  new Vector3((anchoUltimo / 2f) + (anchoNuevo / 2f), 0, 0);
        }

        GameObject nuevo = Instantiate(prefab, pos, Quaternion.identity, contenedor);
        nuevo.transform.localScale = prefab.transform.localScale;

        nuevo.GetComponent<ent_seccion>().no_seccion = contenedor.childCount;

        TMP_Text texto = nuevo.GetComponentInChildren<TMP_Text>();
        if (texto != null)
        {
            texto.text = $"Seccion {contenedor.childCount}";
        }
    }

    float ObtenerAncho(GameObject obj)
    {
        Renderer rend = obj.GetComponentInChildren<Renderer>();
        if (rend != null)
            return rend.bounds.size.x;

        return 1f;
    }
}
