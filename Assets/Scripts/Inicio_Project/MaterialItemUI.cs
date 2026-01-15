using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaterialItemUI : MonoBehaviour
{
    public TMP_Text txtNombre;
    public TMP_InputField inputPrecio;
    public UnityEngine.UI.Toggle toggleActivo;

    Material material;

    public void Bind(Material mat)
    {
        material = mat;

        txtNombre.text = mat.nombre_Material;
        inputPrecio.text = mat.Precio.ToString("0.00");

        inputPrecio.onEndEdit.AddListener(v =>
        {
            if (double.TryParse(v, out double p))
                mat.Precio = p;
        });
    }
}
