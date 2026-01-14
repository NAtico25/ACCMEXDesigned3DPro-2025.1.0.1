using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaMaterialesUI : MonoBehaviour
{
    public MaterialItemUI prefabItem;
    public Transform contenedor;

    public void Construir(List<Material> materiales)
    {
        foreach (Transform child in contenedor)
            Destroy(child.gameObject);

        foreach (var mat in materiales)
        {
            if (mat == null) continue;

            var item = Instantiate(prefabItem, contenedor);
            item.Inicializar(mat);
        }
    }
}
