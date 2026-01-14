using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaterialItemUI : MonoBehaviour
{
    public TMP_Text txtNombre;
    public TMP_InputField inputCantidad;

    private Material material;

    public void Inicializar(Material mat)
    {
        material = mat;

        txtNombre.text = mat.nombre_Material;
        inputCantidad.text = mat.Numero_Parte.ToString();

        inputCantidad.onEndEdit.RemoveAllListeners();
        inputCantidad.onEndEdit.AddListener(OnCantidadChanged);
    }

    void OnCantidadChanged(string value)
    {
        if (int.TryParse(value, out int cantidad))
        {
            txtNombre.text = material.nombre_Material;
            inputCantidad.text = material.Numero_Parte.ToString();
        }
    }
}
