using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaMaterialesUI : MonoBehaviour
{
    public MaterialItemUI prefabItem;
    public Transform content;

    public void MostrarMateriales(ent_seccion seccion)
    {
        // Limpia lista anterior
        foreach (Transform hijo in content)
            Destroy(hijo.gameObject);

        // Genera UI dinámicamente
        foreach (var material in seccion.ObtenerMateriales())
        {
            /*var item = Instantiate(prefabItem, content);
            item.MostrarPrecio(material);*/
        }
    }
}
